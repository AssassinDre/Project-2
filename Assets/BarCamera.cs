using UnityEngine;
using System.Collections;

public class BarCamera : MonoBehaviour {

	public GameObject player;
	
	public Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = new Vector3(0f, 1.15f, -20f);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (player.transform.position.x > 0f && player.transform.position.x <10.1f){
			transform.position = player.transform.position + offset;
		}
	}
}
