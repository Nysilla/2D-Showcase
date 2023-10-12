using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableTypes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // whole num
        int health = 100;
        // decimal
            //float velocity = 0.5f;
        // words
            //string name = "Ken, the Abominable Snowman";
        // true or false
            //bool isAlive = true;
        //all different ways to change int/float values
        health = health - 1;
        health -= 1;
        health += 3;
        health--;
        health++;
        if (health <= 0)
        {
             //isAlive = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
