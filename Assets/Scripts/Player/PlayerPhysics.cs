using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    public float initialForce = 100f;
    public float gravityMultiplier = 50f;
    private Rigidbody2D rb;
    private bool orbiting = false;
    public Transform orbitingObject;

    private bool stableOrbit = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * initialForce);
    }

    void FixedUpdate()
    {
        if (orbiting)
        {
            if (stableOrbit)
            {
                
            }
            else
            {
                // direction of gravity
                Vector3 direction = orbitingObject.position - transform.position;
                float distance = direction.magnitude;
                direction.Normalize();
                rb.AddForce(direction * gravityMultiplier / (distance * distance));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            orbiting = false;
        }   
    }

    public void OrbitObject(GravityCenterController newOrbitingObject)
    {
        orbitingObject = newOrbitingObject.transform;
        orbiting = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("KillOnTouch"))
        {
            Debug.Log("Kill :(");
            // todo die
        } 
    }
}