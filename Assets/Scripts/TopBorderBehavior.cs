using System;
using UnityEngine;

public class TopBorderBehavior : MonoBehaviour
{
    public float timeout;
    private float timeStart;
    private float timeThusFar;
    public GameObject gameOver;
    //public bool isGameOver = false;
    
    public PlayerBehavior player;

    // adding a check to fix the bug where the timeout resets every time a new one enters the collider
    private int ballsInZone = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeStart = Time.time;
        if (player == null) // Check to auto set the reference because we only have one player.
            player = FindObjectOfType<PlayerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            ballsInZone++;
            if (ballsInZone == 1) // First ball to enter starts the clock
            {
                timeStart = Time.time;
                Debug.Log("Game Over Timer Started at: " + timeStart);
            }
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (!player.isGameOver)
        {
            if (collision.gameObject.tag.Equals("Ball"))
            {
                timeThusFar = Time.time - timeStart;
                Debug.Log("Game Over Timer Updated: " + timeThusFar);
                if (timeThusFar >= timeout)
                {
                    Debug.Log("Game Over");
                    player.isGameOver = true;
                    gameOver.SetActive(true);
                }
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            ballsInZone = Mathf.Max(0, ballsInZone - 1);
            if (ballsInZone == 0)
            {
                Debug.Log("No balls left in zone. Timer reset.");
                timeThusFar = 0f;
            }
        }
    }

}
