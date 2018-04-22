using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour {

    public string message;

    private Color startColor;
    private SpriteRenderer renderer;

    private void Start() {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        
    }

    void OnMouseEnter() {
        startColor = renderer.material.color;
        renderer.material.color = Color.red;
    }

    void OnMouseExit() {
        renderer.material.color = startColor;
    }
}
