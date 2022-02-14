using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjectTeeth : MonoBehaviour {

	[SerializeField]
	private Transform myPlace;

	private Vector2 initialPosition;

	private Vector2 mousePosition;

	private Vector2 currentPosition;

	private float deltaX, deltaY;

	public static bool locked;

	private bool rightTrend;
	private bool upTrend;

	public AudioSource SFX1;
	public AudioSource SFX2;

	public bool isPlaque;
	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		locked = false;
		rightTrend = true;
		upTrend = true;
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
		if ((Mathf.Abs (currentPosition.x - mousePosition.x) > 5) || Mathf.Abs(currentPosition.y - mousePosition.y)>5) {
			currentPosition = mousePosition;
		}
		mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = new Vector2 (mousePosition.x - deltaX, mousePosition.y - deltaY);

		if (isPlaque) {
			if (rightTrend) {
				if (mousePosition.x < currentPosition.x) {
					rightTrend = false;
					if (!SFX1.isPlaying) {
						SFX1.Stop ();
						SFX1.Play ();
					}
				}
			} else {
				if (mousePosition.x > currentPosition.x) {
					rightTrend = true;
					if (!SFX2.isPlaying) {
						SFX2.Stop ();
						SFX2.Play ();
					}
				}
			}
		} else {
			if (upTrend) {
				if (mousePosition.x < currentPosition.x) {
					upTrend = false;
					SFX1.Play ();
				}
			} else {
				if (mousePosition.x > currentPosition.x) {
					upTrend = true;
					SFX2.Play ();
				}
			}
		}
	}

	private void OnMouseUp()
	{
		transform.position = new Vector2 (initialPosition.x, initialPosition.y);
	}
}
