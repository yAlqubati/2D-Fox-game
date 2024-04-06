using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : MonoBehaviour
{
    // config parameters
    public float moveSpeed;
    public float distance;
    public int direction = 1;
    private Vector3 startPos;
    public Animator anim;
    public SpriteRenderer theSR;

    private bool isTouchingGround;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool wallCheck;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        checkWallAndGround();
        transform.position += new Vector3(moveSpeed * Time.deltaTime * direction, 0f, 0f);
    
        if(transform.position.x >= startPos.x + distance)
        {
            if(wallCheck)
            {
                
            }
            direction = -1;
        }
        else if(transform.position.x <= startPos.x - distance)
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

    public void checkWallAndGround()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        wallCheck = Physics2D.Raycast(transform.position, new Vector2(direction, 0f), 0.5f, groundLayer);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealController.instance.TakeDamage();
            AudioManager.instance.effectToPlay(9);
        }
    }
}
