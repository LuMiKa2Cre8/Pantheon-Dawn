using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlephosSpecific : MonoBehaviour
{
    Animator AlephAnimator;
    public bool InPrimary;
    public bool InSecondary;
    public bool InSecondaryDash;
    public bool InSecondaryDashDrain;
    public bool InSecondarySlash;
    public bool InSecondaryEvoke;

    public float SecondaryCharge = 0;
    public float PeakCharges = 0;
    public float SecondaryTimer = 0;

    public bool SelfAbilityLock;

    public GameObject SecondaryProjectileSource;

    public GameObject SecondaryProjectile;

    public float VoidPassive = 0;


    int PrimaryState = 1;

    void Start()
    {
        AlephAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AttackInformation();
        AlephosPrimary();
        AlephosSecondary();
        OnGettingHit();
        
        if (InPrimary == false && InSecondary == false && InSecondaryDash == false && InSecondarySlash == false && InSecondaryEvoke == false)
        {
            AnimationPlayingAlephos();
        }

        VoidPassiveIndicator();



    }


    private void FixedUpdate()
    {

        if (InPrimary == false && InSecondary == false && InSecondaryDash == false && InSecondarySlash == false && InSecondaryEvoke == false)
        {

            GetComponent<Rigidbody2D>().gravityScale = 4f;
            GetComponent<Entity>().damage_reduction = 1;

        }
        else if (InPrimary == true)
        {


            if (PrimaryState == 1)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0.0f);


            }
            else if (PrimaryState == 2)
            {

            }
            else if (PrimaryState == 3)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y * 0.0f);


            }

            

        }
        else if (InSecondary == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x * 0.87f, GetComponent<Rigidbody2D>().velocity.y * 0.93f);
            GetComponent<Rigidbody2D>().gravityScale = 1.2f;
        }
        else if (InSecondaryDash == true)
        {
            PushDirectionFace(170f, ForceMode2D.Force);
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 15f, ForceMode2D.Force);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
            GetComponent<Entity>().damage_reduction = ((10-PeakCharges) / 10);

        }
        else if (InSecondarySlash == true)
        {
            PushDirectionFace(-30f, ForceMode2D.Force);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x * 0.5f, GetComponent<Rigidbody2D>().velocity.y * 0.0f);

        }
        else if (InSecondaryEvoke == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y * 0.0f);
        }
    }

    void AnimationPlayingAlephos()
    {
        if (GetComponent<PlayableCharacter>().groundchecker.GetComponent<Groundcheck>().grounded == false)
        {
            if (GetComponent<Rigidbody2D>().velocity.y > 0)
            {
                AlephAnimator.Play("Alephos Jump Up");
            }
            else
            {
                AlephAnimator.Play("Alephos Jump Down");
            }

        }

        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            AlephAnimator.Play("Alephos Running");
        }
        else
        {
            AlephAnimator.Play("Alephos Idle");
        }
    }

    void AlephosPrimary()
    {
        if (Input.GetKey(KeyCode.Q) && SelfAbilityLock == false && Input.GetKey(KeyCode.W) == false)
        {


            if (PrimaryState == 1)
            {
                AlephAnimator.Play("Alephos Primary Stab");

            }
            else if (PrimaryState == 2)
            {
                AlephAnimator.Play("Alephos Primary Overhead");

            }
            else if (PrimaryState == 3)
            {
                AlephAnimator.Play("Alephos Primary Sweep");

            }

            if (PrimaryState == 1)
            {
                GameObject.Find("QPI2").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("QPI3").GetComponent<SpriteRenderer>().enabled = false;

            }
            else if (PrimaryState == 2)
            {
                GameObject.Find("QPI2").GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (PrimaryState == 3)
            {
                GameObject.Find("QPI3").GetComponent<SpriteRenderer>().enabled = true;


            }
        }
    }

    void GoNext1()
    {
        PrimaryState = 2;
    }

    void GoNext2()
    {
        PrimaryState = 3;
    }

    void GoNext3()
    {
        PrimaryState = 1;
    }

    void StabDash()
    {
        PushDirectionFace(30f, ForceMode2D.Impulse);
    }

    void Overhead1()
    {
        PushDirectionFace(15f, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 16f, ForceMode2D.Impulse);
    }

    void Overhead2()
    {
        PushDirectionFace(15f, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().AddForce(Vector2.down * 25f, ForceMode2D.Impulse);
    }


    void Sweep()
    {
        PushDirectionFace(15f, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 6f, ForceMode2D.Impulse);
    }



    void WhyDoIHaveToDoThis()
    {
        InSecondary = true;
    }

    void Evoke()
    {
        PushDirectionFace(-5f, ForceMode2D.Impulse);


        if(PeakCharges <= 6)
        {
            SecondaryProjectile.GetComponent<AlephosProjectile>().size = 0;
        }
        else if (PeakCharges <= 9)
        {
            SecondaryProjectile.GetComponent<AlephosProjectile>().size = 1;
        }
        else
        {
            SecondaryProjectile.GetComponent<AlephosProjectile>().size = 2;
        }

        SecondaryProjectile.GetComponent<Projectile>().ID = GetComponent<Entity>().Identification;


        if (GetComponent<Entity>().islooking_right)
        {
            SecondaryProjectileSource.transform.localPosition = new Vector2(0.5f, -0.177548885f);
            SecondaryProjectile.GetComponent<SpriteRenderer>().flipX = false;

            SecondaryProjectile.GetComponent<AlephosProjectile>().facingright = true;
            Instantiate(SecondaryProjectile, SecondaryProjectileSource.transform.position, Quaternion.identity);

        }
        else
        {
            SecondaryProjectileSource.transform.localPosition = new Vector2(-0.5f, -0.177548885f);
            SecondaryProjectile.GetComponent<SpriteRenderer>().flipX = true;
            SecondaryProjectile.GetComponent<AlephosProjectile>().facingright = false;
            Instantiate(SecondaryProjectile, SecondaryProjectileSource.transform.position, Quaternion.identity);

        }

        
    }


    void PushDirectionFace(float AmountofForce, ForceMode2D howtopush)
    {
        if (GetComponent<Entity>().islooking_right == true)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * AmountofForce, howtopush);
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * AmountofForce, howtopush);
        }
    }



    void AlephosSecondary()
    {
        GameObject.Find("WChargeIndicator").transform.localScale = new Vector2(135.3136f * (SecondaryCharge / 10f), 13.53136f);
        GameObject.Find("WCooldownIndicator").GetComponent<SpriteRenderer>().color = new Color(0,0,0, ((10-SecondaryCharge)/10 * 208 / 255f));


        if (Input.GetKey(KeyCode.W) && SelfAbilityLock == false)
        {
            SecondaryTimer += Time.deltaTime;
            if(SecondaryTimer >= 0.1f && SecondaryCharge < 10)
            {
                SecondaryCharge += 1;
                SecondaryTimer = 0;

              


            }

            InSecondary = true;
        }
        else
        {
            
        }

        if(Input.GetKeyUp(KeyCode.W) && InSecondaryDashDrain != true)
        {
            PeakCharges = SecondaryCharge;
            InSecondaryDashDrain = true;
        }



        if (SecondaryCharge > 0 && Input.GetKey(KeyCode.W) == true && Input.GetKey(KeyCode.Q) == true && SecondaryCharge > 5)
        {
            InSecondaryEvoke = true;
            PeakCharges = SecondaryCharge;
            SecondaryCharge = 0;
            SecondaryTimer = 0;
        }


        if (SecondaryCharge > 0 && InSecondaryDashDrain == true)
        {
            InSecondary = false;

            

            SecondaryTimer += Time.deltaTime;
            if (SecondaryTimer >= 0.05f)
            {
                SecondaryCharge -= 1;
                SecondaryTimer = 0;
                print(SecondaryCharge);
            }
            
            if (PeakCharges >= 5)
            {
                if (InSecondary == false && SecondaryCharge > 0)
                {
                    InSecondaryDash = true;

                }
                else
                {
                    InSecondaryDash = false;


                    InSecondarySlash = true;
                    InSecondaryDashDrain = false;

                }

            }



        }
        else if(SecondaryCharge ==0 && Input.GetKey(KeyCode.W) == false)
        {
            InSecondary = false;
            InSecondaryDashDrain = false;
        }



        if (SecondaryCharge >= 10)
        {
            SecondaryCharge = 10;
        }
        else if (SecondaryCharge <= 0)
        {
            SecondaryCharge = 0;
        }



        if (InSecondary == true)
        {
            if (GetComponent<PlayableCharacter>().groundchecker.GetComponent<Groundcheck>().grounded == false)
            {
                if (GetComponent<Rigidbody2D>().velocity.y > 0)
                {
                    AlephAnimator.Play("Alephos Secondary Jump Up");
                }
                else
                {
                    AlephAnimator.Play("Alephos Secondary Jump Down");
                }

            }

            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                AlephAnimator.Play("Alephos Secondary Running");
            }
            else
            {
                AlephAnimator.Play("Alephos Secondary Idle");
            }




        }

        if (InSecondaryDash == true)
        {
            AlephAnimator.Play("Alephos Secondary Dash");
        }
        else if (InSecondarySlash == true)
        {
            AlephAnimator.Play("Alephos Secondary Slash");
        }
        else if (InSecondaryEvoke == true)
        {
            AlephAnimator.Play("Alephos Secondary Evoke");
        }    


        else
        {
            GetComponent<PlayableCharacter>().lockedcontrols = false;
            GetComponent<PlayableCharacter>().fakefrictionon = true;
        }





    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" )
        {



            if(SecondaryCharge > 0 )
            {
                if (InSecondaryDash == true)
                {
                    SecondaryCharge = 0;

                    InSecondaryDash = false;
                    InSecondarySlash = true;

                    
                }
                else
                {

                }


                
            }






        }
    }


    public void OnGettingHit()
    {
        if(GetComponent<PlayableCharacter>().actualinvincibilityframes >0)
        {

            VoidPassive = 0;



        }
    }



    public void AttackInformation()
    {
        if(GetComponent<Entity>().islooking_right)
        {
            GameObject.Find("AlephosSwivel").transform.rotation = Quaternion.AngleAxis(0f, Vector3.up);
        }
        else
        {
            GameObject.Find("AlephosSwivel").transform.rotation = Quaternion.AngleAxis(180f, Vector3.up);
        }





    }



    public void VoidPassiveIndicator()
    {
        GameObject.Find("VoidIndicator").transform.Rotate(Vector3.forward, -VoidPassive/73f);


    }








}
