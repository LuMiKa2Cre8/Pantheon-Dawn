using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float contactdamage;
    public float contactknockback;
    public float hurtframes = 10f;
    public float actualhurtframes;

    public GameObject Alephosmark;
    public GameObject AMarkCopy;
    public bool AlephosPassiveMarked;
    public float AlephosPassiveOnce = 0;



    void Start()
    {
        Alephosmark = Resources.Load("AlephosMark") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        HurtAppear();

        AlephosPassiveAether();

        if(GetComponent<Entity>().HP == 0)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<Entity>().TakeDamage(contactdamage, GetComponent<Entity>().Identification);
            collision.gameObject.GetComponent<Entity>().KnockBack(contactknockback, this.gameObject);


        }
    }

    public void DamageStarter(float damage)
    {
        if (AMarkCopy.gameObject == isActiveAndEnabled)
        {

            GetComponent<Entity>().HP -= damage;
            GetComponent<Entity>().HP -= damage;
            if (AMarkCopy.gameObject == isActiveAndEnabled)
            {
                Destroy(AMarkCopy);
            }

            GetComponent<Entity>().damagetobeshown = damage * 2;
        }

        else
        {
            GetComponent<Entity>().HP -= damage;

            GetComponent<Entity>().damagetobeshown = damage;
        }

        


        if (damage == 0)
        {

        }
        else
        {
            GetComponent<Entity>().DamageShow();

            actualhurtframes= hurtframes;
        }


    }

    void HurtAppear()
    {
        if (actualhurtframes > 0)
        {

            actualhurtframes -= (40 * Time.deltaTime);
            if (Mathf.Round(actualhurtframes) % 5 == 1)
            {
                this.GetComponent<SpriteRenderer>().color = Color.clear;

            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = Color.white;

            }



        }
        else
        {

        }



    }




    void AlephosPassiveAether()
    {
        if (GetComponent<SpriteRenderer>().isVisible)
        {
            AlephosPassiveMarked = true;
        }
        else 
        {
            AlephosPassiveMarked = false ;
            AlephosPassiveOnce = 0;
        }

        if (AlephosPassiveOnce == 0 && AlephosPassiveMarked == true)
        {
            AMarkCopy = Instantiate(Alephosmark, new Vector2 (GetComponent<Entity>().hpbar.transform.position.x, GetComponent<Entity>().hpbar.transform.position.y + 0.6f), Quaternion.identity, this.transform);
        }


        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>().WhoHitMe == GetComponent<Entity>().Identification)
        {
            if(AMarkCopy.gameObject == isActiveAndEnabled)
            {
                Destroy(AMarkCopy);
            }

        }


        if (AlephosPassiveMarked == true)
        {
            AlephosPassiveOnce += 1;
            if (AlephosPassiveOnce >= 3)
                AlephosPassiveOnce = 3;
            
        }
        else
        {
            Destroy(AMarkCopy);
        }
        




    }



}
