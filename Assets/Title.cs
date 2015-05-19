using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){

		if (GUI.Button(new Rect(Screen.width/1.55f, Screen.height/1.5f, 100, 40), "Start"))
		{
			Application.LoadLevel("Voice");
		}
		if (GUI.Button(new Rect(Screen.width/1.55f, Screen.height/1.3f, 100, 40), "Quit"))
		{
			Application.Quit ();
		}
		
		
	}
}
