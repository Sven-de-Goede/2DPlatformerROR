using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public Transform Gun;
    public Transform shootPoint;
    Vector2 direction;
    public GameObject Bullet;
    public GameObject BulletClone;
    public float bulletSpeed;
    public float fireRate;
    float readyForNextShot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BulletClone = GameObject.Find("Bullet(Clone)");

        Gun.transform.position = transform.position;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Gun.position;
        faceMouse();

        if (Input.GetMouseButton(0))
        {
            if (Time.time > readyForNextShot)
            {
                readyForNextShot = Time.time + 1 / fireRate;
                shoot();
                
            }
            
            Destroy(BulletClone, 2);
        }
    }

    void faceMouse()
    {
        Gun.transform.right = direction;
    }

    void shoot()
    {
        GameObject bulletIns = Instantiate(Bullet, shootPoint.position, shootPoint.rotation);
        bulletIns.GetComponent<Rigidbody2D>().AddForce(bulletIns.transform.right * bulletSpeed);
        
    }
} 