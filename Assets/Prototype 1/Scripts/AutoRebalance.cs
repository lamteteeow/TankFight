using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRebalance : MonoBehaviour
{
    private Rigidbody rb;
    private float stablization = 15000f;
    public float dampening;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 torqueVertical = stablization * Vector3.Cross(transform.up, Vector3.up) - 1 * dampening * rb.angularVelocity;
        Vector3 torqueHorizontal = stablization * Vector3.Cross(transform.right, Vector3.right) - 2.5f * dampening * rb.angularVelocity;
        Vector3 torqueForward = stablization * Vector3.Cross(transform.forward, Vector3.forward) - 1.5f * dampening * rb.angularVelocity;
        rb.AddTorque(torqueVertical);
        rb.AddTorque(torqueHorizontal);
        rb.AddTorque(torqueForward);
    }
}
