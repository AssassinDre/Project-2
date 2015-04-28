using UnityEngine;
using System.Collections;

public class ToolTips : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnGUI()
	{
		Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		if (Vector2.Distance(mousePosition, new Vector2(100f, Screen.height-100)) < 100)
		{
			//	GUI.DrawTexture (new Rect(100, 100, 100, 100), dummyInventory);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
