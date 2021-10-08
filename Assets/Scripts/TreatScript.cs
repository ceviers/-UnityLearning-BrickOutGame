using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatScript : MonoBehaviour
{
    public Transform target;
    public Transform LTrans;
    public Transform RTrans;
    private bool treatTag = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.T))
        {
            treatTag = !treatTag;
        }

        if (treatTag)
        {
            Vector3 posi = transform.position;
            posi.x = target.position.x;
            float paddleWidth = transform.GetComponent<Renderer>().bounds.size.x;
            posi.x = Mathf.Clamp(posi.x, LTrans.position.x + paddleWidth * 0.5f + 0.1f, RTrans.position.x - paddleWidth * 0.5f - 0.1f);
            transform.position = posi;
        }
    }
}
