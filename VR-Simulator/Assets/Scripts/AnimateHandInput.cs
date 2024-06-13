using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;

public class AnimateHandInput : MonoBehaviour
{
    [SerializeField] Animator HandAnim;
    public InputActionProperty pinchAction;
    public InputActionProperty grabAction;

    // animate grip and trigger hand animations with respect to controller inputs
    // animation is smoother with real headsets over simulated XR
    void Update()
    {
        HandAnim.SetFloat("Trigger", pinchAction.action.ReadValue<float>());
        HandAnim.SetFloat("Grip", grabAction.action.ReadValue<float>());
    }
}