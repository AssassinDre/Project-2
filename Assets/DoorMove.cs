using UnityEngine;
using System.Collections;

public class DoorMove : MonoBehaviour {


	GameObject Door1B = GameObject.FindGameObjectWithTag("Door1B");
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public Vector3 checkDoor(Vector3 pos, GameObject Door1A){
		//GameObject Door1A = GameObject.Find ("Respawn");
		if (pos == Door1A.transform.position) {
			return Door1A.transform.position;
		}
		return Door1A.transform.localScale;
	}
}
