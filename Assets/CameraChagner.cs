using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChagner : MonoBehaviour
{
    private CinemachineVirtualCamera roomCamera;

    private void Start()
    {
        roomCamera = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            roomCamera.Priority += 2;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            roomCamera.Priority -= 2;
        }
    }
}
