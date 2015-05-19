using UnityEngine;
using System.Collections;

public class itemCheck : MonoBehaviour {
	public Dialouge dia;
	public PlayerScore scoreKeeper;
	// Use this for initialization
	void Start () {
		scoreKeeper = (PlayerScore)FindObjectOfType (typeof(PlayerScore));
	}
	
	public void checkItem(string tag)
	{
		if (tag == "Angry Girl") {
			if (scoreKeeper.items[0] == 1)
				dia.tag = "Girl";
				}
		if (tag == "Woman") {
			if (scoreKeeper.items[1] == 1)
				dia.tag = "Dealer";
				}
	}
}
