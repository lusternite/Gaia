using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EventPopupBehaviour : MonoBehaviour {

    string[] DeforestationLocations = { "Honduras", "Nigeria", "the Philippines", "Russia", "Ghana", "North Korea", "Brazil", "the United States of America" };
    string[] DeforestationContinents = { "NORTHAMERICA", "AFRICA", "ASIA", "EUROPE", "AFRICA", "ASIA", "SOUTHAMERICA", "NORTHAMERICA" };

    string[] GasLocations = { "China", "the United States of America", "the European Union", "India", "Brazil", "Germany", "Australia", "the Democratic Republic of Congo" };
    string[] GasContinents = { "ASIA", "NORTHAMERICA", "EUROPE", "ASIA", "SOUTHAMERICA", "EUROPE", "AUSTRALIA", "AFRICA" };

    string[] WasteLocations = { "Sri Lanka", "Barbados", "the Solomon Islands", "New Zealand", "St Lucia", "Switzerland", "Guyana" };
    string[] WasteContinents = { "ASIA", "NORTHAMERICA", "AUSTRALIA", "AUSTRALIA", "NORTHAMERICA", "EUROPE", "SOUTHAMERICA" };

    public string Continent;
    public string Country;
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

    EarthRotation EarthRotationScript()
    {
        GameObject o = GameObject.Find("Earth");
        return o.GetComponent<EarthRotation>();
    }

    void RandomlyGenerateContinent()
    {
        //float randomContinent = Random.Range(0, 6);
        //if (randomContinent <= 1.0f)
        //{
        //    Continent = "AFRICA";
        //}
        //else if (randomContinent <= 2.0f)
        //{
        //    Continent = "EUROPE";
        //}
        //else if (randomContinent <= 3.0f)
        //{
        //    Continent = "AUSTRALIA";
        //}
        //else if (randomContinent <= 4.0f)
        //{
        //    Continent = "ASIA";
        //}
        //else if (randomContinent <= 5.0f)
        //{
        //    Continent = "NORTHAMERICA";
        //}
        //else if (randomContinent <= 6.0f)
        //{
        //    Continent = "SOUTHAMERICA";
        //}

        if (Problem == GaiaManager.Problems.LOGGING || Problem == GaiaManager.Problems.LAND_DEV || Problem == GaiaManager.Problems.FOREST_BURN)
        {
            float rand = Random.Range(0, 8);
            Country = DeforestationLocations[(int)rand];
            Continent = DeforestationContinents[(int)rand];   
        }
        else if (Problem == GaiaManager.Problems.FOSSIL_FUEL || Problem == GaiaManager.Problems.FACTORY || Problem == GaiaManager.Problems.TRANSPORT || Problem == GaiaManager.Problems.AGRICULTURE)
        {
            float rand = Random.Range(0, 8);
            Country = GasLocations[(int)rand];
            Continent = GasContinents[(int)rand];
        }
        else
        {
            float rand = Random.Range(0, 7);
            Country = WasteLocations[(int)rand];
            Continent = WasteContinents[(int)rand];
        }

        EarthRotationScript().SnapToContinent(Continent);
    }

    //A temporary function to display what continent and problem this event is
    void DisplayInformation()
    {
        string strProblem = "";
        switch (Problem)
        {
            case GaiaManager.Problems.LOGGING:
                {
                    strProblem = "A large increase in logging in ";
                    break;
                }
            case GaiaManager.Problems.LAND_DEV:
                {
                    strProblem = "Major land development taking place in ";
                    break;
                }
            case GaiaManager.Problems.FOREST_BURN:
                {
                    strProblem = "Large areas of forest being burned in ";
                    break;
                }
            case GaiaManager.Problems.FOSSIL_FUEL:
                {
                    strProblem = "Fossil fuel burning is getting out of hand in ";
                    break;
                }
            case GaiaManager.Problems.FACTORY:
                {
                    strProblem = "Huge increases in factory emissions in ";
                    break;
                }
            case GaiaManager.Problems.TRANSPORT:
                {
                    strProblem = "Carbon emissions from transportation are through the roof in ";
                    break;
                }
            case GaiaManager.Problems.AGRICULTURE:
                {
                    strProblem = "Agricultural emissions being produced in ";
                    break;
                }
            case GaiaManager.Problems.LANDFILL:
                {
                    strProblem = "Exessive landfilling taking place in ";
                    break;
                }
            case GaiaManager.Problems.COMBUSTION:
                {
                    strProblem = "Large amounts of waste combustion in ";
                    break;
                }
            case GaiaManager.Problems.HAZARD:
                {
                    strProblem = "Too much hazardous waste being produced in ";
                    break;
                }
            default:
                {
                    break;
                }
        }
        transform.GetChild(0).GetComponent<Text>().text = strProblem + Country + "!";
    }

    public void DestroySelf()
    {
        EarthRotationScript().SnapBackToRotation();
        Destroy(gameObject);
    }
}
