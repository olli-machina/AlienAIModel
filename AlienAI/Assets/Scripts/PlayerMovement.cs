using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 newVelocity;

    public float playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        newVelocity = new Vector3(Input.GetAxis("Horizontal") * playerSpeed, 0.0f, Input.GetAxis("Vertical") * playerSpeed);
        rb.velocity = newVelocity;
    }
}
