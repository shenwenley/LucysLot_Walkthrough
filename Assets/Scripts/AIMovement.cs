using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour {

    public float moveSpeed;

    private float xDir;
    private float yDir;

    private Animator animator;

    private void Start() {
        Random.InitState((int)System.DateTime.Now.Ticks);
        animator = GetComponent<Animator>();
        xDir = Random.Range(-1, 1);
        yDir = Random.Range(-1, 1);
        float t = Random.Range(.1f, 1);
        Invoke("changeDirection", t);

    }

    private void changeDirection() {
        float stop = Random.Range(0, 100);
        if(stop < 25) {
            xDir = 0;
            yDir = 0;
            animator.speed = 0;
        }
        else {
            xDir = Random.Range(-1.0f, 1.0f);
            yDir = Random.Range(-1.0f, 1.0f);
            animator.speed = 1;
        }
        float t = Random.Range(.1f, 1);
        Invoke("changeDirection", t);
    }

    void Update() {
        Vector2 moveDir = new Vector2(xDir, yDir);
        if(moveDir.magnitude > 2) {
            moveDir = moveDir.normalized;
        }
        transform.localScale = new Vector3(Mathf.Sign(xDir), 1, 1);
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }
}
