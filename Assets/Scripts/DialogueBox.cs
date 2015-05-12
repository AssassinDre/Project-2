using UnityEngine;
using System.Collections;

public class DialogueBox : MonoBehaviour {

	bool canTalk;
	int i = 0;
	string[] lines;
	string[] lines2;

	// Use this for initialization
	void Start () 
	{
		canTalk = false;
	}
	
	void Update () 
	{
		if(canTalk == true) //canTalk is true when you are able to talk to someone
		{
			if (Input.GetKeyUp(KeyCode.X)) //in this case, the X key begins dialogue
			{
			//	typeText.guiText.text = ""; //clears first line
			//	typeText2.guiText.text = ""; //clears second line
				
				if(i < lines.Length) //if there are still more lines to be printed
				{
					renderer.enabled = true; //keep dialogue sprite visible
					printLines(lines, lines2); //prints dialogue on screen
					//printLines is included further below
				}
				else
				{		
					renderer.enabled = false; //hide dialog box
					i = 0; 
					
				}
			}
		}
	}
	public void printLines(string[] lines, string[] lines2)
	{
	//	TypeText.line = lines[i];  //assigns lines to first line
		//refers to TypeText.cs which is responsible for printing the first line
		
	//	TypeText2.line = lines2[i];  //assign lines2 to second line
		//refers to TypeText.cs which is responsible for printing the second line
		
	//	TypeText.Type();  //prints first line
	//	TypeText2.Type();  //prints second line, currently fires at same time as first line
	//	
		if (i < lines.Length)
		{
			i++;
		}		
	}

}
