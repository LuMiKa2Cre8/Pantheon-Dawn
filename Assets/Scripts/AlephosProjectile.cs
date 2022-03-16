using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlephosProjectile : MonoBehaviour
{
    public int size = 0;

    public bool facingright;

    public Sprite small;
    public Sprite medium;
    public Sprite large;


    void Start()
    {
        Destroy(this.gameObject, 5f);

        if (size == 0)
        {
            GetComponent<SpriteRenderer>().sprite = small;
            GetComponent<BoxCollider2D>().size = new Vector2(1, 1);
        }
        else if (size == 1)
        {
            GetComponent<SpriteRenderer>().sprite = medium;
            GetComponent<BoxCollider2D>().size = new Vector2(1, 1.5f);
        }
        else if (size ==2)
        {
            GetComponent<SpriteRenderer>().sprite =  large;
            GetComponent<BoxCollider2D>().size = new Vector2(1, 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (size == 0)
        {
            GetComponent<BoxCollider2D>().size = new Vector2(1, 1);

            if (facingright)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * 40f, ForceMode2D.Force);
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.left * 40f, ForceMode2D.Force);
            }
        }
        else if (size == 1)
        {


            if (facingright)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * 60f, ForceMode2D.Force);
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.left * 60f, ForceMode2D.Force);
            }



        }
        else if (size == 2)
        {

            if (facingright)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * 80f, ForceMode2D.Force);
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.left * 80f, ForceMode2D.Force);
            }


        }




    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponent<Entity>() != null)
        {

            if (size == 0)
            {
                other.gameObject.GetComponent<Entity>().TakeDamage(5f + GameObject.Find("Alephos").GetComponent<AlephosSpecific>().VoidPassive, GetComponent<Projectile>().ID);
                other.gameObject.GetComponent<Entity>().KnockBack(20f, this.gameObject);
            }
            else if (size == 1)
            {
                other.gameObject.GetComponent<Entity>().TakeDamage(10f + GameObject.Find("Alephos").GetComponent<AlephosSpecific>().VoidPassive, GetComponent<Projectile>().ID);
                other.gameObject.GetComponent<Entity>().KnockBack(20f, this.gameObject);
            }
            else if (size == 2)
            {
                other.gameObject.GetComponent<Entity>().TakeDamage(20f + GameObject.Find("Alephos").GetComponent<AlephosSpecific>().VoidPassive, GetComponent<Projectile>().ID);
                other.gameObject.GetComponent<Entity>().KnockBack(20f, this.gameObject);
            }

        }


        if (other.gameObject.GetComponent<Projectile>() != null)
        {


            Destroy(other.gameObject);
            GameObject.Find("Alephos").GetComponent<AlephosSpecific>().VoidPassive += 5;


        }
        else
        {

        }

    }


}
