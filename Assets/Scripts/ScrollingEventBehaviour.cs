using UnityEngine;
using System.Collections;

public class ScrollingEventBehaviour : MonoBehaviour {

    public float ScrollSpeed = 100.0f;
    RectTransform rectTransform;
    public GameObject EventPopup;

	// Use this for initialization
	void Start () {
        rectTransform = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y - ScrollSpeed * Time.deltaTime);
        if (rectTransform.anchoredPosition.y <= 0.0f)
        {
            gameObject.SetActive(false);
        }
	}

    public void SpawnEventPopup()
    {
        GameObject eventPopup = Instantiate(EventPopup);
        eventPopup.transform.SetParent(GameObject.Find("Canvas").transform);
        eventPopup.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
        Time.timeScale = 0.5f;
    }
}
