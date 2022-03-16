using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlephosMeleeinfo : MonoBehaviour
{
    public int attacktype;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponent<Entity>() != null)
        {
            GameObject.Find("Alephos").GetComponent<PlayableCharacter>().selfprotect = true;


            if(attacktype == 0)
            {
                other.gameObject.GetComponent<Entity>().TakeDamage(20f + transform.parent.parent.GetComponent<AlephosSpecific>().VoidPassive, transform.parent.parent.GetComponent<Entity>().Identification);
                other.gameObject.GetComponent<Entity>().KnockBack(20f, this.gameObject);
            }
            else if (attacktype == 1)
            {
                other.gameObject.GetComponent<Entity>().TakeDamage(10f + transform.parent.parent.GetComponent<AlephosSpecific>().VoidPassive, transform.parent.parent.GetComponent<Entity>().Identification);
                other.gameObject.GetComponent<Entity>().KnockBack(20f, this.gameObject);
            }
            else if (attacktype == 2)
            {
                other.gameObject.GetComponent<Entity>().TakeDamage(2.5f + transform.parent.parent.GetComponent<AlephosSpecific>().VoidPassive, transform.parent.parent.GetComponent<Entity>().Identification);
                other.gameObject.GetComponent<Entity>().KnockBack(40f, this.gameObject);
                other.gameObject.GetComponent<Entity>().VerticalKnockBack(40f, this.gameObject);
            }
            else if (attacktype == 3)
            {
                other.gameObject.GetComponent<Entity>().TakeDamage((2.5f * transform.parent.parent.GetComponent<AlephosSpecific>().PeakCharges) + transform.parent.parent.GetComponent<AlephosSpecific>().VoidPassive, transform.parent.parent.GetComponent<Entity>().Identification);
                other.gameObject.GetComponent<Entity>().KnockBack(10f, this.gameObject);
            }



        }
        else
        {

        }


        if (other.gameObject.GetComponent<Projectile>() != null)
        {

            GameObject.Find("Alephos").GetComponent<PlayableCharacter>().selfprotect = true;
            Destroy(other.gameObject);
            transform.parent.parent.GetComponent<AlephosSpecific>().VoidPassive += 5;


        }
        else
        {

        }



    }




}
