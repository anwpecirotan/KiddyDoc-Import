using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RontgenController : MonoBehaviour {

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
		transform.position = new Vector2 (initialPosition.x, initialPosition.y);
		released = true;
	}
}
