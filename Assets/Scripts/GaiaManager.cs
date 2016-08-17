using UnityEngine;
using System.Collections;

public class GaiaManager : MonoBehaviour {

    public enum Solutions { EARTHQUAKE, VOLCANO, TSUNAMI, FLOOD, HURRICANE, TORNADO, DROUGHT, FAMINE, HEATWAVE, BLIZZARD, WILDFIRE, NOTHING };
    public enum Problems { WASTE, FOSSIL, GREENHOUSE };


    public Solutions[] Africa;
    public Solutions[] Asia;
    public Solutions[] Australia;
    public Solutions[] Europe;
    public Solutions[] NorthAmerica;
    public Solutions[] SouthAmerica;



    public int Waste;
    public int FossilFuels;
    public int GreenhouseGas;

    public int WaterLevel;
    public int Temperature;



    // Use this for initialization
    void Start () {

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
        if (WaterLevel >= 70)
        {
            //Lose the game
        }
	}

    public void UpdateContinent(string Continent, Solutions Solution, Problems Problem)
    {
        switch (Solution)
        {
            case Solutions.EARTHQUAKE:
                break;
            case Solutions.VOLCANO:
                break;
            case Solutions.TSUNAMI:
                break;
            case Solutions.FLOOD:
                break;
            case Solutions.HURRICANE:
                break;
            case Solutions.TORNADO:
                break;
            case Solutions.DROUGHT:
                break;
            case Solutions.FAMINE:
                break;
            case Solutions.HEATWAVE:
                break;
            case Solutions.BLIZZARD:
                break;
            case Solutions.WILDFIRE:
                break;
            case Solutions.NOTHING:
                break;
            default:
                break;
        }
    }

}
