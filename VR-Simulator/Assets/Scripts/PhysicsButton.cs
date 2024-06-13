using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{

    /*
     * Flexible Event-based Physics Button
     */

    [SerializeField] float threshold = 0.1f;
    [SerializeField] float deadzone = 0.025f;

    bool isPressed;
    Vector3 startPos;
    ConfigurableJoint buttonJoint;

    public UnityEvent onPressed, onRelease;


    // set default position and set joint component to access in script
    void Start()
    {
        startPos = transform.localPosition;
        buttonJoint = GetComponent<ConfigurableJoint>();
    }

    
    void Update()
    {
        // button is pressed if the physics button is moved from its starting position
        if (!isPressed && getValue() + threshold >= 1)
        {
            buttonPressed();
        }

        // button is released once the user lets go of the button and the button moves
        // back to it's initial position
        if (isPressed && getValue() - threshold <= 0)
        {
            buttonReleased();
        }
    }

    // button pressed -> invoke action
    void buttonPressed()
    {
        isPressed = true;
        onPressed.Invoke();
    }

    // button released -> invoke action
    void buttonReleased()
    {
        isPressed = false;
        onRelease.Invoke();
    }

    // getting the distance of the button to determine if it is pressed
    // clamping to limit to the rage of; -1 to 1.
    float getValue()
    {
        var val = Vector3.Distance(startPos, transform.localPosition) / buttonJoint.linearLimit.limit;

        if (Mathf.Abs(val) < deadzone)
        {
            val = 0;
        }

        return Mathf.Clamp(val, -1f, 1f);
    }
}
