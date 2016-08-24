using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text years;

	// Use this for initialization
	void Start ()
    {
        if (years != null)
	        years.text = "The Earth survived for: " + GameObject.Find("GameManger").GetComponent<GameManager>().Getyear().ToString() + " Years";
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void ExitApplication()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        Application.LoadLevel("GameScene");
        FindObjectOfType<GameManager>().ChangeBGM("GameScene");
    }

    public void ReturnToMenu()
    {
        Application.LoadLevel("MenuScene");
        FindObjectOfType<GameManager>().ChangeBGM("MenuScene");
    }

    public void LinkOne()
    {
        Application.OpenURL("http://www.earthday.org/campaigns/climate-change/");
    }

}
