using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIDisplay : MonoBehaviour {

    public enum UIType { WASTE, GAS, DEFORESTATION, WATER, TEMP };
    public UIType UiElement;
    public Text UiPercent;

    GaiaManager gaiaManager;

    // Use this for initialization
    void Start () {
        gaiaManager = FindObjectOfType<GaiaManager>();
    }
	
	// Update is called once per frame
	void Update () {
	    switch (UiElement)
        {
            case UIType.WASTE:
                UiPercent.text = "Waste = " + Waste() + "%";
                break;
            case UIType.GAS:
                UiPercent.text = "Greenhouse Gasses = " + Gas() + "%";
                break;
            case UIType.DEFORESTATION:
                UiPercent.text = "Deforestation = " + Deforestation() + "%";
                break;
            case UIType.WATER:
                UiPercent.text = "Temperature = " + Temperature() + " C";
                break;
            case UIType.TEMP:
                UiPercent.text = "Water level = " + WaterLevel() + " m";
                break;
        }
	}

    string Waste()
    {
        return (Mathf.Floor((float)gaiaManager.Waste).ToString());
    }

    string Gas()
    {
        return (Mathf.Floor((float)gaiaManager.GreenhouseGas).ToString());
    }

    string Deforestation()
    {
        return (Mathf.Floor((float)gaiaManager.Deforestation).ToString());
    }

    string Temperature()
    {
        return (Mathf.Floor((float)gaiaManager.Temperature).ToString());
    }

    string WaterLevel()
    {
        return (Mathf.Floor((float)gaiaManager.WaterLevel).ToString());
    }
}
