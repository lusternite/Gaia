using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GaiaManager : MonoBehaviour
{

    public enum Solutions { EARTHQUAKE, VOLCANO, TSUNAMI, FLOOD, HURRICANE, TORNADO, DROUGHT, FAMINE, HEATWAVE, BLIZZARD, WILDFIRE, NOTHING };
    public enum Problems { WASTE, FOSSIL, GREENHOUSE };

    public double TimePassed;
    public double UpdateTime;

    public List<Solutions> Africa;
    public List<Solutions> Asia;
    public List<Solutions> Australia;
    public List<Solutions> Europe;
    public List<Solutions> NorthAmerica;
    public List<Solutions> SouthAmerica;

    public double Waste;
    public double FossilFuels;
    public double GreenhouseGas;

    public double WaterLevel;
    public double Temperature;

    public double DeathRate;

    public double TickRate;

    bool soundOn = true;

    public Sprite sound;
    public Sprite mute;
    public Button soundButton;

    // Use this for initialization
    void Start()
    {
        TimePassed = Time.time;
        UpdateTime = Time.time;

        if (Temperature == 0)        
            Temperature = 16.0f;     
        if (WaterLevel == 0)        
            WaterLevel = 7.0f;
        if (DeathRate == 0)
            DeathRate = 2.0f;
        if (TickRate == 0)
            TickRate = 0.25f;

        for (int i = 0; i < 3; ++i)
        {
            Africa.Add(Solutions.NOTHING);
            Asia.Add(Solutions.NOTHING);
            Australia.Add(Solutions.NOTHING);
            Europe.Add(Solutions.NOTHING);
            NorthAmerica.Add(Solutions.NOTHING);
            SouthAmerica.Add(Solutions.NOTHING);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - TimePassed > 15.0f)
        {
            TimePassed = Time.time;
            //Raise passive increase rate
            DeathRate = Mathf.Pow((float)DeathRate, 1.095f);
        }
        if (Time.time - UpdateTime > TickRate)
        {
            UpdateTime = Time.time;

            //Add passive values
            Waste += DeathRate / (35 / TickRate);
            FossilFuels += DeathRate / (35 / TickRate);
            GreenhouseGas += DeathRate / (35 / TickRate);

            //Fix Temperature
            Temperature = 16 + ((Waste + FossilFuels + GreenhouseGas) / 30);

            //Raise water level
            WaterLevel += Mathf.Pow(2, ((float)Temperature - 16)) / (60 / TickRate);
        }

        if (WaterLevel >= 70.0f)
        {
            //Lose the game
        }
    }

    public void UpdateContinent(string Continent, Solutions Solution, Problems Problem)
    {
        //Add natural disaster to the list of previous disasters in the specific continent
        GetContinent(Continent).Add(Solution);

        //Cap continents memory to 3 disasters
        if (GetContinent(Continent).Count > 3)
        {
            GetContinent(Continent).RemoveAt(0);
        }
        float PowerMultiplier = 10.0f;

        //Reduce reduction power with diminishing returns
        for (int i = 0; i < GetContinent(Continent).Count; i++)
        {
            if (GetContinent(Continent)[i] == Solution)
            {
                PowerMultiplier *= 0.5f; //?
            }
        }
        switch (Problem)
        {
            case Problems.WASTE:
                //Positive solutions
                if (Solution == Solutions.BLIZZARD)
                {
                    Waste -= (int)PowerMultiplier * 2;
                }
                //Negative solutions
                else if (Solution == Solutions.EARTHQUAKE)
                {
                    Waste -= (int)PowerMultiplier * 0.5;
                }
                //Neutral solutions
                else
                {
                    Waste -= (int)PowerMultiplier;
                }
                Debug.Log("subtracting waste");
                break;
            case Problems.FOSSIL:
                if (Solution == Solutions.BLIZZARD)
                {
                    Waste -= (int)PowerMultiplier * 2;
                }
                //Negative solutions
                else if (Solution == Solutions.EARTHQUAKE)
                {
                    Waste -= (int)PowerMultiplier * 0.5;
                }
                //Neutral solutions
                else
                {
                    Waste -= (int)PowerMultiplier;
                }
                Debug.Log("subtracting deforestation");
                break;
            case Problems.GREENHOUSE:
                if (Solution == Solutions.BLIZZARD)
                {
                    Waste -= (int)PowerMultiplier * 2;
                }
                //Negative solutions
                else if (Solution == Solutions.EARTHQUAKE)
                {
                    Waste -= (int)PowerMultiplier * 0.5;
                }
                //Neutral solutions
                else
                {
                    Waste -= (int)PowerMultiplier;
                }
                Debug.Log("subtracting gas");
                break;
            default:
                break;
        }

        //Clean up
        if (GreenhouseGas < 0)        
            GreenhouseGas = 0;        
        if (Waste < 0)        
            Waste = 0;        
        if (FossilFuels < 0)        
            FossilFuels = 0;        
    }

    List<Solutions> GetContinent(string Continent)
    {
        switch (Continent)
        {
            case "AFRICA":
                return Africa;
            case "EUROPE":
                return Europe;
            case "AUSTRALIA":
                return Australia;
            case "ASIA":
                return Asia;
            case "NORTHAMERICA":
                return NorthAmerica;
            case "SOUTHAMERICA":
                return SouthAmerica;
            default:
                return Africa;
        }
    }

    public void ToggleSound()
    {
        if (soundOn)
        {
            soundButton.GetComponent<Image>().sprite = mute;
            soundOn = false;
        }
        else if (!soundOn)
        {
            soundButton.GetComponent<Image>().sprite = sound;
            soundOn = true;
        }

    }

    public void QuitToMenu()
    {
        Application.LoadLevel("MenuScene");
    }
}