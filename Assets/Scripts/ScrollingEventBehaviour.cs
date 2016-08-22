using UnityEngine;
using System.Collections;

public class ScrollingEventBehaviour : MonoBehaviour {

    public float ScrollSpeed = 100.0f;
    RectTransform rectTransform;
    public GameObject EventPopup;
    public float TimeSlowFactor = 0.5f;
    public GaiaManager.Problems Problem;
    public float ClimateDamage;

    // Use this for initialization
    void Start () {
        rectTransform = GetComponent<RectTransform>();
        CauseGaiaDamage();
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
        if (GameObject.FindGameObjectWithTag("EventPopup") == null)
        {
            GameObject eventPopup = Instantiate(EventPopup);
            eventPopup.GetComponent<EventPopupBehaviour>().Problem = Problem;
            eventPopup.GetComponent<EventPopupBehaviour>().ClimateDamage = ClimateDamage;
            eventPopup.transform.SetParent(GameObject.Find("Canvas").transform);
            eventPopup.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
            Time.timeScale = TimeSlowFactor;
            gameObject.SetActive(false);
        }
    }

    //This function is called on creation, and does damage to one of Gaia's climate problems
    void CauseGaiaDamage()
    {
        GaiaManager gaiaManager = FindObjectOfType<GaiaManager>();
        switch (Problem)
        {
            case GaiaManager.Problems.LOGGING:
                {
                    gaiaManager.Deforestation += ClimateDamage;
                    break;
                }
            case GaiaManager.Problems.LAND_DEV:
                {
                    gaiaManager.Deforestation += ClimateDamage;
                    break;
                }
            case GaiaManager.Problems.FOREST_BURN:
                {
                    gaiaManager.Deforestation += ClimateDamage;
                    break;
                }
            case GaiaManager.Problems.FOSSIL_FUEL:
                {
                    gaiaManager.GreenhouseGas += ClimateDamage;
                    break;
                }
            case GaiaManager.Problems.FACTORY:
                {
                    gaiaManager.GreenhouseGas += ClimateDamage;
                    break;
                }
            case GaiaManager.Problems.TRANSPORT:
                {
                    gaiaManager.GreenhouseGas += ClimateDamage;
                    break;
                }
            case GaiaManager.Problems.AGRICULTURE:
                {
                    gaiaManager.GreenhouseGas += ClimateDamage;
                    break;
                }
            case GaiaManager.Problems.LANDFILL:
                {
                    gaiaManager.Waste += ClimateDamage;
                    break;
                }
            case GaiaManager.Problems.COMBUSTION:
                {
                    gaiaManager.Waste += ClimateDamage;
                    break;
                }
            case GaiaManager.Problems.HAZARD:
                {
                    gaiaManager.Waste += ClimateDamage;
                    break;
                }
            default:
                {

                    break;
                }
        }
    }
}
