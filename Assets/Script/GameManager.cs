using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player1, player2;
    public Rigidbody2D rb1, rb2;

    public BallController ball;
    private Rigidbody2D rbBall;
    private CircleCollider2D collBall;
    public Trajectory trajectory;

    public int maxScore;

    private bool isDebugWindowShown = false;

    // Start is called before the first frame update
    void Start()
    {
        rb1 = player1.GetComponent<Rigidbody2D>();
        rb2 = player2.GetComponent<Rigidbody2D>();

        rbBall = ball.GetComponent<Rigidbody2D>();
        collBall = ball.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnGUI()
    {
        // posisi Score
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + player1.Score);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + player2.Score);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            player1.ResetScore();
            player2.ResetScore();

            ball.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if (player1.Score == maxScore)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 10, 2000, 1000), "PLAYER ONE WINS");

            ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if (player2.Score == maxScore)
        {
            GUI.Label(new Rect(Screen.width / 2 + 30, Screen.height / 2 - 10, 2000, 1000), "PLAYER TWO WINS");

            ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }


        if (isDebugWindowShown)
        {
            //Simpan Warna
            Color oldColor = GUI.backgroundColor;
            GUI.backgroundColor = Color.red; // warna baru

            // Simpan Variable yang akan di tamplikan 
            float ballMass = rbBall.mass;
            Vector2 ballVelocity = rbBall.velocity;
            float ballSpeed = rbBall.velocity.magnitude;
            Vector2 ballMomentum = ballMass * ballVelocity;

            float ballFraction = collBall.friction;


            float impulsePlayer1X = player1.LastContanctPoint.normalImpulse;
            float impulsePlayer1Y = player1.LastContanctPoint.tangentImpulse;

            float impulsePlayer2X = player2.LastContanctPoint.normalImpulse;
            float impulsePlayer2Y = player2.LastContanctPoint.tangentImpulse;

            // Debug Text
            string debugText =
                "Ball Mass" + ballMass + "\n" +
                "Ball Velocity" + ballVelocity + "\n" +
                "Ball Speed" + ballSpeed + "\n" +
                "Ball Momentum" + ballMomentum + "\n" +
                "Ball Fraction" + ballFraction + "\n" +
                "Last Implse from Player 1 = (" + impulsePlayer1X + "," + impulsePlayer1Y + ")\n" +
                "Last Implse from Player 2 = (" + impulsePlayer2X + "," + impulsePlayer2Y + ")\n";

            // Tampilkan debug window
            GUIStyle guiStyle = new GUIStyle(GUI.skin.textArea);
            guiStyle.alignment = TextAnchor.UpperCenter;
            GUI.TextArea(new Rect(Screen.width / 2 - 200, Screen.height - 200, 400, 110), debugText, guiStyle);
            trajectory.enabled = !trajectory.enabled;

            // Kembalikan warna lama GUI
            GUI.backgroundColor = oldColor;
        }
                    // Toggle nilai debug window ketika pemain mengeklik tombol ini.
            if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height - 73, 120, 53), "TOGGLE\nDEBUG INFO"))
            {
                isDebugWindowShown = !isDebugWindowShown;
            }
    }
}
