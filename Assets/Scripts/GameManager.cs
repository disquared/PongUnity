using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text scoreText;

    private int score1;
    private int score2;

	// Use this for initialization
	void Start () {
        this.score1 = 0;
        this.score2 = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateScore(int player) {
        if (player == 1) {
            this.score1++;
        }
        else if (player == 2) {
            this.score2++;
        }

        this.scoreText.text = this.score1 + " - " + this.score2;
    }
}
