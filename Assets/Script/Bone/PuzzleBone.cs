using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBone : MonoBehaviour {

	private float deltaX, deltaY;
	private Vector2 mousePosition;
	private Vector2 initialPosition;
	private PuzzleManager myManager;

	public bool released;
	public MissingBone myMiss;
	private AudioSource mySFX;
	private SpriteRenderer mySprite;
	private bool isActive;
	// Use this for initialization
	void Start () {
		isActive = true;
		released = true;
		mySFX = GetComponent<AudioSource> ();
		initialPosition = transform.position;
		myManager = FindObjectOfType<PuzzleManager> ();
		mySprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (myMiss.mySprite.color.r == 1 && isActive) {
			isActive = false;
			myManager.counter++;
			StartCoroutine ("DestroyMe");
		}
	}

	private void OnMouseDown()
	{
		if (isActive) {
			deltaX = Camera.main.ScreenToWorldPoint (Input.mousePosition).x - transform.position.x;
			deltaY = Camera.main.ScreenToWorldPoint (Input.mousePosition).y - transform.position.y;
			released = false;
			transform.localScale = new Vector3 (0.7f, 0.7f, 1);
		}
	}

	private void OnMouseDrag()
	{
		if (isActive) {
			mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			transform.position = new Vector2 (mousePosition.x - deltaX, mousePosition.y - deltaY);
			released = false;
		}
	}

	private void OnMouseUp()
	{
		transform.position = new Vector2 (initialPosition.x, initialPosition.y);
		released = true;
		transform.localScale = new Vector3 (0.48f, 0.48f, 1);
	}

	public IEnumerator DestroyMe()
	{
		mySprite.color = new Color (1, 1, 1, 0);
		mySFX.Play ();
		yield return new WaitForSeconds (1);
		Destroy (gameObject);
	}
}
