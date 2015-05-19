using UnityEngine;
using System.Collections;

public class Load2 : MonoBehaviour {
	public PlayerScore scoreKeeper;
	public bool triggerred = false;

	void Start()
	{
		scoreKeeper = (PlayerScore) FindObjectOfType (typeof(PlayerScore));
	}

	void OnTriggerEnter(Collider other)
	{
		if (scoreKeeper.criticalMet == true) 
		{
			scoreKeeper.criticalMet = false;
			//Application.LoadLevel(Application.loadedLevel + 1);
			triggerred = true;
		}
	}

}
