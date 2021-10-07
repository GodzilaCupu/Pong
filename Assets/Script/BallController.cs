using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float xIntialForce;
    public float yIntialForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        RestartGame();
    }

    private void ResetBall()
    {
        transform.position = Vector2.zero;

        rb.velocity = Vector2.zero;
    }

    private void PushBall()
    {
        float yRandomInitialForce = Random.Range(-yIntialForce, yIntialForce);

        float randomDirection = Random.Range(0, 2);

        if(randomDirection < 1.0f)
        {
            rb.AddForce(new Vector2(-xIntialForce, yRandomInitialForce));
        }
        else
        {
            rb.AddForce(new Vector2(xIntialForce, yRandomInitialForce));
        }
    }

    private void RestartGame()
    {
        ResetBall();

        Invoke("PushBall", 2);
    }
}
