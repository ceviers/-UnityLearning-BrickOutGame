using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashEffectController : MonoBehaviour
{
    public float effectDuration;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, effectDuration);
    }
}
