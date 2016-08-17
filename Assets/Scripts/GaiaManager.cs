using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GaiaManager : MonoBehaviour {

    public enum Solutions { EARTHQUAKE, VOLCANO, TSUNAMI, FLOOD, HURRICANE, TORNADO, DROUGHT, FAMINE, HEATWAVE, BLIZZARD, WILDFIRE, NOTHING };
    public enum Problems { WASTE, FOSSIL, GREENHOUSE };

    public double TimePassed;

    public List<Solutions> Africa;
    public List<Solutions> Asia;
    public List<Solutions> Australia;
    public List<Solutions> Europe;
    public List<Solutions> NorthAmerica;
    public List<Solutions> SouthAmerica;

    public int Waste;
    public int FossilFuels;
    public int GreenhouseGas;

    public float WaterLevel;
    public int Temperature;

    public float DeathRate;

    // Use this for initialization
    void Start () {
        TimePassed = Time.time;
        WaterLevel = 7.0f;
        DeathRate = 10.0f;
    for (int i = 0; i < 3; ++i)
        {
            Africa[i] = Solutions.NOTHING;
            Asia[i] = Solutions.NOTHING;
            Australia[i] = Solutions.NOTHING;
            Europe[i] = Solutions.NOTHING;
            NorthAmerica[i] = Solutions.NOTHING;
            SouthAmerica[i] = Solutions.NOTHING;
        }
}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - TimePassed > 15.0f)
        {
            TimePassed = Time.time;

            DeathRate = Mathf.Pow(DeathRate, 1.05f);
        }

        Waste += (int)DeathRate / 10;
        FossilFuels += (int)DeathRate / 4;
        GreenhouseGas += (int)DeathRate / 6;

        WaterLevel = (Waste * 0.00004f) + (FossilFuels * 0.000005f) + (GreenhouseGas * 0.000015f);
        
        if (WaterLevel >= 70.0f)
        {
            //Lose the game
        }
	}

    public void UpdateContinent(string Continent, Solutions Solution, Problems Problem)
    {
        GetContinent(Continent).Add(Solution);
        if (GetContinent(Continent).Count > 3)
        {
            GetContinent(Continent).RemoveAt(0);
        }
        float PowerMultiplier = 50.0f;
        for (int i = 0; i < GetContinent(Continent).Count; i++)
        {
            if (GetContinent(Continent)[i] == Solution)
            {
                PowerMultiplier *= 0.6f; //?
            }
        }
        switch (Problem)
        {
            case Problems.WASTE:
                Waste -= (int)PowerMultiplier;
                if (Waste < 0){
                    Waste = 0;
                }
                break;
            case Problems.FOSSIL:
                FossilFuels -= (int)PowerMultiplier;
                if (FossilFuels < 0){
                    FossilFuels = 0;
                }
                break;
            case Problems.GREENHOUSE:
                GreenhouseGas -= (int)PowerMultiplier;
                if (Waste < 0){
                    GreenhouseGas = 0;
                }
                break;
            default:
                break;            
        }
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

}
