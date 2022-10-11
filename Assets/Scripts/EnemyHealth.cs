using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private int enemyHealth = 2;
    SpriteRenderer sprite;
    private Shake shake;
    private ScoreScript Score;
    // Start is called before the first frame update
    void Start()
    {
        Score = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreScript>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    // Update is called once per frame
    void Update()
    {
        ps.transform.position = transform.position;

        if (enemyHealth <= 0){
            shake.CamShake();
            ps.Play();
            Destroy(gameObject);
            Score.score += 10;
            return;
        }
    }

        void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet") {
            enemyHealth -= 1;
            Score.score += 5;
            sprite.color = new Color (1, 0, 0, 1);
            Invoke(nameof(ChangeColorBack), 0.2f);
        }
    }
    void ChangeColorBack(){
        sprite.color = new Color (0.5729389f, 0, 1, 1);
    }
}
