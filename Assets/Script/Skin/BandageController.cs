using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandageController : MonoBehaviour {

	private float deltaX, deltaY;
	private Vector2 mousePosition;
	private Vector2 initialPosition;

	public bool released;

	// Use this for initialization
	void Start () {
		released = true;
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown()
	{
		deltaX = Camera.main.ScreenToWorldPoint (Input.mousePosition).x - transform.position.x;
		deltaY = Camera.main.ScreenToWorldPoint (Input.mousePosition).y - transform.position.y;
		released = false;
	}

	private void OnMouseDrag()
	{
		mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = new Vector2 (mousePosition.x - deltaX, mousePosition.y - deltaY);
		released = false;
	}

	private void OnMouseUp()
	{
		//if (Mathf.Abs (transform.position.x - myPlace.position.x) <= 0.5f &&
		//  Mathf.Abs (transform.position.y - myPlace.position.y) <= 0.5f) {
		//	transform.position = new Vector2 (myPlace.position.x, myPlace.position.y);
		//	locked = true;
		//} else {
		transform.position = new Vector2 (initialPosition.x, initialPosition.y);
		released = true;
		//}
	}
}
