using UnityEngine;
using System.Collections;

public class Player2Movement : MonoBehaviour
{
    Animator anim;
    int jumpHash = Animator.StringToHash("Jump");
    public GameObject Hattack, Lattack, Sattack, player2;
    public float speed;             //Floating point variable to store the player's movement speed.
    public float jumpforce;
    public bool flipped = false;
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
        anim = GetComponent<Animator>();
    }


    public void Jump()
    {

        anim.SetFloat("Speed", Input.GetAxis("Vertical1"));
        if (isGround)
        {
           
            rb2d.velocity = jumpforce * Vector2.up;//jumping

           
        }
        }


    public void HAttack() {
        Instantiate(Hattack, transform.position, Quaternion.identity);
        //attack.transform.localPosition = new Vector2(0.5f, 0);

    }
    public void LAttack()
    {
        Instantiate(Lattack, transform.position, Quaternion.identity);
        //attack.transform.localPosition = new Vector2(0.5f, 0);

    }
    public void SAttack()
    {
        Instantiate(Sattack, transform.position, Quaternion.identity);
        //attack.transform.localPosition = new Vector2(0.5f, 0);

    }


    public void Move(float horizontalInput)//takes input
    {



        Vector2 moveVel = rb2d.velocity;
        moveVel.x = horizontalInput * speed;//moving
        rb2d.velocity = moveVel;




    }

    public void Flip()
    {

        if (flipped == false)
        {
            if (myTrans.position.x - player2.transform.position.x > 1)
            {
                myTrans.Rotate(new Vector2(0, 180));
                flipped = true;
            }
        }
        else if (flipped == true)
        {
            if (myTrans.position.x - player2.transform.position.x < 0)
            {
                myTrans.Rotate(new Vector2(0, 180));
                flipped = false;
            }
        }
    }
    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {

        Flip();
     
        isGround = Physics2D.Linecast(myTrans.position, tagGround.position, playerMask);//checks if hit ground

        Move(Input.GetAxisRaw("Horizontal1"));//moving
        if (Input.GetButtonDown("Jump1"))//jumping
        {
            anim.SetTrigger(jumpHash);
            Jump();
           
        }
        else if (Input.GetButtonUp("Jump1"))
        {
            anim.ResetTrigger(jumpHash);
        }
        if (Input.GetButtonDown("Heavy"))
        {
            HAttack();
        }
        if (Input.GetButtonDown("Light"))
        {
            LAttack();
        }
        if (Input.GetButtonDown("Special"))
        {
            SAttack();
        }
        

    }
}