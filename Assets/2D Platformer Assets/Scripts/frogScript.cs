using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogScript : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    private int  direction = 1;
    private Vector3 startPos;
    public float moveLength = 5f;
    private bool isTouchingGround;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public Animator anim;
    public SpriteRenderer theSR;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        
        
            
            transform.position += new Vector3(moveSpeed * Time.deltaTime * direction, jumpForce, 0f);
    
            if (transform.position.x >= startPos.x + moveLength)
            {
                direction = -1;
            }
            else if (transform.position.x <= startPos.x - moveLength)
            {
                direction = 1;
            }

            if(direction == 1)
            {
                theSR.flipX = true;
            }
            else if(direction == -1)
            {
                theSR.flipX = false;
            }

            

            anim.SetBool("isRight",direction == 1);

    }


    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerHealController.instance.TakeDamage();
        }
    }
}
