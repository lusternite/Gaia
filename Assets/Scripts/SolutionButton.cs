using UnityEngine;
using System.Collections;

public class SolutionButton : MonoBehaviour {

    public string SolutionType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChooseSolution()
    {
        switch (SolutionType)
        {
            case "EARTHQUAKE":
                {

                    break;
                }
            case "VOLCANO":
                {

                    break;
                }
            case "TSUNAMI":
                {

                    break;
                }
            case "FLOOD":
                {

                    break;
                }
            case "HURRICANE":
                {

                    break;
                }
            case "TORNADO":
                {

                    break;
                }
            case "DROUGHT":
                {

                    break;
                }
            case "FAMINE":
                {

                    break;
                }
            case "HEATWAVE":
                {

                    break;
                }
            case "BLIZZARD": //....entertainment
                {

                    break;
                }
            case "WILDFIRE":
                {

                    break;
                }
        }
    }
}
