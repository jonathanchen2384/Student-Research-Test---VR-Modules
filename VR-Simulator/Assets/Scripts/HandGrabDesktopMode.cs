using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class HandGrabDesktopMode : MonoBehaviour
{
    [SerializeField] Animator leftHandAnim;
    [SerializeField] Animator rightHandAnim;

    string actionType = "Grip";

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            if (leftHandAnim.GetFloat(actionType) == 1)
            {
                leftHandAnim.SetFloat(actionType, 0);
            }

            else
            {
                leftHandAnim.SetFloat(actionType, 1);
            }
        }

        else {
            if (leftHandAnim.GetFloat(actionType) > 0)
            {
                leftHandAnim.SetFloat(actionType, leftHandAnim.GetFloat(actionType)-1);
            }
        }


        if (Input.GetKey(KeyCode.K))
        {
            if (rightHandAnim.GetFloat(actionType) == 1)
            {
                rightHandAnim.SetFloat(actionType, 0);
            }

            else
            {
                rightHandAnim.SetFloat(actionType, 1);
            }
        }

    }
}