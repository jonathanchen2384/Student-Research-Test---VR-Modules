using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// declaring float usage for unity event for passing float parameter

[System.Serializable]
public class FloatEvent : UnityEvent<float> { }

public class leverScript : MonoBehaviour
{
    [SerializeField] Transform joystick;

    float scaler = 0.333f;

    // float parameter event
    public FloatEvent onLeverValue = new FloatEvent();

    // check for joystick during the start of the game
    void Start()
    {
        if (!joystick)
        {
            Debug.Log("Error: No Joystick set for " + transform.name);
            return;
        }
    }

    // if the rotation value from the lever's joint is not zero,
    // invoke the onLeverValue event with the respective values for the parameters
    void Update()
    {
        float rotationX = joystick.transform.localEulerAngles.x*scaler;

        if (Mathf.Abs(rotationX) > 0.1f)
        {
            onLeverValue.Invoke(rotationX);
        }
    }
}