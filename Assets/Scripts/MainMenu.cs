﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string single;
    public string multi;

	public void LoadSingle () {
        SceneManager.LoadScene(this.single);
    }

    public void LoadMulti () {
        SceneManager.LoadScene(this.multi);
    }

    public void QuitGame () {
        Application.Quit();
    }
}
