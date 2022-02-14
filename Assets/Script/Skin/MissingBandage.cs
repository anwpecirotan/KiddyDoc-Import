using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingBandage : MonoBehaviour {

	public bool active;
	public SkinManager theSkin;
	public SpriteRenderer mySprite;
	public bool wrapped;

	public string expectedName;

	public int type;
	public Sprite shadow1, shadow2, shadow3, shadow4, shadow5;
	public Sprite bandage1, bandage2, bandage3, bandage4, bandage5, bandageX;
	public AudioSource mySFX;

	// Use this for initialization
	void Start () {
		theSkin = FindObjectOfType<SkinManager> ();
		mySprite = GetComponent<SpriteRenderer> ();
		active = false;
		wrapped = false;
		type = Random.Range (0, 5);
		switch (type) {
		case 0:
			{
				mySprite.sprite = shadow1;
				bandageX = bandage1;
				expectedName = "Bandage1";
				break;
			}
		case 1:
			{
				mySprite.sprite = shadow2;
				bandageX = bandage2;
				expectedName = "Bandage2";
				break;
			}
		case 2:
			{
				mySprite.sprite = shadow3;
				bandageX = bandage3;
				expectedName = "Bandage3";
				break;
			}
		case 3:
			{
				mySprite.sprite = shadow4;
				bandageX = bandage4;
				expectedName = "Bandage4";
				break;
			}
		case 4:
			{
				mySprite.sprite = shadow5;
				bandageX = bandage5;
				expectedName = "Bandage5";
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (active && theSkin.released == true && wrapped == false) {
			mySprite.sprite = bandageX;
			mySprite.sortingOrder = 1;
			mySprite.color = new Color (1, 1, 1, 1);
			wrapped = true;
			mySFX.Play ();
			theSkin.bandageCount++;
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
