using UnityEngine;
using System.Collections;

public class EventScrollerBehaviour : MonoBehaviour {

    public GameObject ScrollingEventPrefab;
    public float SpawnRate = 5.0f;
    float SpawnTimer = 0.0f;

	// Use this for initialization
	void Start () {
        Debug.Log(Screen.currentResolution);
	}
	
	// Update is called once per frame
	void Update () {
        SpawnScrollingEvent();
	}

    void SpawnScrollingEvent()
    {
        if (SpawnTimer == 0.0f)
        {
            //Spawn prefab
            GameObject NewPrefab = Instantiate(ScrollingEventPrefab);
            NewPrefab.GetComponent<ScrollingEventBehaviour>().Problem = GenerateRandomProblem();
            NewPrefab.GetComponent<ScrollingEventBehaviour>().ClimateDamage = GenerateRandomClimateDamage();
            NewPrefab.transform.SetParent(transform);
            NewPrefab.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, Screen.currentResolution.height / 2 + NewPrefab.GetComponent<RectTransform>().rect.height);
            SpawnTimer = SpawnRate;
        }
        else if (SpawnTimer > 0.0f)
        {
            SpawnTimer -= Time.deltaTime;
            if (SpawnTimer <= 0.0f)
            {
                SpawnTimer = 0.0f;
            }
        }
    }

    GaiaManager.Problems GenerateRandomProblem()
    {
        float randomProblem = Random.Range(0.0f, 10.0f);
        if (randomProblem <= 1.0f)
            return GaiaManager.Problems.LOGGING;
        else if (randomProblem <= 2.0f)
            return GaiaManager.Problems.LAND_DEV;
        else if (randomProblem <= 3.0f)
            return GaiaManager.Problems.FOREST_BURN;
        else if (randomProblem <= 4.0f)
            return GaiaManager.Problems.FOSSIL_FUEL;
        else if (randomProblem <= 5.0f)
            return GaiaManager.Problems.FACTORY;
        else if (randomProblem <= 6.0f)
            return GaiaManager.Problems.TRANSPORT;
        else if (randomProblem <= 7.0f)
            return GaiaManager.Problems.AGRICULTURE;
        else if (randomProblem <= 8.0f)
            return GaiaManager.Problems.LANDFILL;
        else if (randomProblem <= 9.0f)
            return GaiaManager.Problems.COMBUSTION;
        else 
            return GaiaManager.Problems.HAZARD;
    }

    float GenerateRandomClimateDamage()
    {
        return ((float)FindObjectOfType<GaiaManager>().DeathRate * Random.Range(1.0f, 10.0f));
    }
}
