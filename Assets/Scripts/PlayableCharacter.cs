using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter: MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject groundchecker;
    public float characterspeed = 40f;
    public float characterjumpstrength = 40f;
    public float characterjumpcancelstrength = 40f;
    public float fallingspeed = 40f;
    public float charfriction = 40f;
    public bool lockedcontrols = false;
    public bool fakefrictionon = true;
    public bool fakegravitygenerateron = true;
    public bool invincible = false;
    public bool selfprotect = false;
    public float invincibilityframes = 40f;
    public float actualinvincibilityframes;
    GameObject[] enemies;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        FakeGravityGenerator();




        Invincibility();

    }


    private void LateUpdate()
    {
        if (lockedcontrols == false)
        {
            Jump();
        }
        else
        {

        }
    }


    private void FixedUpdate()
    {
        if (lockedcontrols == false)
        {
            Run();
        }
        else
        {

        }




        if (fakefrictionon == true)
        {
            FakeFrictionGenerator();
        }
        else
        {
            rb.drag = 4;
        }




    }




    void Run()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (groundchecker.GetComponent<Groundcheck>().grounded == true)
                rb.AddForce(Vector3.right * characterspeed * 1.5f , ForceMode2D.Force);
            else
                rb.AddForce(Vector3.right * characterspeed, ForceMode2D.Force);

            GetComponent<Entity>().islooking_right = true;

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (groundchecker.GetComponent<Groundcheck>().grounded == true)
                rb.AddForce(Vector3.left * characterspeed * 1.5f, ForceMode2D.Force);
            else
                rb.AddForce(Vector3.left * characterspeed, ForceMode2D.Force);

            GetComponent<Entity>().islooking_right = false;
            
        }
        
        

    }

    void FakeFrictionGenerator()
    {
        if (groundchecker.GetComponent<Groundcheck>().grounded == true)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb.drag = 4;
            }
            else
            {
                rb.drag = 8;
            }
        }
        else
        {
            rb.drag = 4;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown (KeyCode.UpArrow) && groundchecker.GetComponent<Groundcheck>().grounded == true &&lockedcontrols ==false)
        {
            rb.AddForce(Vector3.up * characterjumpstrength * 40, ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.UpArrow) != true && rb.velocity.y > 0)
        {
            rb.AddForce(Vector3.down * rb.velocity.y * characterjumpcancelstrength / 15, ForceMode2D.Force);
        }


        



    }

    void FakeGravityGenerator()
    {
        if (rb.velocity.y < 0 && groundchecker.GetComponent<Groundcheck>().grounded == false)
        {
            rb.AddForce(Vector3.down * fallingspeed / 6, ForceMode2D.Force);
        }
    }


    public void DamageStarter(float damage)
    {
        GetComponent<Entity>().HP -= damage;
        if( damage == 0)
        {

        }
        else
        {
            actualinvincibilityframes = invincibilityframes;
            GetComponent<Entity>().damagetobeshown = damage;
            GetComponent<Entity>().DamageShow();
        }





    }

    void Invincibility()
    {
        if (actualinvincibilityframes > 0)
        {
            invincible = true;
            actualinvincibilityframes -= (40 * Time.deltaTime);
            if (Mathf.Round(actualinvincibilityframes) % 5 == 1)
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
            GetComponent<Entity>().WhoHitMe = 0;
            invincible = false;
        }


        enemies = GameObject.FindGameObjectsWithTag("Enemy");


        if (invincible == true)
        {

            foreach(GameObject enemy in enemies)
            {
                Physics2D.IgnoreCollision(enemy.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
            }
            
        }
        else
        {

            foreach (GameObject enemy in enemies)
            {
                Physics2D.IgnoreCollision(enemy.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
            }

        }



    }



    public void Uninvincible()
    {
        GetComponent<PlayableCharacter>().selfprotect = false;
    }
}
