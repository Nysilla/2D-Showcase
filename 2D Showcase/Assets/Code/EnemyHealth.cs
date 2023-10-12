using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int health = 100;
    [SerializeField] int playerDamage = 15;
    //public static int soulCount;
    int maxHealth = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
            health -= playerDamage;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
            health -= playerDamage;
        }
    }
    void Start()
    {
        maxHealth = health;
    }
    void Update()
    {
        if (health <= 0)
        {
            //soulCount++;
            //myText.text = "Souls: " + soulCount;
            Destroy(gameObject);
        }
    }

}
