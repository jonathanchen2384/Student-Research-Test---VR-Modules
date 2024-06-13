using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class FloatEvent : UnityEvent<float> { }

public class leverScript : MonoBehaviour
{
    [SerializeField] Transform joystick;

    public FloatEvent onLeverValue = new FloatEvent();

    void Start()
    {
        if (!joystick)
        {
            Debug.Log("Error: No Joystick set for " + transform.name);
            return;
        }
    }

    void Update()
    {
        float rotationX = joystick.transform.localEulerAngles.x/3f;

        if (Mathf.Abs(rotationX) > 0.1f)
        {
            onLeverValue.Invoke(rotationX);
        }
    }
}