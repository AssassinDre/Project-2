using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	public SpriteRenderer render;
	// Use this for initialization
	void Start () {
		render.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake(){
		DontDestroyOnLoad (this);
		}
}
