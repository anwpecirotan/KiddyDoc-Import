using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PimpleController : MonoBehaviour {

	public int health;
	public Sprite sprite1, sprite2, sprite3;
	public SpriteRenderer mySprite;
	public SkinManager mySkin;

	// Use this for initialization
	void Start () {
		health = 6;
		mySkin = FindObjectOfType<SkinManager> ();
		mySprite = GetComponent<SpriteRenderer> ();
		mySprite.sprite = sprite1;
	}
	
	// Update is called once per frame
	void Update () {
		if (health == 6) {
			mySprite.sprite = sprite1;
		} else if (health == 4) {
			mySprite.sprite = sprite2;
		} else if (health == 2) {
			mySprite.sprite = sprite3;
		} else if (health <= 0) {
			Destroy (gameObject);
		}
	}

	private void OnMouseDown()
	{
		if (mySkin.stage > 1) {
			health--;
		}
	}
}
