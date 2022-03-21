using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Room : MonoBehaviour
{
    private CinemachineVirtualCamera roomCamera;
    private GameObject doors;
    private bool hasGauntletSpawned;

    private void Start()
    {
        roomCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        doors = transform.Find("Grid").gameObject;
        hasGauntletSpawned = false;
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GameObject gauntlet = this.transform.Find("Gauntlet").gameObject;
        if (collision.gameObject.tag == "Player")
        {
            if (!hasGauntletSpawned)
            {
                doors.SetActive(true);
                doors.GetComponentInChildren<CompositeCollider2D>().GenerateGeometry();
                
                this.transform.Find("Gauntlet").gameObject.SetActive(true);

                roomCamera.Priority += 2;

                hasGauntletSpawned = true;
            }
        }
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        roomCamera.Priority -= 2;
    //    }
    //}
}
