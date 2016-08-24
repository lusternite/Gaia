using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SolutionButton : MonoBehaviour
{
    public GaiaManager.Solutions SolutionType;

    public AudioSource earthquake;
    public AudioSource volcano;
    public AudioSource tsunami;
    public AudioSource flood;
    public AudioSource blizzard;
    public AudioSource tornado;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    EarthRotation EarthRotationScript()
    {
        GameObject o = GameObject.Find("Earth");
        return o.GetComponent<EarthRotation>();
    }

    public void ChooseSolution()
    {
        GameObject eventPopup = GameObject.FindGameObjectWithTag("EventPopup");
        if (eventPopup != null)
        {
            FindObjectOfType<GaiaManager>().UpdateContinent(eventPopup.GetComponent<EventPopupBehaviour>().Continent, SolutionType, eventPopup.GetComponent<EventPopupBehaviour>().Problem);
            Destroy(eventPopup);

            GameObject[] TotalCollectables = GameObject.FindGameObjectsWithTag("hazard");
            //maxCollectables = TotalCollectables.Length.ToString();
            //CollectablesText.text = "0 / " + maxCollectables;

            if (TotalCollectables.Length == 1)
            {
                TotalCollectables[0].SetActive(true);
            }

            //GameObject[] gos;
            //gos = GameObject.FindGameObjectsWithTag("hazard");


            string a = "";
            string b = "";
            switch (eventPopup.GetComponent<EventPopupBehaviour>().Continent)
            {
                case "AFRICA":
                    a = "Africa";
                    break;
                case "EUROPE":
                    a = "Europe";
                    break;
                case "ASIA":
                    a = "Asia";
                    break;
                case "NORTHAMERICA":
                    a = "North America";
                    break;
                case "SOUTHAMERICA":
                    a = "South America";
                    break;
                case "AUSTRALIA":
                    a = "Oceania";
                    break;
                default:
                    break;
            }

            switch (SolutionType)
            {
                case GaiaManager.Solutions.BLIZZARD:
                    b = "Blizzard ";
                    blizzard.Play();
                    break;
                case GaiaManager.Solutions.VOLCANO:
                    b = "Volcano ";
                    volcano.Play();
                    Debug.Log("volcano sound should have played");
                    break;
                case GaiaManager.Solutions.FLOOD:
                    b = "Flood ";
                    flood.Play();
                    break;
                case GaiaManager.Solutions.TSUNAMI:
                    b = "Tsunami ";
                    tsunami.Play();
                    break;
                case GaiaManager.Solutions.EARTHQUAKE:
                    b = "Earthquake ";
                    earthquake.Play();
                    break;
                case GaiaManager.Solutions.TORNADO:
                    b = "Tornado ";
                    tornado.Play();
                    break;

            }

            EarthRotationScript().SnapBackToRotation();

            if (FindObjectOfType<GaiaManager>().previous != "")
            {
                GameObject same2 = GameObject.Find(FindObjectOfType<GaiaManager>().previous);
                same2.SetActive(false);
                Debug.Log("Yes");
            }




            GameObject same = GameObject.Find("Earth/EarthModel/" + b + a);
            Debug.Log("I made" + b + a);
            same.SetActive(true);

            FindObjectOfType<GaiaManager>().previous = "Earth/EarthModel/" + b + a;
        }
    }
}


