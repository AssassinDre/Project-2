using UnityEngine;
using System.Collections;

public class loadNext : MonoBehaviour {
	public PlayerScore scoreKeeper;
	public MeshCollider collider1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreKeeper.criticalMet)
		{
			collider1.enabled = false;
		}
	}
}