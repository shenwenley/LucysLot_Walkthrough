using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float moveSpeed;
    public AudioClip walkSound;
    private AudioSource source;

    private Animator animator;
    private bool facingRight = false;
    private Rigidbody2D rb;
   

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
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
            if (!source.isPlaying)
            {
                source.PlayOneShot(walkSound, 1);
            }
        }
        else
        {
            animator.SetBool("IsMoving", false);
            source.Stop();
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
