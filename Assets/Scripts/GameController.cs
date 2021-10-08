using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public bool isRunning = false;
    public int HP = 3;
    public Text HPText;
    public bool isClear = false;
    public GameObject ClearText;
    public GameObject LossText;

    void Awake()
    {
        instance = this;
        HPText.text = "Balls: " + HP;
    }
    // Start is called before the first frame update
    void Start()
    {
        BrickCollide[] bricks = GameObject.FindObjectsOfType<BrickCollide>();
        foreach(var brick in bricks)
        {
            if(brick.type != BrickCollide.BreakType.Unbreakable)
                brick.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (isClear) {
            ClearText.SetActive(true);
            isRunning = false;
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
            

    }

    public void GameOver(Transform ball, Transform paddle, Rigidbody RBall)
    {
        HPText.text = "Balls: " + --HP;
        Vector3 posi = ball.position;
        posi.x = paddle.position.x;
        posi.y = paddle.position.y + 0.25f;
        ball.position = posi;
        RBall.velocity = Vector3.zero;
    }

}
