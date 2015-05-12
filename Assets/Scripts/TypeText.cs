using UnityEngine;
using System.Collections;

public class TypeText : MonoBehaviour {

	public float letterPause = 0.5f;
	bool npcTalk, playerTalk;
	string textDisplayed;
	string npcName;
	//declare appropriate variables, blah blah blah


	TypeText(){
		npcTalk = false;
		playerTalk = false;
		textDisplayed = "";
		npcName = "";
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
	
	IEnumerator TypeHelper (string line, bool player, bool npc, string npcNm)  //responsible for printing each letter individually
	{
		textDisplayed = "";
		npcTalk = npc;
		playerTalk = player;
		npcName = npcNm;
		foreach (char letter in line.ToCharArray())
			//the line referred to here is the same line referred to in DialogueBox.cs
		{
			//this entire foreach loop is responsible for printing the message string
			//if (sound)
			//	audio.PlayOneShot (sound); 
			//for example, a typewriter sound, set in editor
			textDisplayed = textDisplayed + letter;
			//yield return 0;
			yield return new WaitForSeconds (letterPause); 
			//speed of printing, set in editor
		}
	}	
	
	public void Type(string line, bool player, bool npc, string npcNm)
	{
		//this is the method called by the DialogueBox.cs when typing out the first line
		StartCoroutine(TypeHelper (line, player, npc, npcNm));//calls method to type script	
		
	}

}
