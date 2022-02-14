using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RontgenPoint : MonoBehaviour {

	public bool active;
	public RontgenController theRontgen;
	public SpriteRenderer mySprite;
	//public Sprite scanned;
	public bool wrapped;
	public Animator myAnim;
	private RontgenManager theManager;
	public AudioSource myBeep;

	public GameObject scannedd;
	// Use this for initialization
	void Start () {
		theRontgen = FindObjectOfType<RontgenController> ();
		mySprite = GetComponent<SpriteRenderer> ();
		active = false;
		wrapped = false;
		theManager = FindObjectOfType<RontgenManager> ();
		myAnim = GetComponent<Animator> ();
		myBeep = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (active && theRontgen.released == true && wrapped == false) {
			myBeep.Play ();
			Instantiate (scannedd, transform.position, transform.rotation);
			myAnim.enabled = false;
			transform.localScale = new Vector3 (2.5f, 2.5f, 1);
			mySprite.color = new Color (1, 1, 1, 0);
			wrapped = true;
			theManager.scannedCount++;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Rontgen") {
			active = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == "Rontgen") {
			active = false;
		}
	}
}
