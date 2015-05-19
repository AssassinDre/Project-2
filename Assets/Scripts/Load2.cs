using UnityEngine;
using System.Collections;

public class Load2 : MonoBehaviour {
	public PlayerScore scoreKeeper;
	public bool triggerred = false;
	public string killPath;
	public string goodPath;

	void Start()
	{
		scoreKeeper = (PlayerScore) FindObjectOfType (typeof(PlayerScore));
	}

	void OnTriggerEnter(Collider other)
	{
		if (scoreKeeper.criticalMet == true) 
		{
			scoreKeeper.criticalMet = false;
			if (scoreKeeper.score <= 0)
				Application.LoadLevel(killPath);
			else
				Application.LoadLevel(goodPath);
			triggerred = true;
		}
	}

}
