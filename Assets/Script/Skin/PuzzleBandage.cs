using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBandage : MonoBehaviour {

	private float deltaX, deltaY;
	private Vector2 mousePosition;
	private Vector2 initialPosition;
	public SkinManager theSkin;
	//private PuzzleManager myManager;

	public bool released;
	//public MissingBandage myMiss;

	// Use this for initialization
	void Start () {
		theSkin = FindObjectOfType<SkinManager> ();
		released = true;
		initialPosition = transform.position;
		//myManager = FindObjectOfType<PuzzleManager> ();
	}

	// Update is called once per frame
	void Update () {
		//if (myMiss.mySprite.color.r == 1) {
			//myManager.counter++;
			//Destroy (gameObject);
		//}
	}

	private void OnMouseDown()
	{
		transform.localScale = new Vector2 (0.7f, 0.7f);
		deltaX = Camera.main.ScreenToWorldPoint (Input.mousePosition).x - transform.position.x;
		deltaY = Camera.main.ScreenToWorldPoint (Input.mousePosition).y - transform.position.y;
		theSkin.released = false;
	}

	private void OnMouseDrag()
	{
		mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = new Vector2 (mousePosition.x - deltaX, mousePosition.y - deltaY);
		theSkin.released = false;
	}

	private void OnMouseUp()
	{
		transform.localScale = new Vector2 (0.30f, 0.33f);
		transform.position = new Vector2 (initialPosition.x, initialPosition.y);
		theSkin.released = true;
	}
}
