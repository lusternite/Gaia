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
        float randomProblem = Random.Range(0, 3);
        if (randomProblem <= 1.0f)
        {
            return GaiaManager.Problems.FOSSIL;
        }
        else if (randomProblem <= 2.0f)
        {
            return GaiaManager.Problems.GREENHOUSE;
        }
        else
        {
            return GaiaManager.Problems.WASTE;
        }
    }

    float GenerateRandomClimateDamage()
    {
        return ((float)FindObjectOfType<GaiaManager>().DeathRate * Random.Range(1.0f, 10.0f));
    }
}
