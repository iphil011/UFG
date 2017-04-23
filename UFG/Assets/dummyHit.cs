using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummyHit : MonoBehaviour {
    public bool flipped = false;
    Transform myTrans;
    public GameObject player2;
    public GameObject LeftEffect;
    public GameObject RightEffect;
    // Use this for initialization
    void Start () {
        myTrans = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update () {
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
        if (collision.gameObject.tag == "Attack1") {
            if (flipped ==true)
            {
                Instantiate(LeftEffect, myTrans.position, Quaternion.identity);
                Vector3 up = new Vector2(0.3f, 0.4f);
                transform.position += up;
            }
            else if (flipped==false)
            {
                Instantiate(RightEffect, myTrans.position, Quaternion.identity);

                Vector3 up = new Vector2(-0.3f, 0.4f);
                transform.position += up;


            }
        }
        if (collision.gameObject.tag == "Attack2")
        {
            if (flipped == true)
            {
                Instantiate(LeftEffect, myTrans.position, Quaternion.identity);
                Vector3 up = new Vector2(0.4f, 0.1f);
                transform.position += up;
            }
            else if (flipped == false)
            {
                Instantiate(RightEffect, myTrans.position, Quaternion.identity);

                Vector3 up = new Vector2(-0.4f, 0.1f);
                transform.position += up;
            }
            }
        if (collision.gameObject.tag == "Attack3")
        {
            if (flipped == true)
            {
                Vector3 up = new Vector2(1.5f, 1.5f);
                transform.position += up;
            }
            else if (flipped == false)
            {
                Vector3 up = new Vector2(-1.5f, 1.5f);
                transform.position += up;
            }
        }

    }
}
