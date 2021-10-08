using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollide : MonoBehaviour
{
    public enum BreakType
    {
        Normal,
        Unbreakable,
        HPBall
    }

    public BreakType type;
    private Vector3 cur_posi;
    public GameObject HPBallPerfeb;
    public GameObject CrashEffect;
    public AudioSource CrshSoundEffect;

    void OnCollisionEnter(Collision other)
    {
        if(gameObject.GetComponent<BrickCollide>().type != BreakType.Unbreakable)
        {
            BrickCollide[] bricks = GameObject.FindObjectsOfType<BrickCollide>();
            int count = 0;
            foreach (BrickCollide brick in bricks)
            {
                if (brick.type != BreakType.Unbreakable)
                    count++;
            }
            if (count <= 1)
            {
                GameController.instance.isClear = true;
            }
            CrshSoundEffect.Play();
            cur_posi = gameObject.transform.position;
            GameObject ce = Instantiate(CrashEffect);
            ce.GetComponent<Renderer>().material.color =  gameObject.GetComponent<MeshRenderer>().material.color;
            ce.transform.position = cur_posi;
            Destroy(gameObject);
        }

        if(gameObject.GetComponent<BrickCollide>().type == BreakType.HPBall)
        {
            GameObject HPBall = Instantiate(HPBallPerfeb);
            cur_posi.z = 1f;
            HPBall.transform.position = cur_posi;
        }
    }
}
