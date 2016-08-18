using UnityEngine;
using System.Collections;

public class SolutionButton : MonoBehaviour {

    public GaiaManager.Solutions SolutionType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChooseSolution()
    {
        GameObject eventPopup = GameObject.FindGameObjectWithTag("EventPopup");
        if (eventPopup != null)
        {
            FindObjectOfType<GaiaManager>().UpdateContinent(eventPopup.GetComponent<EventPopupBehaviour>().Continent, SolutionType, eventPopup.GetComponent<EventPopupBehaviour>().Problem);
            Time.timeScale = 1.0f;
            Destroy(eventPopup);
        }
    }
}
