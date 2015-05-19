using UnityEngine;
using System.Collections;

public class EndCard : MonoBehaviour {
	public bool show = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		if (show == true){
		
			if (GUI.Button(new Rect(Screen.width/4f, Screen.height/1.5f, 100, 40), "Menu"))
			{
				Application.LoadLevel("Title");
			}
			if (GUI.Button(new Rect(Screen.width/1.6f, Screen.height/1.5f, 100, 40), "Quit"))
			{
				Application.Quit ();
			}
		}
	}
	void Show(){
		show = true;
	}
}
