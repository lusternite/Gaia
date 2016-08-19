using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GaiaManager : MonoBehaviour
{

    public enum Solutions { EARTHQUAKE, VOLCANO, TSUNAMI, FLOOD, TORNADO, BLIZZARD, NOTHING };
    public enum Problems { LOGGING, LAND_DEV, FOREST_BURN, FOSSIL_FUEL, FACTORY, TRANSPORT, AGRICULTURE, LANDFILL, COMBUSTION, HAZARD };

    public double TimePassed;
    public double UpdateTime;

    public List<Solutions> Africa;
    public List<Solutions> Asia;
    public List<Solutions> Australia;
    public List<Solutions> Europe;
    public List<Solutions> NorthAmerica;
    public List<Solutions> SouthAmerica;

    public double Waste;
    public double Deforestation;
    public double GreenhouseGas;

    public double WaterLevel;
    public double Temperature;

    public double DeathRate;
    public double TickRate;

    public double PositiveReaction;
    public double NegativeReaction;
    public double Reaction;

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
        if (PositiveReaction == 0)
            PositiveReaction = 2.0f;
        if (NegativeReaction == 0)
            NegativeReaction = 0.75f;
        if (Reaction == 0)
            Reaction = 5.0f;

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
            Deforestation += DeathRate / (35 / TickRate);
            GreenhouseGas += DeathRate / (35 / TickRate);

            //Fix Temperature
            Temperature = 16 + ((Waste + Deforestation + GreenhouseGas) / 30);

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
        double Multiplier = (DeathRate * 4);

        //Reduce reduction power with diminishing returns
        for (int i = 0; i < GetContinent(Continent).Count; i++)
        {
            if (GetContinent(Continent)[i] == Solution)
            {
                Multiplier *= 0.5f; //?
            }
        }
        switch (Problem)
        {
            case Problems.LOGGING:
                //Positive solutions
                if (Solution == Solutions.TORNADO || Solution == Solutions.BLIZZARD)
                    Deforestation -= (int)Multiplier * PositiveReaction;
                //Negative solutions
                else if (Solution == Solutions.EARTHQUAKE)
                    Deforestation -= (int)Multiplier * NegativeReaction;
                //Neutral solutions
                else
                    Deforestation -= (int)Multiplier;
                break;
            case Problems.LAND_DEV:
                //Positive solutions
                if (Solution == Solutions.EARTHQUAKE || Solution == Solutions.VOLCANO)
                    Deforestation -= (int)Multiplier * PositiveReaction;
                //Negative solutions
                else if (Solution == Solutions.TORNADO)
                    Deforestation -= (int)Multiplier * NegativeReaction;
                //Neutral solutions
                else
                    Deforestation -= (int)Multiplier;
                break;
            case Problems.FOREST_BURN:
                //Positive solutions
                if (Solution == Solutions.BLIZZARD || Solution == Solutions.FLOOD || Solution == Solutions.TSUNAMI)
                    Deforestation -= (int)Multiplier * PositiveReaction;
                //Negative solutions
                else if (Solution == Solutions.VOLCANO)
                    Deforestation -= (int)Multiplier * NegativeReaction;
                //Neutral solutions
                else
                    Deforestation -= (int)Multiplier;
                break;
            case Problems.FOSSIL_FUEL:
                //Positive solutions
                if (Solution == Solutions.EARTHQUAKE || Solution == Solutions.TSUNAMI)
                    GreenhouseGas -= (int)Multiplier * PositiveReaction;
                //Negative solutions
                else if (Solution == Solutions.VOLCANO)
                    GreenhouseGas -= (int)Multiplier * NegativeReaction;
                //Neutral solutions
                else
                    GreenhouseGas -= (int)Multiplier;
                break;
            case Problems.FACTORY:
                //Positive solutions
                if (Solution == Solutions.EARTHQUAKE || Solution == Solutions.FLOOD)
                    GreenhouseGas -= (int)Multiplier * PositiveReaction;
                //Negative solutions
                else if (Solution == Solutions.VOLCANO)
                    GreenhouseGas -= (int)Multiplier * NegativeReaction;
                //Neutral solutions
                else
                    GreenhouseGas -= (int)Multiplier;
                break;
            case Problems.TRANSPORT:
                //Positive solutions
                if (Solution == Solutions.TSUNAMI || Solution == Solutions.TORNADO || Solution == Solutions.FLOOD)
                    GreenhouseGas -= (int)Multiplier * PositiveReaction;
                //Negative solutions
                else if (Solution == Solutions.BLIZZARD)
                    GreenhouseGas -= (int)Multiplier * NegativeReaction;
                //Neutral solutions
                else
                    GreenhouseGas -= (int)Multiplier;
                break;
            case Problems.AGRICULTURE:
                //Positive solutions
                if (Solution == Solutions.BLIZZARD || Solution == Solutions.FLOOD)
                    GreenhouseGas -= (int)Multiplier * PositiveReaction;
                //Negative solutions
                else if (Solution == Solutions.TORNADO)
                    GreenhouseGas -= (int)Multiplier * NegativeReaction;
                //Neutral solutions
                else
                    GreenhouseGas -= (int)Multiplier;
                break;
            case Problems.LANDFILL:
                //Positive solutions
                if (Solution == Solutions.VOLCANO)
                    Waste -= (int)Multiplier * PositiveReaction;
                //Negative solutions
                else if (Solution == Solutions.EARTHQUAKE || Solution == Solutions.TSUNAMI)
                    Waste -= (int)Multiplier * NegativeReaction;
                //Neutral solutions
                else
                    Waste -= (int)Multiplier;
                break;
            case Problems.COMBUSTION:
                //Positive solutions
                if (Solution == Solutions.BLIZZARD || (Solution == Solutions.TORNADO))
                    Waste -= (int)Multiplier * PositiveReaction;
                //Negative solutions
                else if (Solution == Solutions.VOLCANO)
                    Waste -= (int)Multiplier * NegativeReaction;
                //Neutral solutions
                else
                    Waste -= (int)Multiplier;
                break;
            case Problems.HAZARD:
                //Positive solutions
                if (Solution == Solutions.VOLCANO || Solution == Solutions.EARTHQUAKE)
                    Waste -= (int)Multiplier * PositiveReaction;
                //Negative solutions
                else if (Solution == Solutions.FLOOD || Solution == Solutions.TSUNAMI)
                    Waste -= (int)Multiplier * NegativeReaction;
                //Neutral solutions
                else
                    Waste -= (int)Multiplier;
                break;
            default:
                break;
        }

        //Clean up
        if (GreenhouseGas < 0)        
            GreenhouseGas = 0;        
        if (Waste < 0)        
            Waste = 0;        
        if (Deforestation < 0)        
            Deforestation = 0;        
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