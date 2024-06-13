using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    [SerializeField] float threshold = 0.1f;
    [SerializeField] float deadzone = 0.025f;

    bool isPressed;
    Vector3 startPos;
    ConfigurableJoint buttonJoint;

    public UnityEvent onPressed, onRelease;

    void Start()
    {
        startPos = transform.localPosition;
        buttonJoint = GetComponent<ConfigurableJoint>();
    }

    void Update()
    {
        if (!isPressed && getValue() + threshold >= 1)
        {
            buttonPressed();
        }

        if (isPressed && getValue() - threshold <= 0)
        {
            buttonReleased();
        }
    }

    void buttonPressed()
    {
        isPressed = true;
        onPressed.Invoke();

    }

    void buttonReleased()
    {
        isPressed = false;
        onRelease.Invoke();
    }

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
