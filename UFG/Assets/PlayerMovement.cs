using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    int jumpHash = Animator.StringToHash("Jump");
    public GameObject Hattack, Lattack, Sattack;
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
        anim = GetComponent<Animator>();
    }


    public void Jump()
    {

        anim.SetFloat("Speed", Input.GetAxis("Vertical"));
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
    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {

     
        isGround = Physics2D.Linecast(myTrans.position, tagGround.position, playerMask);//checks if hit ground

        Move(Input.GetAxisRaw("Horizontal"));//moving
        if (Input.GetButtonDown("Jump"))//jumping
        {
            anim.SetTrigger(jumpHash);
            Jump();
           
        }
        else if (Input.GetButtonUp("Jump"))
        {
            anim.ResetTrigger(jumpHash);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            HAttack();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            LAttack();
        }
        if (Input.GetButtonDown("Fire3"))
        {
            SAttack();
        }
        

    }
}