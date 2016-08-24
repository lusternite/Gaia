using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class StatisticIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public GameObject ToolTipObject;
    public string ToolTipString;
    public Color ToolTipStringColor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse enter");
        ToolTipObject.GetComponent<Text>().text = ToolTipString;
        ToolTipObject.GetComponent<Text>().color = ToolTipStringColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exit");
        ToolTipObject.GetComponent<Text>().text = "";
    }
}
