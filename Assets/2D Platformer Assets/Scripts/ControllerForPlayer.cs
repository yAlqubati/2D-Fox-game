using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerForPlayer : MonoBehaviour
{
    // necessary variables
    public static ControllerForPlayer instance;
    public Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public SpriteRenderer spriterenderer;
    bool isTouchingGround;
    bool oneMoreJump;
    // here is the layer mask for the ground
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError("Animator component not found!");
        }
    }


    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        // here to if the player is touching the ground
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if(isTouchingGround){
            oneMoreJump = true;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            if(isTouchingGround){
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                AudioManager.instance.effectToPlay(10);
            }

            else if(oneMoreJump){
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                oneMoreJump = false;
                AudioManager.instance.effectToPlay(10);
            }
        }

        if(rb.velocity.x > 0){
            spriterenderer.flipX = false;
        }
        else if(rb.velocity.x < 0){
            spriterenderer.flipX = true;
        }
        
        anim.SetFloat("playerSpeed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("IsTouchingGround", isTouchingGround);
        
        
    }

    public void KnockBack()
    {
        rb.velocity = new Vector2(-10f, 10f);
        anim.SetTrigger("DamageHappened");
    }
}
