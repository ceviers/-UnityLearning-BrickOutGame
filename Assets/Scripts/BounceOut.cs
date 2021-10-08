using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BounceOut : MonoBehaviour
{
    public Transform ball;
    public Rigidbody RBall;
    public Transform paddle;

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.name.Equals("Ball"))
        {
            GameController.instance.GameOver(ball, paddle, RBall);
            GameController.instance.isRunning = false;
        }
        else
        {
            Destroy(other.gameObject);
        }
        
    }
}
