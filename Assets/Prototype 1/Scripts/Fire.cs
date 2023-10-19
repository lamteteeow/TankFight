using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UIElements;

public class Fire : MonoBehaviour
{
    // Drag in the Bullet Emitter from the Component Inspector.
    public GameObject BulletEmitter;

    // Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;

    // Enter the Speed of the Bullet from the Component Inspector.
    public float Bullet_Forward_Force;
    private float fireInput;
    public string inputID;

    // Shooting overload
    private float gunHeat;

    public double emitAngle;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        fireInput = Input.GetAxis("Fire" + inputID);

        if (gunHeat > 0)
        {
            gunHeat -= Time.deltaTime;
        }

        if (fireInput > 0)
        {
            if (gunHeat <= 0)
            {
                gunHeat = 0.5f;
                Shoot();
            }
        }
    }
    private void Shoot()
    {
        emitAngle = 1.5 * Math.PI / 180;

        //The Bullet instantiation happens here.
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Bullet, BulletEmitter.transform.position, BulletEmitter.transform.rotation) as GameObject;

        //Retrieve the Rigidbody component from the instantiated Bullet and control it.
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

        //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
        Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force * (float)Math.Cos(emitAngle));
        Temporary_RigidBody.AddForce(transform.up * Bullet_Forward_Force * (float)Math.Sin(emitAngle));

        // Clean Up after 3 seconds
        Destroy(Temporary_Bullet_Handler, 3.5f);
    }
}