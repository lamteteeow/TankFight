using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusAutorunning : MonoBehaviour
{
    public float speed = 0.05f;
    public Vector3 originalPos = new Vector3(5.75f, 0, 410.1f);
    public Vector3 originalRot = new Vector3(0, 180, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed);
        if (transform.position.y < -5.0f)
        {
            transform.position = originalPos;
            transform.eulerAngles = originalRot;
        }
    }
}
