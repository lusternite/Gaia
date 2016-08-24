using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SolutionButton : MonoBehaviour
{

    public GaiaManager.Solutions SolutionType;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChooseSolution()
    {
        GameObject eventPopup = GameObject.FindGameObjectWithTag("EventPopup");
        if (eventPopup != null)
        {
            FindObjectOfType<GaiaManager>().UpdateContinent(eventPopup.GetComponent<EventPopupBehaviour>().Continent, SolutionType, eventPopup.GetComponent<EventPopupBehaviour>().Problem);
            Time.timeScale = 1.0f;
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
                    break;
                case GaiaManager.Solutions.VOLCANO:
                    b = "Volcano ";
                    break;
                case GaiaManager.Solutions.FLOOD:
                    b = "Flood ";
                    break;
                case GaiaManager.Solutions.TSUNAMI:
                    b = "Tsunami ";
                    break;
                case GaiaManager.Solutions.EARTHQUAKE:
                    b = "Earthquake ";
                    break;
                case GaiaManager.Solutions.TORNADO:
                    b = "Tornado ";
                    break;

            }

            if (FindObjectOfType<GaiaManager>().previous != "")
            {
                GameObject same2 = GameObject.Find(FindObjectOfType<GaiaManager>().previous);
                same2.SetActive(false);
                Debug.Log("Yes");
            }




            GameObject same = GameObject.Find("Earth/Model1/" + b + a);
            Debug.Log("I made" + b + a);
            same.SetActive(true);

            FindObjectOfType<GaiaManager>().previous = "Earth/Model1/" + b + a;
        }
    }
}


