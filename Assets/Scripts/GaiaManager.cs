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

    public int Year;

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
    public GameObject DiminishingReturnsPrefab;

    public string previous;

    public AudioSource BackgroundMusic;
    public AudioClip MoodEasy;
    public AudioClip MoodMedium;
    public AudioClip MoodHard;

    public GameObject ex1;
    public GameObject ex2;
    public GameObject ex3;
    public GameObject ex4;
    public GameObject ex5;

    EarthRotation EarthRotationScript()
    {
        GameObject o = GameObject.Find("Earth");
        return o.GetComponent<EarthRotation>();
    }

    // Use this for initialization
    void Start()
    {
        ex1.GetComponent<Image>().enabled = false;
        ex2.GetComponent<Image>().enabled = false;
        ex3.GetComponent<Image>().enabled = false;
        ex4.GetComponent<Image>().enabled = false;
        ex5.GetComponent<Image>().enabled = false;

        TimePassed = Time.time;
        UpdateTime = Time.time;
        Year = 2000;

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
        previous = "";

        BackgroundMusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - TimePassed > 15.0f)
        {
            Year += 1;
            TimePassed = Time.time;
            UpdateMusic();
            //Cap the death rate so it doesnt get out of hand
            if (DeathRate < 15.0f)
            {
                //Raise passive increase rate
                DeathRate = Mathf.Pow((float)DeathRate, 1.095f);
            }
        }
        if (Time.time - UpdateTime > TickRate)
        {
            UpdateTime = Time.time;

            //Add passive values
            Waste += DeathRate / (35 / TickRate);
            if (Waste > 80)
                ex1.GetComponent<Image>().enabled = true;
            else
                ex1.GetComponent<Image>().enabled = false;

            Deforestation += DeathRate / (35 / TickRate);
            if (Deforestation > 80)
                ex2.GetComponent<Image>().enabled = true;
            else
                ex2.GetComponent<Image>().enabled = false;

            GreenhouseGas += DeathRate / (35 / TickRate);
            if (GreenhouseGas > 80)
                ex3.GetComponent<Image>().enabled = true;
            else
                ex4.GetComponent<Image>().enabled = false;

            //Fix Temperature
            Temperature = 16 + ((Waste + Deforestation + GreenhouseGas) / 30);
            if (Temperature > 20)
                ex5.GetComponent<Image>().enabled = true;
            else
                ex5.GetComponent<Image>().enabled = false;

            //Raise water level
            WaterLevel += Mathf.Pow(2, ((float)Temperature - 16)) / (60 / TickRate);
            if (WaterLevel > 55)
                ex4.GetComponent<Image>().enabled = true;
            else
                ex4.GetComponent<Image>().enabled = false;
        }

        if (WaterLevel >= 70.0f)
        {
            //Lose the game
            GameObject.Find("GameManager").GetComponent<GameManager>().Setyear(Year);
            Application.LoadLevel("PostGameScene");
            FindObjectOfType<GameManager>().ChangeBGM("PostGameScene");
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
        double Multiplier = 2.5 + (DeathRate / 1.5);
        int _iCount = 0;

        //Reduce reduction power with diminishing returns
        for (int i = 0; i < GetContinent(Continent).Count; i++)
        {
            if (GetContinent(Continent)[i] == Solution)
            {
                _iCount += 1;
                Multiplier *= 0.6f; //?
            }
            Debug.Log("Current count is = " + _iCount);
            if (_iCount >= 2)
            {
                GameObject DRCheck = GameObject.FindGameObjectWithTag("DiminishingReturnsPopup");
                if (DRCheck)
                {
                    Destroy(DRCheck);
                }
                GameObject DRPopup = Instantiate(DiminishingReturnsPrefab); //Instantiate an information popup.
                DRPopup.transform.SetParent(GameObject.Find("Canvas").transform);
                DRPopup.GetComponent<RectTransform>().anchoredPosition = new Vector2(-352.0f, -104.0f);
                switch (Solution)
                {
                    case Solutions.TORNADO:
                        DRPopup.transform.GetChild(0).GetComponent<Text>().text = "With so many Tornados recently occuring in " + ContinentStringConverter(Continent) + " the government has been increasing awareness and structural integrity of weak buildings.";
                        break;
                    case Solutions.VOLCANO:
                        DRPopup.transform.GetChild(0).GetComponent<Text>().text = "With so much Volcanic activity happening in " + ContinentStringConverter(Continent) + " early alarm systems have been implemented, and precautions are being taken.";
                        break;
                    case Solutions.EARTHQUAKE:
                        DRPopup.transform.GetChild(0).GetComponent<Text>().text = "With the amount Earthquakes being experienced by " + ContinentStringConverter(Continent) + " structural integrity of buildings is being reinforced as a precaution.";
                        break;
                    case Solutions.BLIZZARD:
                        DRPopup.transform.GetChild(0).GetComponent<Text>().text = "With the amount of blizzards happening in " + ContinentStringConverter(Continent) + " citizens are taking extra care around the continent.";
                        break;
                    case Solutions.TSUNAMI:
                        DRPopup.transform.GetChild(0).GetComponent<Text>().text = "With the frequency of tsunami's growing in " + ContinentStringConverter(Continent) + " wave breakers are being used to lessen their impact";
                        break;
                    case Solutions.FLOOD:
                        DRPopup.transform.GetChild(0).GetComponent<Text>().text = "With all the recent Floods in " + ContinentStringConverter(Continent) + " there has been a heavy increase in flood prevention measures.";
                        break;
                    default:
                        break;
                }
            }
            //Call popup function
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
            BackgroundMusic.Pause();
            FindObjectOfType<GameManager>().BackGroundMusic.Pause();
        }
        else if (!soundOn)
        {
            soundButton.GetComponent<Image>().sprite = sound;
            soundOn = true;
            BackgroundMusic.Play();
            FindObjectOfType<GameManager>().BackGroundMusic.Play();
        }

    }

    void UpdateMusic()
    {
        double IntensityLevel = Waste + GreenhouseGas + Deforestation;
        if (IntensityLevel < 60 && BackgroundMusic.clip != MoodEasy)
        {
            BackgroundMusic.clip = MoodEasy;
            BackgroundMusic.Play();
        }
        else if (IntensityLevel >= 60 && IntensityLevel < 120 && BackgroundMusic.clip != MoodMedium)
        {
            BackgroundMusic.clip = MoodMedium;
            BackgroundMusic.Play();
        }
        else if (IntensityLevel >= 120 && BackgroundMusic.clip != MoodHard)
        {
            BackgroundMusic.clip = MoodHard;
            BackgroundMusic.Play();
        }
    }

    public void QuitToMenu()
    {
        Application.LoadLevel("MenuScene");
        FindObjectOfType<GameManager>().ChangeBGM("MenuScene");
    }

    string ContinentStringConverter(string continent)
    {
        switch (continent)
        {
            case "AFRICA":
                return "Africa";
            case "EUROPE":
                return "Europe";
            case "ASIA":
                return "Asia";
            case "NORTHAMERICA":
                return "North America";
            case "SOUTHAMERICA":
                return "South America";
            case "AUSTRALIA":
                return "Oceania";
            default:
                return "Conversion Error";
        }
    }
}