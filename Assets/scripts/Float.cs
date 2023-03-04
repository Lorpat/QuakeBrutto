using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float freqency = 1f;
    Vector3 posOrigin = new Vector3();
    Vector3 tempPos = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        posOrigin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        tempPos = posOrigin;
        tempPos.y += Mathf.Sin(freqency * Time.fixedTime * Mathf.PI) * amplitude;
        transform.position = tempPos;
    }
}
