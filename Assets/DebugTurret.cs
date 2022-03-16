using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTurret : MonoBehaviour
{
    public GameObject projectilesource;
    public GameObject projectile;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        if (gameObject.transform.position.x < GameObject.FindGameObjectWithTag("Player").transform.position.x )
        {
            projectilesource.transform.localPosition = new Vector2(1.35f, 0);
            projectile.GetComponent<DebugBullet>().facingright = true;

        }
        else
        {
            projectilesource.transform.localPosition = new Vector2(-1.35f, 0);
            projectile.GetComponent<DebugBullet>().facingright = false;
        }

        projectile.GetComponent<Projectile>().ID = GetComponent<Entity>().Identification;
        
        Instantiate(projectile, projectilesource.transform.position, Quaternion.identity);

    }


    public void Pause()
    {

    }
}
