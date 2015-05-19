using UnityEngine;
using System.Collections;

public class PlayerPickup : MonoBehaviour {
	PlayerScore scoreKeeper;
	string tag;
	bool pickup = false;
	GameObject item;

	// Use this for initialization
	void Start () {
		scoreKeeper = (PlayerScore)FindObjectOfType (typeof(PlayerScore));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.E) && pickup) {
			if (tag == "Newspapers")
				scoreKeeper.items [0] = 1;
			else if (tag == "Syringe")
				scoreKeeper.items [1] = 1;
			else if (tag == "Bullets")
				scoreKeeper.items [2] = 1;
			else if (tag == "Money")
				scoreKeeper.items [4] = 1;
			else if (tag == "Knife")
				scoreKeeper.items [3] = 1;
			Destroy (item);
		}
	
	}

	void OnTriggerEnter(Collider other)
	{
		tag = other.tag;
		pickup = true;
		item = other.gameObject;
	}

	void OnTriggerExit(Collider other)
	{
		pickup = false;
	}

}
