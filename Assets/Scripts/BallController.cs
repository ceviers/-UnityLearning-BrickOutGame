using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    private Rigidbody ball;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        velocity = new Vector3(1f, 1f, 0f).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameController.instance.isRunning)
        {
            if ((ball.velocity.x == 0 || ball.velocity.y == 0) && ball.velocity != Vector3.zero)
            {
                ball.velocity = new Vector3(1f, 1f, 0f).normalized * speed;
            }
            
            if (Input.GetKeyUp(KeyCode.Space))
            {
                velocity = ball.velocity;
                ball.velocity = Vector3.zero;
                GameController.instance.isRunning = false;
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Space) && GameController.instance.HP > 0)
            {
                ball.velocity = velocity;
                GameController.instance.isRunning = true;
            }
            if(GameController.instance.HP <= 0)
            {
                GameController.instance.LossText.SetActive(true);
            }
            if(GameController.instance.isClear)
                ball.velocity = Vector3.zero;
        }

    }

    private void OnCollisionOut(Collision other)
    {
        if (GameController.instance.isRunning)
        {
            Vector3 temp = ball.velocity.normalized;
            ball.velocity = temp * speed;
        }
    }
}
