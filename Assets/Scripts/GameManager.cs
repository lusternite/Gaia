using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    //public AudioSource BackGroundMusic;

    void Start()
    {
        //ReadFromFile();
        if (!instance)
        {
            instance = this;
            print("Game Manager Created");
        }
        else
        {
            Destroy(this.gameObject);
            print("Destroyed duplicate");
        }

        //BackGroundMusic.loop = true;
        //BackGroundMusic.Play();

        DontDestroyOnLoad(this.gameObject);
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update ()
    {
	
	}
}
