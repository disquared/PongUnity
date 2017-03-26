using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    public float speed;

    private int direction;
    public float adjustSpeed;

    public Transform upperLimit;
    public Transform lowerLimit;

    public bool isPlayerOne;

    public bool isAI;
    public BallController ballController;

	// Use this for initialization
	void Start () {
        this.ballController = FindObjectOfType<BallController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isAI) {
            transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(transform.position.x,
                            this.ballController.transform.position.y,
                            transform.position.z),
                this.speed * Time.deltaTime);
            return;
        }

        KeyCode paddleUpKey = isPlayerOne ? KeyCode.W : KeyCode.UpArrow;
        KeyCode paddleDownKey = isPlayerOne ? KeyCode.S : KeyCode.DownArrow;
        if (Input.GetKey(paddleUpKey)) {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y + (this.speed * Time.deltaTime));
            this.direction = 1;
        }
        else if (Input.GetKey(paddleDownKey)) {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y - (this.speed * Time.deltaTime));
            this.direction = -1;
        }
        else {
            this.direction = 0;
        }

        if (transform.position.y > this.upperLimit.position.y) {
            transform.position = new Vector3(
                transform.position.x, this.upperLimit.position.y, transform.position.z);
        }
        else if(transform.position.y < this.lowerLimit.position.y) {
            transform.position = new Vector3(
                transform.position.x, this.lowerLimit.position.y, transform.position.z);
        }
    }

    void OnCollisionExit2D (Collision2D other) {
        other.rigidbody.velocity = new Vector2(
            other.rigidbody.velocity.x * 1.1f,
            other.rigidbody.velocity.y + (this.adjustSpeed * this.direction));
        Debug.Log(other.rigidbody.velocity);
    }
}
