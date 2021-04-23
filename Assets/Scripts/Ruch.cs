using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruch : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    float kierunekRuchuLP;
    float predkoscRuchuLP = 7f;
    bool czyJestWTrakcieSkoku;
    bool czyMozeSkoczyc;
    float silaSkoku = 70f;
    void Start()
    {
        czyMozeSkoczyc = true;
        czyJestWTrakcieSkoku = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        kierunekRuchuLP = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            czyJestWTrakcieSkoku = true;
        }
        ObracajGracza();
        Animuj();
    }

    void FixedUpdate()
    {
        RuszajSie();
        Skocz();
    }

    void RuszajSie()
    {
        rb.velocity = new Vector2(kierunekRuchuLP * predkoscRuchuLP, rb.velocity.y);
    }

    void Skocz()
    {
        if (czyJestWTrakcieSkoku)
        {
            if (czyMozeSkoczyc)
            {
                rb.AddForce(new Vector3(0, silaSkoku, 0), ForceMode2D.Impulse);
                czyJestWTrakcieSkoku = false;
                czyMozeSkoczyc = false;
            }
        }
    }

    void ObracajGracza()
    {
        if(kierunekRuchuLP >= 0)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
    }

    void Animuj()
    {
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetTrigger("Shoot");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if( collision.gameObject.CompareTag("Ground")){
            czyMozeSkoczyc = true;
        }
    }
}
