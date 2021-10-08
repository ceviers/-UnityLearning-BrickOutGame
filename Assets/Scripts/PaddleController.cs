using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaddleController : MonoBehaviour
{
    public float speed = 4f;
    public Transform LTrans;
    public Transform RTrans;
    public Text HPText;
    public AudioSource HPSoundEffect;

    // Update is called once per frame
    void Update()
    {
        float paddleX = Input.GetAxisRaw("Horizontal");
        if (paddleX != 0 && GameController.instance.isRunning)
        {
            Vector3 posi = transform.position;
            posi.x += paddleX * Time.deltaTime * speed;
            float paddleWidth = transform.GetComponent<Renderer>().bounds.size.x;
            posi.x = Mathf.Clamp(posi.x, LTrans.position.x + paddleWidth * 0.5f + 0.1f, RTrans.position.x - paddleWidth * 0.5f - 0.1f);
            transform.position = posi;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("HPBall")) {
            HPSoundEffect.Play();
            GameController.instance.HP += 1;
            HPText.text = "Balls: " + GameController.instance.HP;
            Destroy(other.gameObject);
        }
    }
}
