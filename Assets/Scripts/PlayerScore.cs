using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {
	public int score = 0;
	public int[] items;
	public bool criticalMet;
	string tag;
	public Item newspapers;
	public Item syringe;
	public Item bullets;
	public Item knife;
	public Item cash;
	public Item phone;
	public Item gun;
	// Use this for initialization
	void Start () {
		items = new int[7] {0,0,0,0,0,1,1};
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
		if (items[5] == 1)
			phone.render.enabled = true;
		if (items[6] == 1)
			gun.render.enabled = true;

	
	}

	void Awake (){
			DontDestroyOnLoad(gameObject);
		}
}