using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipManager : MonoBehaviour {

    public static TooltipManager Instance;
    public GameObject canvasPrefab;
    public float yOffset;

    private GameObject canvas;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(Instance.gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public void CreateTooltip(string message, Vector3 position)
    {
        position = new Vector3(position.x, position.y + yOffset, 0);
        canvas = Instantiate(canvasPrefab, position, canvasPrefab.transform.rotation);
        canvas.GetComponent<TooltipText>().SetText(message);
    }

}
