using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private float parallaxDistance = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = transform.parent.parent.GetComponent<Transform>();
        //UpdateScale();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.GetComponent<Transform>().position = new Vector2(cameraTransform.position.x * parallaxDistance, cameraTransform.position.y * parallaxDistance);
        //UpdateScale(); //DEBUG
    }

    void UpdateScale()
    {
        this.GetComponent<Transform>().localScale = new Vector2(1 + parallaxDistance, 1 + parallaxDistance);
    }
}
