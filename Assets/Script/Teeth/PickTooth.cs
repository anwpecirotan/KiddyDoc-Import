using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickTooth : MonoBehaviour {

	public bool broken;
	public GameObject crack;
	public SpriteRenderer mySprite;
	private Vector2 mousePosition;
	private float deltaX, deltaY;
	private Rigidbody2D myBody;
	private ToothManager myManager;
	private BoxCollider2D myBox;

	public AudioSource mySfx;
	private int pluggedOut;
	public Sprite brokenTooth;
	// Use this for initialization
	void Start () {
		myBox = GetComponent<BoxCollider2D> ();
		mySfx = GetComponent<AudioSource> ();
		mySprite = GetComponent<SpriteRenderer> ();
		myBody = GetComponent<Rigidbody2D> ();
		myManager = FindObjectOfType<ToothManager> ();
		if (broken) {
			mySprite.sprite = brokenTooth;
		}
	}

	private void OnMouseDown()
	{
        if(broken)
        {
            if (myManager.pickable)
            {
                deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
                deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
            }
        }
	}

	private void OnMouseDrag()
	{
        if(broken)
        {
            if (transform.position.y >= -0.07f)
            {
                if (myManager.pickable)
                {
                    mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    transform.position = new Vector2(transform.position.x, mousePosition.y - deltaY);
                }
            }
        }
		
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y >= 2) {
			if (pluggedOut < 1) {
				mySfx.Play ();
				pluggedOut = 10;
			}
			myBody.velocity = new Vector2 (0, 8);
			StartCoroutine ("KillMe");
		}

		if (transform.position.y < -0.07f) {
			transform.position = new Vector2(transform.position.x, -0.06f);
		}

		if (broken) {
			mySprite.sprite = brokenTooth;
		}

		if (myManager.stage > 2) {
			myBox.enabled = true;
		}
	}

	public IEnumerator KillMe()
	{
		yield return new WaitForSeconds (1);
		Destroy (gameObject);
		myManager.pickCount++;
	}
}
