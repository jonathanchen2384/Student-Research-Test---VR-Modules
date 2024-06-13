using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;

public class VRDetector : MonoBehaviour
{
    [SerializeField] bool SimulatorMode;
    [SerializeField] GameObject simulatorObj;

    void Start()
    {
        if (!SimulatorMode)
        {
            var xrSettings = XRGeneralSettings.Instance;

            if (xrSettings == null)
            {
                Debug.Log("XRGeneralSettings not detected");
                return;
            }

            var xrManager = xrSettings.Manager;

            if (xrManager == null)
            {
                Debug.Log("XR Manager not detected");
                return;
            }

            var xrLoader = xrManager.activeLoader;

            if (xrLoader == null)
            {
                Debug.Log("XR Loader not detected, Desktop mode");

                startInVR(false);

                return;
            }

            Debug.Log("XR is detected: " + xrLoader);

            startInVR(true);
        }

        else {
            Debug.Log("Desktop mode");

            startInVR(false);
        }
    }

    void startInVR( bool StartingVR)
    {
        simulatorObj.SetActive(!StartingVR);
    }
}