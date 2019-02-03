using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour {
    public float movementSpeed = 2.0f;
	// Use this for initialization

	 public float delta = -10.2f;  // Amount to move left and right from the start point
     public float speed = 0.2f; 
     private Vector3 startPos;

	void Start () 
	{
		   startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
       Vector3 v = startPos;
         v.y += delta * Mathf.Sin (Time.time * speed);
         transform.position = v;
	}
}
