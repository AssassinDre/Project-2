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
	bool check = true;
	string npcName;

	bool option2 = false, option3 = false, choice = false;


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
		GUI.skin.box.wordWrap = true;
		if (npcTalk) {
			GUI.Box (new Rect (Screen.width - 300, Screen.height - 100, 300, 100), textDisplayed);
			GUI.Box (new Rect (Screen.width - 150, Screen.height - 150, 150, 50), npcName);
		}
		if (playerTalk) {
			GUI.Box (new Rect (0, Screen.height - 100, 300, 100), textDisplayed);
			GUI.Box (new Rect (0, Screen.height - 150, 150, 50), "Player");
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
			print(tag);
			checkFile(tag);
		}

		if (PlayerMove2.collected && check) {
			GameObject Text2 = GameObject.FindWithTag("Text2");
			Text2.tag = Text2.tag + "A";
			print (Text2.tag);
			check = false;
		}
	}

	void checkFile(string start)
	{

		int length = dialogLines.GetLength(0);
		//print (length);
		for (int i = 0; i < length; ++i) {
			string temp = dialogLines[i];
			//Debug.Log(temp.Equals(tag));
			//print(temp);
			if (temp.Equals(tag))
			{
				PlayerMove2.isPaused = true;
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
			temp = dialogLines [line];
			npcName = temp;
			npcTalk = true;
			//Debug.Log("Proceed1");
			StartCoroutine(npcTalking (line));
		}
		if (temp.Contains("Player"))
		    {
			temp = dialogLines [line];
			npcName = temp;
			StartCoroutine(npcTalking (line));
			//playerTalk = true;
			//playerTalking(line);
		}
		if (temp.Equals("End")){
	
		}


	}

	IEnumerator npcTalking(int line)
	{
		string temp;
		while (true) {
			choice = false;
			option2 = false;
			option3 = false;
			line++;
			temp = dialogLines [line];
			//print ("TEMP:" + temp);
			print (temp);

			if (temp.Contains ("Player"))
			{

				playerTalk = true;
				npcTalk=false;
				line++;
				temp = dialogLines [line];
			}
			if (temp.Contains ("NPC"))
			{
				playerTalk = false;
				npcTalk= true;

				line++;
				temp = dialogLines [line];
			}
			if (temp.Contains ("End"))
			{
				playerTalk = false;
				npcTalk= false;
				talking = false;
				PlayerMove2.isPaused = false;
				return true;
			}
			if (temp.Contains ("PickOption"))
			{
				choice = true;
				line++;
				temp = dialogLines [line];
				print ("TEMP:" + temp);
			}
			textDisplayed = temp;
			//StartCoroutine(MyCoroutine());
			yield return new WaitForSeconds(0.5f);
			yield return StartCoroutine (WaitForKeyPress ("space"));
			_keyPressed = false;
			if (choice)
			{
				if (option2) line = line + 10;
				if (option3) line = line + 20;
			}
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
			if(Input.GetKeyDown(KeyCode.Y))
			{
				_keyPressed = true;
				option2 = true;
				//print("Pressed.");
				break;
			}
			if(Input.GetKeyDown(KeyCode.U))
			{
				_keyPressed = true;
				option3 = true;
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
