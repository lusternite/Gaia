﻿using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
	
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
    }

}