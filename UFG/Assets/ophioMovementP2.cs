using UnityEngine;
using System.Collections;

public class ophioMovementP2 : MonoBehaviour
{
    Animator anim;
    public GameObject Me, Hattack, Lattack, Sattack, player2;
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


    public void HAttack()
    {
        
        Vector3 vecpos = transform.position;
        if (!flipped)
        {
            vecpos.x = vecpos.x - 0.4f;
            vecpos.y = vecpos.y + 0.3f;
        }
        if (flipped == true)
        {
            vecpos.x = vecpos.x + 0.4f;
            vecpos.y = vecpos.y + 0.3f;

        }
        GameObject hattack = Instantiate(Hattack, vecpos, Quaternion.identity);
        hattack.transform.parent = gameObject.transform;
        Hattack.layer = Me.layer;

        //attack.transform.localPosition = new Vector2(0.5f, 0);

    }
    public void LAttack()
    {
        
        Vector3 vecpos = transform.position;
        if (!flipped)
        {
            vecpos.x = vecpos.x - 0.5f;
            vecpos.y = vecpos.y + 0.4f;
        }
        if (flipped == true)
        {
            vecpos.x = vecpos.x + 0.5f;
            vecpos.y = vecpos.y + 0.4f;
        }
        GameObject lattack = Instantiate(Lattack, vecpos, Quaternion.identity);
        lattack.transform.parent = gameObject.transform;
        Lattack.layer = Me.layer;
        //attack.transform.localPosition = new Vector2(0.5f, 0);

    }
    public void SAttack()
    {
        
        Vector3 vecpos = transform.position;
        if (!flipped)
        {
            vecpos.x = vecpos.x - 1.5f;
            vecpos.y = vecpos.y + 0.2f;
        }
        if (flipped == true)
        {
            vecpos.x = vecpos.x + 1.5f;
            vecpos.y = vecpos.y + 0.2f;

        }
        GameObject sattack = Instantiate(Sattack, vecpos, Quaternion.identity);
        sattack.transform.parent = gameObject.transform;
        Sattack.layer = Me.layer;
        //attack.transform.localPosition = new Vector2(0.5f, 0);

    }


    public void Move(float horizontalInput)//takes input
    {



        Vector2 moveVel = rb2d.velocity;
        moveVel.x = horizontalInput * speed;//moving
        rb2d.velocity = moveVel;
        anim.SetFloat("Speed", moveVel.x);




    }

    public void Flip()
    {

        if (flipped == false)
        {
            if (myTrans.position.x - player2.transform.position.x < 0)
            {
                myTrans.Rotate(new Vector2(0, 180));
                flipped = true;
            }
        }
        else if (flipped == true)
        {
            if (myTrans.position.x - player2.transform.position.x > 1)
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
            anim.SetTrigger("Jump");
            Jump();



        }
        else if (Input.GetButtonUp("Jump1"))
        {
            anim.ResetTrigger("Jump");
        }
        if (Input.GetButtonDown("Heavy"))
        {
            anim.SetTrigger("HeavyAttack");

            HAttack();
        }


        if (Input.GetButtonUp("Heavy"))
        {
            anim.ResetTrigger("HeavyAttack");

        }
        if (Input.GetButtonDown("Light"))
        {
            anim.SetTrigger("LightAttack");

            LAttack();
        }
        if (Input.GetButtonUp("Light"))
        {
            anim.ResetTrigger("LightAttack");
        }
        if (Input.GetButtonDown("Special"))
        {
            anim.SetTrigger("SAttack");
            SAttack();
        }
        if (Input.GetButtonUp("Special"))
        {
            anim.ResetTrigger("SAttack");

        }


    }
}