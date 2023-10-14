using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;


public class PlayerController : MonoBehaviour
{
    private float velocity = 0.0f;
    private float turnVelocity;
    private const float innertia = 0.15f;
    private float horizontalInput;
    private float forwardInput;

    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;
    public string inputID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turnVelocity = 17 * Math.Abs(velocity);
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        if (velocity - innertia > 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 20 * (velocity - innertia));
        }
        if (velocity + innertia < 0)
        {
            transform.Translate(Vector3.back * Time.deltaTime * 15 * -(velocity + innertia));
        }

        // Create user input in order to move increase and decrease the acceleration
        if (forwardInput > 0)
        {
            if (velocity <= 2.2f) // Set max velocity
            {
                velocity += 0.006f;
                // increase field of view as the user press W
                mainCamera.fieldOfView += (Math.Abs(velocity) * 0.05f);
            }
        } else
        {
            // Decrease field of view as the vehicle naturally slows down until the original field of view is reached
            if (mainCamera.fieldOfView >= 60.07f)
            {
                mainCamera.fieldOfView -= 0.07f;
            }
        }
        if (forwardInput < 0)
        {
            if (velocity >= -2.0f) // Set max reverse velocity
            {
                velocity -= 0.01f;
                // increase field of view as the user press S
                mainCamera.fieldOfView += (Math.Abs(velocity) * 0.05f);
            }
        }

        // create user input in order to turn the vehicle left and right
        transform.Rotate(Vector3.up, Time.deltaTime * turnVelocity * horizontalInput);

        // Reduce velocity if gas is not given
        if (forwardInput == 0)
        {
            if (velocity > innertia)
            {
                velocity -= 0.01f;
            }
            if (velocity < -innertia)
            {
                velocity += 0.01f;
            }
        }

        // Switch between cameras
        if (Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
        }
    }
}
