using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Room : MonoBehaviour
{
    private CinemachineVirtualCamera roomCamera;
    private GameObject doors;

    private void Start()
    {
        roomCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        doors = transform.Find("Grid").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            roomCamera.Priority += 2;
            doors.SetActive(true);
            doors.GetComponentInChildren<CompositeCollider2D>().GenerateGeometry();
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
