using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EventPopupBehaviour : MonoBehaviour {

    public string Continent;
    public float ClimateDamage;
    public GaiaManager.Problems Problem;

	// Use this for initialization
	void Start () {
        RandomlyGenerateContinent();
        DisplayInformation();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void RandomlyGenerateContinent()
    {
        float randomContinent = Random.Range(0, 6);
        if (randomContinent <= 1.0f)
        {
            Continent = "AFRICA";
        }
        else if (randomContinent <= 2.0f)
        {
            Continent = "EUROPE";
        }
        else if (randomContinent <= 3.0f)
        {
            Continent = "AUSTRALIA";
        }
        else if (randomContinent <= 4.0f)
        {
            Continent = "ASIA";
        }
        else if (randomContinent <= 5.0f)
        {
            Continent = "NORTHAMERICA";
        }
        else if (randomContinent <= 6.0f)
        {
            Continent = "SOUTHAMERICA";
        }
    }

    //A temporary function to display what continent and problem this event is
    void DisplayInformation()
    {
        string strProblem = "";
        switch (Problem)
        {
            case GaiaManager.Problems.FOSSIL:
                {
                    strProblem = "Fossil Fuels";
                    break;
                }
            case GaiaManager.Problems.GREENHOUSE:
                {
                    strProblem = "Greenhouse gases";
                    break;
                }
            case GaiaManager.Problems.WASTE:
                {
                    strProblem = "Waste";
                    break;
                }
        }
        transform.GetChild(0).GetComponent<Text>().text = "AHHHH " + strProblem + " in " + Continent + "!";
    }
}
