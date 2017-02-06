using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float speed;             //Floating point variable to store the player's movement speed.
    public float jumpforce;
    Transform myTrans, tagGround;
    public LayerMask playerMask;
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    public bool isGround = false;
    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        myTrans = GetComponent<Transform>();
        tagGround = GameObject.Find(this.name + "/tag_Ground").transform;
    }


    public void Jump()
    {
        if (isGround)
        {
            rb2d.velocity = jumpforce * Vector2.up;//jumping
        }
        }


    public void Move(float horizontalInput)//takes input
    {



        Vector2 moveVel = rb2d.velocity;
        moveVel.x = horizontalInput * speed;//moving
        rb2d.velocity = moveVel;




    }
    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {

        isGround = Physics2D.Linecast(myTrans.position, tagGround.position, playerMask);//checks if hit ground

        Move(Input.GetAxisRaw("Horizontal"));//moving
        if (Input.GetButtonDown("Jump"))//jumping
        {
            Jump();
        }
    }
}