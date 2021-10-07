using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //tombol input
    public KeyCode upBtn = KeyCode.W;
    public KeyCode downBtn = KeyCode.S;

    //kecepatan gerak
    public float speed = 10.0f;

    //Boundary vertikal
    public float yBoundary = 9.0f;

    //Rigidbody player
    private Rigidbody2D rbPlayer;

    //skor
    private int score;

    private ContactPoint2D lastContactPoint;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rbPlayer.velocity;


        //player input
        if (Input.GetKey(upBtn))
        {
            velocity.y = speed;
        }
        else if (Input.GetKey(downBtn))
        {
            velocity.y = -speed;
        }
        else
        {
            velocity.y = 0f;
        }
        rbPlayer.velocity = velocity;

        Vector3 position = transform.position;

        if (position.y > yBoundary)
        {
            position.y = yBoundary;
        }
        else if (position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }
        transform.position = position;
    }

    public void IncrementScore()
    {
        score++;
    }

    public void ResetScore()
    {
        score = 0;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        
    }


    public int Score
    {
        get { return score;  }
    }

    public ContactPoint2D lastContanctPoint
    {
        get { return lastContactPoint;  }
    }
}
