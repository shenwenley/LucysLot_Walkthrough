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

    public Texture2D cursorTexture;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

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
        renderer.material.color = new Color(1f, 0.686f, 0.686f,1f);
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void OnMouseExit() {
        renderer.material.color = startColor;
        Cursor.SetCursor(null, hotSpot, cursorMode);
    }
}
