using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Dialouge : MonoBehaviour {
	//StreamReader reader = new StreamReader("file.txt");
	bool talk = false, talking = false, npcTalk = false, playerTalk = false, proceed = false;
	private Vector2 pos;

	public TextAsset textFile;
	string[] dialogLines;
	string textDisplayed;

	string tag;
	// Use this for initialization
	void Start () {
		pos = transform.position;
		string text = textFile.text;
		if(textFile != null)
		{
			// Add each line of the text file to
			// the array using the new line
			// as the delimiter
			dialogLines = Regex.Split(text, "\r\n");
		}
	}

	void OnGUI()
	{
		if (npcTalk) GUI.Box(new Rect(110, 110, Screen.width/2, 100), textDisplayed);
		if (playerTalk) GUI.Box(new Rect(110, 110, Screen.width/2, 100), textDisplayed);
		if (talking) {
			if (GUI.Button (new Rect((Screen.width)/2,(Screen.height)/2,140,70), "Proceed"))
			{
				proceed = true;
			}
		}
	}
	
	void OnTriggerEnter(Collider other) {
		tag = other.tag;
		talk = true;
	}

	void OnTriggerExit(Collider other)
	{
		talk = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W) && talk){
			checkFile(tag);
		}
	}

	void checkFile(string start)
	{
		int length = dialogLines.GetLength(0);
		for (int i = 0; i < length; ++i) {
			string temp = dialogLines[i];
			//Debug.Log(temp.Equals(tag));
			if (temp.Equals(tag))
			{
				talking = true;
				textDisplayed = temp;
				readDialog(i);
			}
		}
		talk = false;
	}

	void readDialog(int line)
	{
		string temp = dialogLines [line+1];
		Debug.Log(temp);
		if (temp.Contains ("NPC")) {
			npcTalk = true;
			Debug.Log("Proceed1");
			StartCoroutine(npcTalking (line));
		}
		if (temp.Equals("Player"))
		    {
			playerTalk = true;
			playerTalking(line);
		}
		if (temp.Equals("End")){

		}


	}

	IEnumerator npcTalking(int line)
	{
		string temp;
		while (true) {
			line++;
			temp = dialogLines [line];
			print ("TEMP:" + temp);
			if (temp.Equals ("Player"))
			{
				playerTalk = true;
				npcTalk=false;
			}
			textDisplayed = temp;
			//StartCoroutine(MyCoroutine());
			yield return new WaitForSeconds(1);
			yield return StartCoroutine (WaitForKeyPress ("space"));
			_keyPressed = false;
			//Debug.Log ("Proceed2");
		}

	}

	bool _keyPressed = false;

	public IEnumerator WaitForKeyPress(string _button)
	{
		while(!_keyPressed)
		{
			if(Input.GetKeyDown(KeyCode.T))
			{
				_keyPressed = true;
				//print("Pressed.");
				break;
			}
			//print("Awaiting key input.");
			yield return 0;
		}
	}


	IEnumerator playerTalking(int line)
	{
		string temp = dialogLines [line];
		if (temp.Equals("npc")) playerTalking(line);
		textDisplayed = temp;
		while (!Input.GetKeyDown(KeyCode.Space))
		{
			yield return null;
		}

		playerTalking (line);
	}
	
}
