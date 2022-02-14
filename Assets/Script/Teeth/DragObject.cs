using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {

	[SerializeField]
	private Transform myPlace;

	private Vector2 initialPosition;

	private Vector2 mousePosition;

	private float deltaX, deltaY;

	public static bool locked;

	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		locked = false;
	}

	private void OnMouseDown()
	{
		if (!locked) {
			deltaX = Camera.main.ScreenToWorldPoint (Input.mousePosition).x - transform.position.x;
			deltaY = Camera.main.ScreenToWorldPoint (Input.mousePosition).y - transform.position.y;
		}
	}

	private void OnMouseDrag()
	{
		if (!locked) {
			mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			transform.position = new Vector2 (mousePosition.x - deltaX, mousePosition.y - deltaY);
		}
	}

	private void OnMouseUp()
	{
		//if (Mathf.Abs (transform.position.x - myPlace.position.x) <= 0.5f &&
		//  Mathf.Abs (transform.position.y - myPlace.position.y) <= 0.5f) {
		//	transform.position = new Vector2 (myPlace.position.x, myPlace.position.y);
		//	locked = true;
		//} else {
			transform.position = new Vector2 (initialPosition.x, initialPosition.y);
		//}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
