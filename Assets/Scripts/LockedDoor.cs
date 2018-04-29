using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour {

    public AudioClip openDoor;
    private AudioSource source;

    public Texture2D cursorTexture;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    private Color startColor;
    public Color selected = new Color(1f, 0.686f, 0.686f, 1f);
    private SpriteRenderer renderer;
    private bool touching;
    private bool enter;

    public string levelName;
    public Vector2 loc;

    private void Start()
    {
        touching = false;
        renderer = GetComponent<SpriteRenderer>();
        startColor = renderer.material.color;
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && touching && enter)
        {
            StaticPosition.location = loc;
            source.PlayOneShot(openDoor, 1);
            //SceneManager.LoadScene(levelName);
        }
    }

    private void OnMouseEnter()
    {
        enter = true;
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    private void OnMouseExit()
    {
        enter = false;
        Cursor.SetCursor(null, hotSpot, cursorMode);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("enter player");
            renderer.material.color = selected;
            touching = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("exit player");
            renderer.material.color = startColor;
            touching = false;
        }
    }
}