using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform playerTransform;
    public Vector3 cameraOffset;
    public float smoothFactor = 0.5f, rotationSpeedX = 5.0f, rotationSpeedY = 2f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position + cameraOffset;
        FaceMouse();
    }

    void FaceMouse()
    {
        Quaternion canTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeedX, Vector3.up);
        Quaternion canTurnAngleY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * rotationSpeedY, Vector3.left);
        cameraOffset = (canTurnAngle * canTurnAngleY) * cameraOffset;

        Vector3 newPos = playerTransform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        transform.LookAt(playerTransform);
    }
}