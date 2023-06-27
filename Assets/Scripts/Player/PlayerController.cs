using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   //public static Transform playerTransform;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator Anim;
    //Movement Variables
    public float speed = 5.0f;
    public float jumpForce = 300.0f;

    //Groundcheck Stuff
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask isGroundLayer;
    public float groundCheckRadius = 0.02f;

    Coroutine speedChange = null;

    // Start is called before the first frame update
    void Start()
    {
        //playerTransform = transform;

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();

        if (speed <= 0) speed = 5.0f;
        if (jumpForce <= 0) jumpForce = 340.0f;
        if (groundCheckRadius <= 0) groundCheckRadius = 0.02f;

        if (!groundCheck) groundCheck = GameObject.FindGameObjectWithTag("GroundCheck").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] curPlayingClips = Anim.GetCurrentAnimatorClipInfo(0);

        float hInput = Input.GetAxisRaw("Horizontal");
            
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

        if (isGrounded)
            rb.gravityScale = 1;

        if (curPlayingClips.Length > 0)
        {
            if (Input.GetButtonDown("Fire1") && curPlayingClips[0].clip.name != "Fire")
                Anim.SetTrigger("Fire");
            else if (curPlayingClips[0].clip.name == "Fire")
                rb.velocity = Vector2.zero;
            else
            {
                Vector2 moveDirection = new Vector2(hInput * speed, rb.velocity.y);
                rb.velocity = moveDirection;
            }

        }

        if (isGrounded && Input.GetButtonDown("Jump1"))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
        }


        //if (isGrounded && Input.GetButtonDown("Down1"))
            //Anim.SetTrigger("Down");


        if (isGrounded && Input.GetButtonDown("Run/Gun"))
            Anim.SetTrigger("RunGun");


        Anim.SetFloat("hInput", Mathf.Abs(hInput));
        Anim.SetBool("isGrounded", isGrounded);

        if (hInput != 0)
            sr.flipX = (hInput < 0);


    }

    public void StartSpeedChange()
    {
        Debug.Log("You are speed");
        if (speedChange == null)
        {
            speedChange = StartCoroutine(SpeedChange());
            return;
        }
        StopCoroutine(speedChange);
        speedChange = null;
        speed /= 2;
        StartSpeedChange();
    }

    IEnumerator SpeedChange()
    {
        speed *= 2;

        yield return new WaitForSeconds(5.0f);

        speed /= 2;

        speedChange = null;
    }

   
}
