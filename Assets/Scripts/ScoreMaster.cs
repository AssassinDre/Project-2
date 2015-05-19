using UnityEngine;
using System.Collections;

public class ScoreMaster : MonoBehaviour {
	public Dialouge dia;
	public PlayerScore scoreKeeper;
	// Use this for initialization
	void Start () {
		scoreKeeper = (PlayerScore)FindObjectOfType (typeof(PlayerScore));
	}

	public void getKnifeFromNPC()
	{
		scoreKeeper.items [3] = 1;
	}

	public void checkCritical()
	{
		string tag = dia.tag;
		if (tag == "Bartender" || tag == "Boy" || tag == "Reporter" || tag == "Dancer" || tag == "Young Man" || tag == "Woman" || tag == "Dealer" || tag == "Gang Member")
			scoreKeeper.criticalMet = true;
	}

	public void Score(int choiceVal)
	{
		string tag = dia.tag;
		if (tag == "Bartender") {
			if(choiceVal == 1)
				scoreKeeper.score++;
			else if(choiceVal == 2)
				scoreKeeper.score--;
		}
		if (tag == "Scruffy Man") {
			if(choiceVal == 1)
				scoreKeeper.score--;
			else if(choiceVal == 2)
				++scoreKeeper.score;
		}
		if (tag == "Boy") {
			if(choiceVal == 1)
				++scoreKeeper.score;
			else if(choiceVal == 2)
				scoreKeeper.score--;
		}
		if (tag == "Girl") {
			if(choiceVal == 1)
				scoreKeeper.score--;
			else if(choiceVal == 2)
				++scoreKeeper.score;
		}
		if (tag == "Reporter") {
			if(choiceVal == 1)
				++scoreKeeper.score;
			else if(choiceVal == 2)
				scoreKeeper.score--;
		}
		if (tag == "Dancer") {
			if(choiceVal == 1)
				scoreKeeper.score--;
			else if(choiceVal == 2)
				++scoreKeeper.score;
		}
		if (tag == "Older Lady") {
			if(choiceVal == 1)
				++scoreKeeper.score;
			else if (choiceVal == 2)
				scoreKeeper.score--;
		}
		print(scoreKeeper.score);
	}
}
