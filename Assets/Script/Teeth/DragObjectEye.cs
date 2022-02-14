using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjectEye : MonoBehaviour {

	[SerializeField]
	private Transform myPlace;

	private Vector2 initialPosition;

	public Vector2 mousePosition;

	public Vector2 currentPosition;

	private float deltaX, deltaY;

	public static bool locked;

	private bool rightTrend;
	private bool upTrend;

	public AudioSource SFX1;
	public AudioSource SFX2;

	private int x;
	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		locked = false;
		rightTrend = true;
		upTrend = true;
		currentPosition = new Vector2 (0, 0);
	}
		

	private void OnMouseDown()
	{
		if (!locked) {
			deltaX = Camera.main.ScreenToWorldPoint (Input.mousePosition).x - transform.position.x;
			deltaY = Camera.main.ScreenToWorldPoint (Input.mousePosition).y - transform.position.y;
			currentPosition = mousePosition;
		}
	}

	private void OnMouseDrag()
	{
		if ((Mathf.Abs (currentPosition.x - mousePosition.x) > 1.5f) || Mathf.Abs(currentPosition.y - mousePosition.y)>3) {
			x++;
			Debug.Log ("INI: " + x);
			currentPosition = mousePosition;
		}
		mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = new Vector2 (mousePosition.x - deltaX, mousePosition.y - deltaY);

		if (mousePosition.x > -5f && mousePosition.y > -3) {
			if (rightTrend) {
				if (mousePosition.x < currentPosition.x) {
					rightTrend = false;
					SFX1.Play ();
				}
			} else {
				if (mousePosition.x > currentPosition.x) {
					rightTrend = true;
					SFX2.Play ();
				}
			}

			if (upTrend) {
				if ((mousePosition.y+1) < currentPosition.y) {
					upTrend = false;
					if (!SFX1.isPlaying) {
						SFX1.Play ();
					}
				}
			} else {
				if ((mousePosition.y-1) > currentPosition.y) {
					upTrend = true;
					if (!SFX2.isPlaying) {
						SFX2.Play ();
					}
				}
			}	
		}
	}

	private void OnMouseUp()
	{
		transform.position = new Vector2 (initialPosition.x, initialPosition.y);
	}
}
