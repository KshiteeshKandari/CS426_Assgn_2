using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Billboard : MonoBehaviour
{
    public Transform localPlayerCamera;

    void Start()
    {
        FindLocalPlayerCamera();
    }

    void LateUpdate()
    {
        if (localPlayerCamera != null)
        {
            transform.LookAt(transform.position + localPlayerCamera.forward);
        }
    }

    void FindLocalPlayerCamera()
    {
        foreach (var player in FindObjectsOfType<NetworkObject>())
         {
            
            if (player.IsLocalPlayer)
            {
                localPlayerCamera = player.GetComponentInChildren<Transform>();
                Debug.Log("Found");
                break;
            }
         }
    }
}

