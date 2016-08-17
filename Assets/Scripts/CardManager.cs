using UnityEngine;
using System.Collections;

public class CardManager : MonoBehaviour {

    public Vector2 StartPosition;
    public Vector2 HiddenPosition;
    Animator anim;

	// Use this for initialization
	void Start () {
        StartPosition = GetComponent<RectTransform>().anchoredPosition;
        anim = GetComponent<Animator>();
        anim.SetTrigger("DrawTrigger");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
