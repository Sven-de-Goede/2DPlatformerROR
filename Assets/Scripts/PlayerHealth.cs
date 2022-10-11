using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] public int Health = 2;
    private Shake shake;
    private float hitCooldown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy if health under 0
        if (Health <= 0){
            shake.CamShake();
            Destroy(gameObject);
            return;
        }
        hitCooldown -=0.1f;
    }

    // Detect collision with enemy 
        void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && hitCooldown <=0) {
            Health -= 1;
            sprite.color = new Color (1, 0, 0, 1);
            Invoke(nameof(ChangeColorBack), 0.2f);
            hitCooldown = 7f;
        }
    }
    void ChangeColorBack(){
        sprite.color = new Color (1, 1, 1, 1);
    }
}
