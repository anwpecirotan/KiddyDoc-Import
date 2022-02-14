using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirtController : MonoBehaviour {

	public int health=5;
	public SpriteRenderer mySprite;
	private ToothManager theManager;
	public bool plack;

	// Use this for initialization
	void Start () {
		mySprite = GetComponent<SpriteRenderer> ();
		theManager = FindObjectOfType<ToothManager> ();
		if (plack) {
			health = 10;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Destroy (gameObject);
			if (plack) {
				theManager.plackCount++;
			} else {
				theManager.yellowCount++;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!plack) {
			if (other.tag == "YellowRemover") {
				health--;
				mySprite.color = new Color (mySprite.color.r, mySprite.color.g, mySprite.color.b, (mySprite.color.a - 0.2f));
			}
		} else {
			if (other.tag == "PlackRemover") {
				health--;
				mySprite.color = new Color (mySprite.color.r, mySprite.color.g, mySprite.color.b, (mySprite.color.a - 0.1f));
			}
		}
	}
}
