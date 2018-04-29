using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectObjectNoMessage : MonoBehaviour {

    private Color startColor;
    private SpriteRenderer renderer;
    private bool touching;

    public string levelName;
    public Vector2 loc;

    private void Start() {
        touching = false;
        renderer = GetComponent<SpriteRenderer>();
        startColor = renderer.material.color;
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0) && touching) {
            StaticPosition.location = loc;
            SceneManager.LoadScene(levelName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            Debug.Log("enter player");
            renderer.material.color = Color.red;
            touching = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        Debug.Log("exit");
        if(collision.gameObject.CompareTag("Player")) {
            Debug.Log("exit player");
            renderer.material.color = startColor;
            touching = false;
        }
    }
}
