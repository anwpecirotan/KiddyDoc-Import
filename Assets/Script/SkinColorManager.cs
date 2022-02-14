﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinColorManager : MonoBehaviour {

	public SpriteRenderer mySprite;
	public Sprite[] colors;

	// Use this for initialization
	void Start () {
		mySprite = GetComponent<SpriteRenderer> ();
		switch (PlayerPrefs.GetInt ("playerColor")) {
		case 1:
			{
				mySprite.sprite = colors [0];
				break;
			}
		case 2:
			{
				mySprite.sprite = colors [0];
				break;
			}
		case 3:
			{
				mySprite.sprite = colors [1];
				break;
			}
		case 4:
			{
				mySprite.sprite = colors [1];
				break;
			}
		case 5:
			{
				mySprite.sprite = colors [2];
				break;
			}
		case 6:
			{
				mySprite.sprite = colors [2];
				break;
			}
		case 7:
			{
				mySprite.sprite = colors [3];
				break;
			}
		case 8:
			{
				mySprite.sprite = colors [3];
				break;
			}
		case 9:
			{
				mySprite.sprite = colors [4];
				break;
			}
		case 10:
			{
				mySprite.sprite = colors [4];
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
