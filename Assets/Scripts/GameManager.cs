using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Text scoreText;
    private int score1;
    private int score2;

    public Text winText;
    public int scoreTarget;
    private const int DEFAULT_SCORE_TARGET = 3;

    public GameObject ball;

	// Use this for initialization
	void Start () {
        this.score1 = 0;
        this.score2 = 0;
        this.scoreTarget = DEFAULT_SCORE_TARGET;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("MainMenu");
        }
	}

    public void UpdateScore (int player) {
        if (player == Constants.PLAYER_ONE) {
            this.score1++;
        }
        else if (player == Constants.PLAYER_TWO) {
            this.score2++;
        }
        this.scoreText.text = this.score1 + " - " + this.score2;

        if (this.score1 >= this.scoreTarget) {
            this.winText.gameObject.SetActive(true);
            this.winText.text = "Player 1 Wins";
            this.ball.SetActive(false);
        }
        else if(this.score2 >= this.scoreTarget) {
            this.winText.gameObject.SetActive(true);
            this.winText.text = "Player 2 Wins";
            this.ball.SetActive(false);
        }
    }
}
