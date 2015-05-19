using UnityEngine;
using System.Collections;

public class loadNext : MonoBehaviour {
	PlayerScore scoreKeeper;
	public MeshCollider collider1;

	// Use this for initialization
	void Start () {
		scoreKeeper = (PlayerScore) FindObjectOfType (typeof(PlayerScore));
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreKeeper.criticalMet)
		{
			collider1.enabled = false;
		}
	}
}