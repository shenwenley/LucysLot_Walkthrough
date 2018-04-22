using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float moveSpeed;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update () {
        Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if(moveDir.magnitude > 2)
        {
            moveDir = moveDir.normalized;
        }
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
	}
}
