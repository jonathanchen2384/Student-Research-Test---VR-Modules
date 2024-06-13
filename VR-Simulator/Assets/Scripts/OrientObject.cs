using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientObject : MonoBehaviour
{
    private float accumulatedRotationX = 0f;
    private float accumulatedRotationY = 0f;
    private float accumulatedRotationZ = 0f;

    public void rotateObjectX(float rotX)
    {
        //Debug.Log("spinning X, speed: " + rotX);
        accumulatedRotationX += rotX * Time.deltaTime;
        transform.rotation = Quaternion.Euler(accumulatedRotationX, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    public void rotateObjectY(float rotY)
    {
        //Debug.Log("spinning Y, speed: " + rotY);
        accumulatedRotationY += rotY * Time.deltaTime;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, accumulatedRotationY, transform.eulerAngles.z);
    }

    public void rotateObjectZ(float rotZ)
    {
        //Debug.Log("spinning Z, speed: " + rotZ);
        accumulatedRotationZ += rotZ * Time.deltaTime;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, accumulatedRotationZ);
    }
}