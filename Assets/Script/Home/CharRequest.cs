using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharRequest : MonoBehaviour {

	public bool active;
	public bool wrapped;
	public GipsController theEye, theSkin, theBone, theTeeth;
	public string myRequest;
	private HomeManager theHome;
	public Image fader;
	public SpriteRenderer charSprite;
	public int playerColor;
	public int x;
	private AudioSource mySFX;

	private int eyeSpecialColor;
	public Sprite eyeChar1, eyeChar2;
	// Use this for initialization
	void Start () {
		eyeSpecialColor = Random.Range (1, 11);
		if (eyeSpecialColor % 2 == 0) {
			eyeSpecialColor = 2;
		} else {
			eyeSpecialColor = 4;
		}
		charSprite = GetComponent<SpriteRenderer> ();
		active = false;
		wrapped = false;
		theHome = FindObjectOfType<HomeManager> ();
		myRequest = PlayerPrefs.GetString ("division");
		mySFX = GetComponent<AudioSource> ();

//		switch (PlayerPrefs.GetInt ("playerColor")) {
//		case 1:
//			{
//				charSprite.color = new Color (1f, 0f, 0f, 1);	
//				break;
//			}
//		case 2:
//			{
//				charSprite.color = new Color (0f, 1f, 0f, 1);
//				break;
//			}
//		case 3:
//			{
//				charSprite.color = new Color (0f, 0f, 1f, 1);
//				break;
//			}
//		case 4:
//			{
//				charSprite.color = new Color (0f, 0f, 0f, 1);
//				break;
//			}
//		case 5:
//			{
//				charSprite.color = new Color (1f, 1f, 1f, 1);
//				break;
//			}
//		}

//		do {
//			x = Random.Range (1, 6);
//		} while(x == PlayerPrefs.GetInt ("playerColor"));
//		PlayerPrefs.SetInt ("playerColor", x);
	}
	
	// Update is called once per frame
	void Update () {
		switch (myRequest) {
		case "Teeth": 
			{
				if (active && theTeeth.released == true && wrapped == false) {
					wrapped = true;
					NextStage ();
					StartCoroutine (Move ("Teeth"));
				}
				break;
			}
		case "Eye": 
			{
				if (eyeSpecialColor == 2) {
					//charSprite.sprite = new Color (0f, 1f, 0f, 1);
					charSprite.sprite = eyeChar2;
					PlayerPrefs.SetInt ("playerColor", 2);
				} else {
					//charSprite.color = new Color (0f, 0f, 0f, 1);
					charSprite.sprite = eyeChar1;
					PlayerPrefs.SetInt ("playerColor", 7);
				}
				if (active && theEye.released == true && wrapped == false) {
					wrapped = true;
					NextStage ();
					StartCoroutine (Move ("Eye"));
				}
				break;
			}
		case "Bone": 
			{
				if (active && theBone.released == true && wrapped == false) {
					wrapped = true;
					NextStage ();
					StartCoroutine (Move ("Bone"));
				}
				break;
			}
		case "Skin": 
			{
				if (active && theSkin.released == true && wrapped == false) {
					wrapped = true;
					NextStage ();
					StartCoroutine (Move ("Skin"));
				}
				break;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == myRequest) {
			active = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == myRequest) {
			active = false;
		}
	}

	void NextStage()
	{
		mySFX.Play ();
		string pref = PlayerPrefs.GetString ("division");
		theHome.hideRequest ();
		do{
			int x = Random.Range (0, 4);
			if (x == 0) {
				PlayerPrefs.SetString ("division", "Skin");
			}
			else if (x == 1) {
				PlayerPrefs.SetString ("division", "Bone");
			}
			else if (x == 2) {
				PlayerPrefs.SetString ("division", "Eye");
			}
			else{
				PlayerPrefs.SetString ("division", "Teeth");
			}
		}while(PlayerPrefs.GetString("division") == pref);
	}

	public IEnumerator Move(string x)
	{
		for (float i = 0; i <= 1f; i += Time.deltaTime) {
			fader.color = new Color (0, 0, 0, i);
			yield return null;
		}
		yield return new WaitForSeconds (0.5f);
		Application.LoadLevel (x);
	}
}
