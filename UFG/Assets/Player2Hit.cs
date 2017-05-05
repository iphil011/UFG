using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Hit : MonoBehaviour
{
    Animator anim;

    public bool flipped = false;
    Transform myTrans;
    public GameObject LeftEffect;
    public GameObject RightEffect;
    public GameObject player2;
    // Use this for initialization
    void Start()
    {
        myTrans = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();

    }
    public void Flip()
    {

        if (flipped == false)
        {
            if (myTrans.position.x - player2.transform.position.x > 1)
            {

                flipped = true;
            }
        }
        else if (flipped == true)
        {
            if (myTrans.position.x - player2.transform.position.x < 0)
            {
                flipped = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack1P2")
        {
            if (flipped == true)
            {
                Instantiate(RightEffect, myTrans.position, Quaternion.identity);
                anim.SetTrigger("Hit");
                Vector3 up = new Vector2(0.5f, 0.5f);
                transform.position += up;
            }
            else if (flipped == false)
            {
                Instantiate(LeftEffect, myTrans.position, Quaternion.identity);

                anim.SetTrigger("Hit");

                Vector3 up = new Vector2(-0.5f, 0.5f);
                transform.position += up;


            }
        }
        if (collision.gameObject.tag == "Attack2P2")
        {
            if (flipped == true)
            {
                Instantiate(RightEffect, myTrans.position, Quaternion.identity);
                anim.SetTrigger("Hit");

                Vector3 up = new Vector2(0.2f, 0.2f);
                transform.position += up;
            }
            else if (flipped == false)
            {
                Instantiate(LeftEffect, myTrans.position, Quaternion.identity);

                Vector3 up = new Vector2(-0.2f, 0.2f);
                transform.position += up;
            }
        }
        if (collision.gameObject.tag == "Attack3P2")
        {
            if (flipped == true)
            {
                Instantiate(RightEffect, myTrans.position, Quaternion.identity);
                anim.SetTrigger("Hit");

                Vector3 up = new Vector2(1.5f, 1.5f);
                transform.position += up;
            }
            else if (flipped == false)
            {
                Instantiate(LeftEffect, myTrans.position, Quaternion.identity);

                anim.SetTrigger("Hit");

                Vector3 up = new Vector2(-1.5f, 1.5f);
                transform.position += up;
            }
        }

    }
}
  
		
