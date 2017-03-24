﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    public float speed;

    private int direction;
    public float adjustSpeed;

    public Transform upperLimit;
    public Transform lowerLimit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W)) {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y + (this.speed * Time.deltaTime),
                0);
            this.direction = 1;
        }
        else if (Input.GetKey(KeyCode.S)) {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y - (this.speed * Time.deltaTime),
                0);
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

    void OnCollisionExit2D(Collision2D other) {
        other.rigidbody.velocity = new Vector2(
            other.rigidbody.velocity.x * 1.1f,
            other.rigidbody.velocity.y + (this.adjustSpeed * this.direction));
        Debug.Log(other.rigidbody.velocity);
    }
}
