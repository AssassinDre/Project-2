using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {
	public int score = 0;
	int[] items;
	public bool criticalMet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake (){
			DontDestroyOnLoad(gameObject);
		}
		
}
