using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float moveSpeed;

    private Animator animator;
    private bool facingRight = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);

        Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (moveDir.magnitude != 0)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        if (moveDir.magnitude > 2)
        {
            moveDir = moveDir.normalized;
        }

        if(moveDir.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveDir.x < 0 && facingRight)
        {
            Flip();
        }

        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
    }
}
