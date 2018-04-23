using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipText : MonoBehaviour {

    public float maxTime = 3f;

    private float timer;

    private GameObject sizeText;

    private void Start()
    {
        sizeText = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= maxTime)
        {
            Destroy(gameObject);
        }
    }

    public void SetText(string message)
    {
        if(sizeText == null)
        {
            sizeText = transform.GetChild(0).gameObject;
        }
        sizeText.GetComponent<Text>().text = message;
        sizeText.transform.GetChild(1).GetComponent<Text>().text = message;
    }

}
