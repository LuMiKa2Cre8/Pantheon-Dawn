using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    GameObject Alephos;
    public bool isAlephosDead = false;
    public bool hasAnimPlayed = false;
    public float animDuration = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Alephos = GameObject.Find("Alephos");
    }

    // Update is called once per frame
    void Update()
    {
        CheckAlephosHP();
        if (isAlephosDead && !hasAnimPlayed)
        {
            PlayerDie();
        }
    }

    void CheckAlephosHP()
    {
        if (Alephos.GetComponent<Entity>().HP == 0)
        {
            isAlephosDead = true;
        }
    }

    void PlayerDie()
    {
        GetComponent<Animator>().Play("DeathFade");
        while (animDuration > 0)
        {
            animDuration -= Time.deltaTime;
        }

        if (animDuration <= 0)
        {
            animDuration = 1.0f;
            isAlephosDead = false;
        }
    }

    public void AnimationDone()
    {
        hasAnimPlayed = true;
    }
}
