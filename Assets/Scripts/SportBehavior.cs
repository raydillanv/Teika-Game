using System;
using UnityEngine;

public class SportBehavior : MonoBehaviour
{
    public float timeout;
    public float timeStart;
    public float timeThusFar;
    public GameObject gameOver;
    public bool GameOver = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        string tag =  collision.gameObject.tag;
        //Debug.Log("You Entered the trigget ofL " + collision.gameObject.tag);
        if (tag.Equals("Top"))
        {
            //Debug.Log("Game Over Timer Started at: " + timeStart);
            timeStart = Time.time;
        }
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (!GameOver)
        {
            string tag =  collision.gameObject.tag;
            //Debug.Log("Trigger Stay on: " + collision.gameObject.tag);
            if (tag.Equals("Top"))
            {
                timeThusFar = Time.time - timeStart;
                Debug.Log("Game over Timer Updated: " + timeThusFar);
                if (timeThusFar >= timeout)
                {
                    Debug.Log("Game Over");
                    GameOver = true;
                } 
            }
        }


    }
}
