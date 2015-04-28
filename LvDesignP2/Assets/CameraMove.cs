using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	public GameObject player;
	public float x;
	public float y;
	
	public Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = new Vector3(x, y, -20f);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (player.transform.position.x < 5.15f && player.transform.position.x > -4.965){
			transform.position = player.transform.position + offset;
		}
	}
}
