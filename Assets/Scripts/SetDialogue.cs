using UnityEngine;
using System.Collections;

public class SetDialogue : MonoBehaviour {

	//allow a string[]lines and a string[]lines2 to be set publicly in the editor
	
	//blah blah blah code
	
	void SetLines()
	{
	//	DialogBox.lines = lines;
	//	DialogBox.lines2 = lines2;
		
		//You decide when SetLines fires.  When it does, it will plug in the lines contained //inside it into DialogueBox.cs
	}
	
	
	//For me, I use raycasting and collision to determine when SetLines fires. It continuously fires until the ray being cast from the player is no longer colliding with the GameObject containing the dialogue.

}
