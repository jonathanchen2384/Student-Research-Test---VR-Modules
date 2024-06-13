using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


// require Ray Interactor
[RequireComponent(typeof(XRRayInteractor))]


public class RayToggler : MonoBehaviour
{
    /*
     * Toggler to maintain both Direct and Ray Interactors,
     * Multiple Interactors used allows the use of both
     * selecting objects and perform actions through rays
     * and interacting with objects physically through direct contact.
     * 
     * This can be useful when the user wants to interact with objects
     * but also wants to be able to teleport through rays
     */

    [SerializeField] private InputActionReference activateReference = null;
    private XRRayInteractor rayInteractor = null;
    private bool isEnabled = false;

    // set ray interactor on awake
    private void Awake()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
    }

    // enable toggle ray 
    private void OnEnable()
    {
        activateReference.action.started += ToggleRay;
        activateReference.action.canceled += ToggleRay;
    }

    // disable toggle ray 
    private void OnDisable()
    {
        activateReference.action.started -= ToggleRay;
        activateReference.action.canceled -= ToggleRay;
    }

    // enabling toggle ray based on a given pressed input action
    private void ToggleRay(InputAction.CallbackContext context)
    {
        isEnabled = context.control.IsPressed();
    }

    // call apply status
    private void LateUpdate()
    {
        ApplyStatus();
    }


    // making sure the ray interactor is enabled
    private void ApplyStatus()
    {
        if (rayInteractor.enabled != isEnabled)
        {
            rayInteractor.enabled = isEnabled;
        }
    }
}