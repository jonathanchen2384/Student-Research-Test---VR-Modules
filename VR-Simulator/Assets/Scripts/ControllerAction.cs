using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ControllerAction : MonoBehaviour
{
    /*
     * 
     *  This is a Flexible script for the controller to
     *  Perform actions and call out external functions
     *  based on the user's pinch and grab inputs.
     *  
     *  More inputs may be added to improve the script
     */

    // inputs
    public InputActionProperty pinchAction;
    public InputActionProperty grabAction;

    // flags to prevent recalls
    bool isPinchPressed;
    bool isGrabPressed;

    // events
    public UnityEvent onPinchPressed, onPinchRelease;
    public UnityEvent onGrabPressed, onGrabRelease;


    void Update()
    {
        // pinch is pressed/released

        if (!isPinchPressed && pinchAction.action.ReadValue<float>() > 0.1f)
        {
            pinchPressed();
        }

        if (isPinchPressed && pinchAction.action.ReadValue<float>() < 0.1f)
        {
            pinchReleased();
        }

        // grab is pressed/released

        if (!isGrabPressed && grabAction.action.ReadValue<float>() > 0.1f)
        {
            grabPressed();
        }

        if (isGrabPressed && grabAction.action.ReadValue<float>() < 0.1f)
        {
            grabReleased();
        }
    }

    // Pressing the Pinch -> invoke action

    void pinchPressed()
    {
        isPinchPressed = true;
        onPinchPressed.Invoke();

    }

    // Releasing the Pinch -> invoke action

    void pinchReleased()
    {
        isPinchPressed = false;
        onPinchRelease.Invoke();
    }

    // Pressing the grab -> invoke action

    void grabPressed()
    {
        isPinchPressed = true;
        onPinchPressed.Invoke();

    }

    // Releasing the grab -> invoke action

    void grabReleased()
    {
        isPinchPressed = false;
        onPinchRelease.Invoke();
    }
}