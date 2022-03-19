using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    public float HP;
    public float MaxHP;
    public bool islooking_right;
    public GameObject hpbar;
    public float damage_reduction;

    public float Identification;
    public float WhoHitMe;
    public float damagetobeshown;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this flips sprite if face right

        if (islooking_right == true)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }


        //this makes it so 0 is 0
        if (HP <=0 )
        {
            HP = 0;
        }



    }


    private void LateUpdate()
    {
        //healthbar stuff

        hpbar.transform.localScale = new Vector2((HP / MaxHP) + 0.01f, 0.1f);

        if (HP == 0)
        {
            hpbar.GetComponent<SpriteRenderer>().color = Color.clear;
        }
    }



    void PushDirectionFace(float AmountofForce, ForceMode2D howtopush)
    {
        //if an enemy/player should push themselves use this


        if(islooking_right == true)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right*AmountofForce, howtopush);
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left* AmountofForce, howtopush);
        }
    }



    public void TakeDamage(float damage, float ID)
    {
        //this allows things to take damage and figure out who hit them

        if (this.tag == "Player" && this.GetComponent<PlayableCharacter>().invincible == false && this.GetComponent<PlayableCharacter>().selfprotect == false)
        {

            WhoHitMe = ID;
            GetComponent<PlayableCharacter>().DamageStarter(damage * damage_reduction);







        }
        else if (this.tag == "Enemy")
        {
            GetComponent<Enemy>().DamageStarter(damage * damage_reduction);



        }




    }


    public void DamageShow()
    {
        //this causes the damage numbers to show up

        GameObject damagepopup;
        damagepopup = Resources.Load("DamageTextLocation") as GameObject;

        GameObject newdamagepopup = Instantiate(damagepopup, this.transform.position, Quaternion.identity, GameObject.Find("DamageNumbers").transform);
        newdamagepopup.transform.GetChild(0).GetComponent<Text>().text = "" +damagetobeshown;

        Destroy(newdamagepopup.gameObject, 1f);
    }







    public void KnockBack(float knockback, GameObject commiter)
    {
        //self explanatory
        if (this.transform.position.x > commiter.gameObject.transform.position.x)
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * knockback, ForceMode2D.Impulse);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.left * knockback, ForceMode2D.Impulse);
        }






    }

    public void VerticalKnockBack(float knockback, GameObject commiter)
    {
        //2+2=4
        if (this.transform.position.y > commiter.gameObject.transform.position.y)
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * knockback, ForceMode2D.Impulse);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.down * knockback, ForceMode2D.Impulse);
        }
    }


}
