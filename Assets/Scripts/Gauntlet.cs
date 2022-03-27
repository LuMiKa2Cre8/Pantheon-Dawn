using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Gauntlet : MonoBehaviour
{
    [SerializeField]
    private int currentWave;
    private int maxWave;
    private GameObject wave;
    [SerializeField]
    private GameObject door;

    private void OnEnable()
    {
        currentWave = 0;
        maxWave = this.transform.childCount;
        ProgressWave();
    }

    private void Update()
    {
        if (wave.transform.childCount == 0)
        {
            if (currentWave == maxWave)
            {
                door.SetActive(false);
                this.transform.parent.GetComponentInChildren<CinemachineVirtualCamera>().Priority -= 2;
                Destroy(this.gameObject);
            }
            else ProgressWave();
        }
    }

    private void StartWave()
    {    
        wave.SetActive(true);
    }

    private void SetWave()
    {
        ++currentWave;
        wave = this.transform.Find("Wave" + currentWave.ToString()).gameObject;
    }

    private void ProgressWave()
    {
        SetWave();

        if (wave != null)
        {
            StartWave();
        }
    }

    public static void bruh()
    {
        Debug.Log("breh");
    }
}
