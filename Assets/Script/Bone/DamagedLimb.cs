using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedLimb : MonoBehaviour {

	public bool active;
	public GipsController theGips;
	public SpriteRenderer mySprite;
	public Sprite gipsed;
	public bool wrapped;
	public Animator myAnim;
	public string expectedName;
	private GipsManager theMan;

	private AudioSource mySFX;
	// Use this for initialization
	void Start () {
		mySFX = GetComponent<AudioSource> ();
		theMan = FindObjectOfType<GipsManager> ();
		mySprite = GetComponent<SpriteRenderer> ();
		active = false;
		wrapped = false;
		myAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (active && theGips.released == true && wrapped == false) {
			transform.localScale = new Vector3 (0.469f, 0.469f, 1);
			mySprite.sprite = gipsed;
			mySFX.Play ();
			myAnim.enabled = false;
			//transform.localScale = new Vector3 (1.7f, 1.7f, 1);
			mySprite.color = new Color (1, 1, 1, 1);
			theMan.StartCoroutine ("Win");
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
