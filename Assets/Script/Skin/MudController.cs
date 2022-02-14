using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudController : MonoBehaviour {

	public int health=5;
	public SpriteRenderer mySprite;
	public bool mud;
	private SkinManager mySkin;

	// Use this for initialization
	void Start () {
		mySprite = GetComponent<SpriteRenderer> ();
		if (mud) {
			health = 10;
		} else {
			health = 20;
		}

		mySkin = FindObjectOfType<SkinManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			if (mud) {
				mySkin.mudCount++;
			} else {
				mySkin.dustCount++;
			}
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!mud) {
			if (other.tag == "PlackRemover") {
				health--;
				mySprite.color = new Color (mySprite.color.r, mySprite.color.g, mySprite.color.b, (mySprite.color.a - 0.035f));
			}
		} else {
			if (other.tag == "PlackRemover") {
				health--;
				mySprite.color = new Color (mySprite.color.r, mySprite.color.g, mySprite.color.b, (mySprite.color.a - 0.08f));
			}
		}
	}
}
