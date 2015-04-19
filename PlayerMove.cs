using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	//********************ANIMATION CODE TO BE ADDED********************

	public float speed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//right movement
		if (Input.GetKey ("right")) 
		{
			rigidbody2D.AddForce(Vector2.right* speed);
		}
		//left movement
		if (Input.GetKey("left"))
		{
			rigidbody2D.AddForce(-Vector2.right* speed);
		}
}
}