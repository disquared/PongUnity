using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public float startForce;

    private Rigidbody2D rigidBody;

    public GameObject paddle1;
    public GameObject paddle2;

    public GameManager gm;

    // Use this for initialization
    void Start () {
		this.rigidBody = GetComponent<Rigidbody2D>();
        this.rigidBody.velocity = new Vector2(this.startForce, this.startForce);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "GoalZone") {
            if (transform.position.x > 0) {
                transform.position = this.paddle2.transform.position + new Vector3(-.25f, 0);
                this.rigidBody.velocity = new Vector2(-this.startForce, -this.startForce);
                this.gm.UpdateScore(Constants.PLAYER_ONE);
            }
            else {
                transform.position = this.paddle1.transform.position + new Vector3(.25f, 0);
                this.rigidBody.velocity = new Vector2(startForce, -startForce);
                this.gm.UpdateScore(Constants.PLAYER_TWO);
            }
        }
    }
}
