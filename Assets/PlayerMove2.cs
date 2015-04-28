using UnityEngine;
using System.Collections;

public class PlayerMove2 : MonoBehaviour {

	static public bool isPaused = false;
	private Vector2 pos;
	public float speed = 1f;
	DoorMove doorMove;
	public GameObject Door1A, Door1B, Door2A, Door2B;
	public bool moving = false;
	bool door = false;
	bool displayInven = false;
	static public bool collected = false;
	public Texture2D dummyInventory;
	
	// Use this for initialization
	void Start () {
		pos = transform.position;
		doorMove = new DoorMove ();
	}

	void OnGUI()
	{
		GUIStyle myLabelStyle = new GUIStyle(GUI.skin.label);
		myLabelStyle.normal.textColor = Color.red;
		myLabelStyle.fontSize = 50;




		if (displayInven) {
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Dummy Inventory Screen");
			if (collected) {
				GUI.DrawTexture (new Rect(100, 100, 100, 100), dummyInventory);
			}
		}


	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (Input.mousePosition);
		checkInput ();
		//Debug.Log("Moving: " + moving);
		//Debug.Log("Door: " + door);
	}

	void OnTriggerEnter(Collider other) {
		moving = true;
		if (other.tag == "Collectable") {
			Destroy (other.gameObject);
			collected = true;
			//Debug.Log (collected);
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Door1A" && door == true) {
			transform.position = Door1B.transform.position;
		}

		if (other.gameObject.tag == "Door1B" && door == true) {
			transform.position = Door1A.transform.position;
		}

		if (other.gameObject.tag == "Door2A" && door == true) {
			transform.position = Door2B.transform.position;
		}
		
		if (other.gameObject.tag == "Door2B" && door == true) {
			transform.position = Door2A.transform.position;
		}
	}

	void OnTriggerExit(){
		moving = false ;
		door = false;
	}

	
	
	private void checkInput(){
		
		if (Input.GetKeyDown (KeyCode.Escape)) {
			isPaused = true;
		}

		if (Input.GetKeyDown (KeyCode.I)) {
			if (isPaused == false) isPaused = true;
			else if (isPaused == true) isPaused = false;
			if (displayInven == false) displayInven = true;
			else if (displayInven == true) displayInven = false;
		}

		if (!isPaused) {
			if (Input.GetKey (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
				//Debug.Log ("Acitavated");
				transform.position += Vector3.right * speed * Time.deltaTime;
			}
			// For left, we have to subtract the direction
			else if (Input.GetKey (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
				transform.position -= Vector3.right * speed * Time.deltaTime;
			}
			else if (Input.GetKey (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) {
				if (moving == true)
				{
					door = true;
					//Debug.Log ("Worked");
				}

			}
			
			// Same as for the left, subtraction for down
			else if (Input.GetKey (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) {
				
			}
		}
	}
}
