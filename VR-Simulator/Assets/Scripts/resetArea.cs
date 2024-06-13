using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetArea : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    [SerializeField] Transform[] initPos;

    public void resetPos()
    {
        Debug.Log("Button pressed");
        for (int i = 0; i < objects.Length; i++)
        {
            if (i < initPos.Length)
            {
                objects[i].transform.position = initPos[i].position;
                objects[i].transform.rotation = initPos[i].rotation;
                objects[i].transform.localScale = initPos[i].localScale;
            }

            else {
                objects[i].transform.position = initPos[initPos.Length - 1].position;
                objects[i].transform.rotation = initPos[initPos.Length - 1].rotation;
                objects[i].transform.localScale = initPos[initPos.Length - 1].localScale;
            }
        }
    }

    public void resetRot()
    {
        Debug.Log("Button pressed");
        for (int i = 0; i < objects.Length; i++)
        {
            if (i < initPos.Length)
            {
                objects[i].transform.rotation = initPos[i].rotation;
            }

            else
            {
                objects[i].transform.rotation = initPos[initPos.Length - 1].rotation;
            }
        }
    }
}