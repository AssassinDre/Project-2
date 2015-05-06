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


	void Start () {

		//Records player position, and transfers speech data from file to array
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


	//When you approach an NPC collider, the talk variable is set to true
	//And that NPC's tag is recorded
	
	void OnTriggerEnter(Collider other) {
		tag = other.tag;
		talk = true;
	}

	//When you leave, talk is set to false

	void OnTriggerExit(Collider other)
	{
		talk = false;
	}
	
	//The tag is then used in the checkFile method to see who we are talking to
	void Update () {

		if (Input.GetKey (KeyCode.W) && talk){
			print(tag);
			checkFile(tag);
		}


		//Example of how this system has NPC's display alternate dialog.
		//If a certain condition is met (in this case, a collectable in the move class is collected)
		//Then the code will search for the tag of the NPC whoose dialog changes
		//And then changes the tag
		//Due to the way the dialog system works, this will change what the NPC says
		//Reasonably elegant and efficient, if a bit hard-code-y
		//The check variable is present so this change only happens once, and not over and over
		if (PlayerMove2.collected && check) {
			GameObject Text2 = GameObject.FindWithTag("Text2");
			Text2.tag = Text2.tag + "A";
			print (Text2.tag);
			check = false;
		}
	}

	void checkFile(string start)
	{
		//Start at the beginning of the file
		int length = dialogLines.GetLength(0);

		for (int i = 0; i < length; ++i) {
			//Search through the file, and when the tag variable of the NPC you are interacting with matches the line
			string temp = dialogLines[i];

			//Halt player movement, set relevant variables, and read the dialog
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
		//Debug.Log(temp);

		//Depending on who is talking first, the relevant dialog box is displayed
		//In both cases, starts the dialog coroutine
		if (temp.Contains ("NPC")) {
			temp = dialogLines [line];
			npcName = temp;
			//npcTalk = true;
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
			//print (temp);

			//Bool variables display relevant dialog boxes depending on who is talking
			//Then fetches the first line of dialog from that character
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

			//If file reads end, ends the conversation
			if (temp.Contains ("End"))
			{
				playerTalk = false;
				npcTalk= false;
				talking = false;
				PlayerMove2.isPaused = false;
				return true;
			}

			//Leads into multiple dialog choice
			if (temp.Contains ("PickOption"))
			{
				choice = true;
				line++;
				temp = dialogLines [line];
				print ("TEMP:" + temp);
			}
			textDisplayed = temp;
			//Waits so that dialog flows properly
			yield return new WaitForSeconds(0.5f);
			//And does not progress until player hits key
			yield return StartCoroutine (WaitForKeyPress ());
			_keyPressed = false;

			//If a multiple dialog tree, goes through file to find the right dialog tree
			//Was having issues with .equals, so using .contains
			//Can have issues if we ever use the string of characters in it,
			//But if so, we just change the delimiters
			//Easy fix
			if (choice)
			{
				if (option2)
				{
					bool found = false;
					while(!found)
					{
						line++;
						if (dialogLines[line].Contains("010")) 
						{
							found = true;
							//line++;
						}
					}
					//line = line + 10;
				}
				if (option3)
				{
					bool found = false;
					while(!found)
					{
						line++;
						if (dialogLines[line].Contains("001")) 
						{
							found = true;
							//line++;
						}
					}
					//line = line + 10;
				}
			}
			//Debug.Log ("Proceed2");
		}

	}

	bool _keyPressed = false;

	//Waits for player to press key
	//If a dialog choice, lets player pick choice
	public IEnumerator WaitForKeyPress()
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


	/*IEnumerator playerTalking(int line)
	{
		string temp = dialogLines [line];
		if (temp.Equals("npc")) playerTalking(line);
		textDisplayed = temp;
		while (!Input.GetKeyDown(KeyCode.Space))
		{
			yield return null;
		}

		playerTalking (line);
	}*/
	
}
