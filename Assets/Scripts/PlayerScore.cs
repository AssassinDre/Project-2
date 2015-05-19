using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {
	public int score = 0;
	public int[] items;
	public bool criticalMet;
	string tag;
	public GUISkin nameBox = null;
	public Item newspapers;
	public Item syringe;
	public Item bullets;
	public Item knife;
	public Item cash;
	// Use this for initialization
	void Start () {
		items = new int[5];
	}
	
	// Update is called once per frame
	void Update () {
		if (items[0] == 1)
			newspapers.render.enabled = true;
		if (items[1] == 1)
			syringe.render.enabled = true;
		if (items[2] == 1)
			bullets.render.enabled = true;
		if (items[3] == 1)
			knife.render.enabled = true;
		if (items[4] == 1)
			cash.render.enabled = true;

	
	}

	void Awake (){
			DontDestroyOnLoad(gameObject);
		}

	void OnGUI ()
	{
		GUI.skin = nameBox;
		GUI.Box (new Rect (0, 0, 600, 100), "");
		
	}
}