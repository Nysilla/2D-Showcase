using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject bullet;
    [SerializeField] float timeToFire = 1;
    [SerializeField] float bulletSpeed = 5;
    [SerializeField] int bulletLifeTime = 2;
    [SerializeField] float shootDistance = 5;
    [SerializeField] bool predictiveShoot = true;
    [SerializeField] float predictiveLead = 1;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Vector3 playerPosition = player.transform.position;
        Vector3 shootDirection = playerPosition - transform.position;

        if (shootDirection.magnitude < shootDistance && timer >= timeToFire)
        {
            if (predictiveShoot)
            {
                Vector3 playerVel = player.GetComponent<Rigidbody2D>().velocity;
                shootDirection += playerVel * predictiveLead;
            }

            timer = 0;
            shootDirection.Normalize();
            GameObject enemyBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            enemyBullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletSpeed;
            Destroy(enemyBullet, bulletLifeTime);
        }
    }
}
