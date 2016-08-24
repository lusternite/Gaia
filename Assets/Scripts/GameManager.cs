using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public AudioSource BackGroundMusic;
    public AudioClip MenuTheme;
    public AudioClip MainTheme;
    public AudioClip EndTheme;

    public int years;

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

        BackGroundMusic = GetComponent<AudioSource>();

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

    public void ChangeBGM(string LevelName)
    {
        switch (LevelName)
        {
            case "GameScene":
                {
                    BackGroundMusic.clip = MainTheme;
                    break;
                }
            case "PostGameScene":
                {
                    BackGroundMusic.clip = EndTheme;
                    break;
                }
            case "MenuScene":
                {
                    BackGroundMusic.clip = MenuTheme;
                    break;
                }
        }
        BackGroundMusic.Play();
    }

    public void Setyear(int y)
    {
        years = y;
    }

    public int Getyear()
    {
        return years;
    }
}
