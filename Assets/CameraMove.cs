using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	public GameObject player;
	
	public Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = new Vector3(0f, 0f, -20f);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
