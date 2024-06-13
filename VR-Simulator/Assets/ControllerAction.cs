using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ControllerAction : MonoBehaviour
{
    public InputActionProperty pinchAction;
    public InputActionProperty grabAction;

    bool isPinchPressed;
    bool isGrabPressed;

    public UnityEvent onPinchPressed, onPinchRelease;
    public UnityEvent onGrabPressed, onGrabRelease;

    void Update()
    {
        // pinch

        if (!isPinchPressed && pinchAction.action.ReadValue<float>() > 0.1f)
        {
            pinchPressed();
        }

        if (isPinchPressed && pinchAction.action.ReadValue<float>() < 0.1f)
        {
            pinchReleased();
        }

        // grab

        if (!isGrabPressed && grabAction.action.ReadValue<float>() > 0.1f)
        {
            grabPressed();
        }

        if (isGrabPressed && grabAction.action.ReadValue<float>() < 0.1f)
        {
            grabReleased();
        }
    }

    void pinchPressed()
    {
        isPinchPressed = true;
        onPinchPressed.Invoke();

    }

    void pinchReleased()
    {
        isPinchPressed = false;
        onPinchRelease.Invoke();
    }

    void grabPressed()
    {
        isPinchPressed = true;
        onPinchPressed.Invoke();

    }

    void grabReleased()
    {
        isPinchPressed = false;
        onPinchRelease.Invoke();
    }
}