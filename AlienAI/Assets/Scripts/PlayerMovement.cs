using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 newVelocity;
    public Transform camera;

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
        //Vector3 move = new Vector3(transform.position.x * Input.GetAxis("Horizontal"), 0f, (transform.position.z - camera.position.z) * Input.GetAxis("Vertical"));
        newVelocity = new Vector3(Input.GetAxis("Horizontal") * playerSpeed, 0.0f, Input.GetAxis("Vertical") * playerSpeed);
        rb.velocity = newVelocity;
        //rb.AddForce(move);
    }
}
