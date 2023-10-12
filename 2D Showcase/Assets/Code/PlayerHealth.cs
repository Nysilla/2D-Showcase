using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] TextMeshProUGUI myText;
    [SerializeField] int soulHealthValue = 10;
    [SerializeField] int enemyDamage = 15;
    [SerializeField] int maxHealth = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            health-= enemyDamage;
            myText.text = "Health: " + health;

            if (health < 0)
            {
                health = 0;
            }
            myText.text = "Health: " + health;
        }

        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            health--;
            myText.text = "Health: " + health;

            if (health < 0)
            {
                health = 0;
            }
            myText.text = "Health: " + health;

            if (collision.gameObject.tag == "EnemyBullet")
            {
                Destroy(collision.gameObject);
            }
        }
        
        if (collision.gameObject.tag == "Soul")
        {
            if (health < maxHealth)
            {
                Destroy(collision.gameObject);
                health += soulHealthValue;
            }
            
            if (health > maxHealth)
            {
                health = maxHealth;
            }
            myText.text = "Health: " + health;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        myText.text = "Health: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
