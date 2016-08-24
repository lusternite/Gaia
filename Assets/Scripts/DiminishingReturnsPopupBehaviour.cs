using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DiminishingReturnsPopupBehaviour : MonoBehaviour {

    public float FadeTime = 5.0f;
    float CurrentFade = 0.0f;

	// Use this for initialization
	void Start () {
        CurrentFade = FadeTime + 2.0f;
	}
	
	// Update is called once per frame
	void Update () {

        CurrentFade -= Time.deltaTime;
        if (CurrentFade <= 0.0f)
        {
            Destroy(gameObject);
        }
        else
        {
            GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, CurrentFade / FadeTime);
            transform.GetChild(0).GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, CurrentFade / FadeTime);
        }

	}
}
