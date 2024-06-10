using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCam : MonoBehaviour
{
    public float sensitivityX, sensitivityY;
    [SerializeField] float yRotation, xRotation;
    public Transform playerOrientation;

    void Start()
    {
        // cursor set to middle and invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // tracking input mouse movements
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivityX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivityY;

        // increment rotation with respect mouse inputs via Quaternion method
        yRotation += mouseX;
        xRotation -= mouseY;

        // clamping to limit the vertical view range between -90 and 90
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // set the values to the rotation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        // rotate the player horizontally
        if (playerOrientation)
        {
            playerOrientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}