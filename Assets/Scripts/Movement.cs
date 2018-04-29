using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float moveSpeed;

    private Animator animator;
    private bool facingRight = false;
    private Rigidbody2D rb;

    private void Start()
    {
        Vector2 pos = StaticPosition.location;
        transform.position = pos;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);

        Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (moveDir.y > 0)
        {
            animator.SetBool("FacingBack", true);
        }
        else if (moveDir.y < 0)
        {
            animator.SetBool("FacingBack", false);
        }

        if (moveDir.magnitude != 0)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }        

        if(moveDir.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveDir.x < 0 && facingRight)
        {
            Flip();
        }

        if (moveDir.magnitude > 2)
        {
            moveDir = moveDir.normalized;
        }

        rb.velocity = moveSpeed * moveDir;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
    }
}
