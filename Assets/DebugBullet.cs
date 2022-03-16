using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugBullet : MonoBehaviour
{
    public bool facingright = false;



    void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        if (facingright)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * 10f;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * 10f;
        }
    }



    private void OnTriggerEnter2D(Collider2D other )
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<Entity>() != null)
        {


            other.gameObject.GetComponent<Entity>().TakeDamage(4f, GetComponent<Projectile>().ID);
            other.gameObject.GetComponent<Entity>().KnockBack(2f, this.gameObject);



        }
    }
}
