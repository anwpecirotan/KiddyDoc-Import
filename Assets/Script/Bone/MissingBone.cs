using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingBone : MonoBehaviour {

	public bool active;
	public PuzzleBone theBone;
	public SpriteRenderer mySprite;
	public bool wrapped;

	public string expectedName;
	// Use this for initialization
	void Start () {
		mySprite = GetComponent<SpriteRenderer> ();
		active = false;
		wrapped = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (active && theBone.released == true && wrapped == false) {
			mySprite.color = new Color (1, 1, 1, 1);
			wrapped = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == expectedName) {
			active = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == expectedName) {
			active = false;
		}
	}
}
