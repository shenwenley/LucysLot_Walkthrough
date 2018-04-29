using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectObject : MonoBehaviour {

    [TextArea(5, 10)]
    public string message = "This is the typed test message";

    private Color startColor;
    private SpriteRenderer renderer;
    private GameObject canvas;

    private void Start() {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        TooltipManager.Instance.CreateTooltip(message, mousePos);
    }

    void OnMouseEnter() {
        startColor = renderer.material.color;
        renderer.material.color = Color.red;
    }

    void OnMouseExit() {
        renderer.material.color = startColor;
    }
}
