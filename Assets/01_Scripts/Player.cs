using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{
    public static  int player1Score=0;
    public static int player2Score=0;
    public TextMeshProUGUI score;
    public PlayerType type;
    public bool isPlayerWall;
     string up;
   string down;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
       
        switch (type)
        {
            case PlayerType.FirstPlayer:
                if (!isPlayerWall)
                {

                    up = "w";
                    down = "s";
                }
                break;
            case PlayerType.Secondplayer:
                if (!isPlayerWall)
                {
                    up = "up";
                    down = "down";
                }
                break;
            default:
                break;
            }   
        }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayerWall) Movement();

    }
    public void Movement()
    {
  
        float y = 0;
        if (Input.GetKey(up))
        {
            y += 1;
        }
        else if (Input.GetKey(down))
        {
            y -= 1;
        }
        rb.velocity = new Vector2(0, y) * moveSpeed;
  
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Ball") && isPlayerWall)
        {
        
            switch (type)
                {
                    case PlayerType.FirstPlayer:
                   
                    player2Score++;
                    score.text = player2Score.ToString();
               

                    break;
                    case PlayerType.Secondplayer:
                    player1Score++;
                    score.text = player1Score.ToString();
             

                    break;
                    default:
                        break;
                }

        }

    }
}


public enum PlayerType
{
    FirstPlayer,
    Secondplayer

}