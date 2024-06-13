using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class HandGrabDesktopMode : MonoBehaviour
{
    [SerializeField] Animator leftHandAnim;
    [SerializeField] Animator rightHandAnim;
    [SerializeField] float AnimSpeed;

    string actionType = "Grip";

    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            handAction(leftHandAnim);
        }

        else {
            handRelease(leftHandAnim);
        }

        if (Input.GetKey(KeyCode.K))
        {
            handAction(rightHandAnim);
        }

        else {
            handRelease(rightHandAnim);
        }
    }

    void handAction( Animator handType)
    {
        if (handType.GetFloat(actionType) < 1)
        {
            handType.SetFloat(actionType, handType.GetFloat(actionType) + AnimSpeed * Time.deltaTime);
        }
    }

    void handRelease(Animator handType)
    {
        if (handType.GetFloat(actionType) > 0)
        {
            handType.SetFloat(actionType, handType.GetFloat(actionType) - AnimSpeed * Time.deltaTime);
        }
    }
}