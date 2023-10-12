using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float bulletSpeed = 10;
    [SerializeField] float bulletTime = 3;
    [SerializeField] bool mouseShoot = true;
    float x = 1;
    float y = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (mouseShoot)
            {
                //shoot twards mouse
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector3 shootDir = mousePosition - transform.position;
                shootDir.z = 0;
                shootDir.Normalize();
                x = shootDir.x;
                y = shootDir.y;
            }
            else
            {
                //GetAxisRaw has no acceletation GetAxis does
                float tempX = Input.GetAxisRaw("Horizontal");
                float tempY = Input.GetAxisRaw("Vertical");

                //tracks x and y input
                if (tempX != 0 || tempY != 0)
                {
                    x = tempX;
                    y = tempY;
                }

            }
            if (Input.GetButtonDown("Fire1"))
            {
                //make refference to bullet we creating, Instantiate create new copy of object, what we make, where we make, quaternion what is rotation and confising we using none,
                GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y) * bulletSpeed;
                Destroy(bullet, bulletTime);
            }
        }
    }
}
