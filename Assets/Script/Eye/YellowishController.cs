using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowishController : MonoBehaviour {

	public int health=10;
	public SpriteRenderer mySprite;
	private EyeManager theEye;

	// Use this for initialization
	void Start () {
		mySprite = GetComponent<SpriteRenderer> ();
		theEye = FindObjectOfType<EyeManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			theEye.yellowCount++;
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "PlackRemover") {
			health--;
			mySprite.color = new Color (mySprite.color.r, mySprite.color.g, mySprite.color.b, (mySprite.color.a - 0.05f));
		}
	}

}
