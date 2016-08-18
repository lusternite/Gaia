using UnityEngine;
using System.Collections;

public class WasteBarBehaviour : MonoBehaviour {

    GaiaManager gaiaManager;

	// Use this for initialization
	void Start () {
        gaiaManager = FindObjectOfType<GaiaManager>();
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100.0f * (float)gaiaManager.Waste / 30.0f);
	}
}
