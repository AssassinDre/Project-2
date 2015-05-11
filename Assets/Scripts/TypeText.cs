using UnityEngine;
using System.Collections;

public class TypeText : MonoBehaviour {

	//declare appropriate variables, blah blah blah
	
	IEnumerator TypeText ()  //responsible for printing each letter individually
	{
		foreach (char letter in line.ToCharArray())
			//the line referred to here is the same line referred to in DialogueBox.cs
		{
			//this entire foreach loop is responsible for printing the message string
			guiText.text += letter;
			if (sound)
				audio.PlayOneShot (sound); 
			//for example, a typewriter sound, set in editor
			yield return 0;
			yield return new WaitForSeconds (letterPause); 
			//speed of printing, set in editor
		}
	}	
	
	public void Type()
	{
		//this is the method called by the DialogueBox.cs when typing out the first line
		StartCoroutine(TypeText ());//calls method to type script	
		
	}

}
