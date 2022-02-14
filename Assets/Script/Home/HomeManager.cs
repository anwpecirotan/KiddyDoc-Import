using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour {
	public Text day;
	public Text point;
	public Text division;

	public SpriteRenderer theRequest;
	public Sprite eyeSymbol, teethSymbol, boneSymbol, skinSymbol;

	public GameObject mind;
	public Image fader, exitButton;

	//teeth, eye, bone, skin = DIVISIONS Name

	// Use this for initialization
	void Start () {
		StartCoroutine (Move (true));
		if (PlayerPrefs.GetInt ("days") == 0) {
			PlayerPrefs.SetInt ("days", 1);
			PlayerPrefs.SetString ("division", "Skin");
			PlayerPrefs.SetInt ("playerColor", 1);
		}
		Time.timeScale = 1;
		exitButton.color = new Color (1, 1, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			StartCoroutine ("backToMainMenu");
		}
		day.text = "Day " + PlayerPrefs.GetInt ("days");
		point.text = "Point: " + PlayerPrefs.GetInt ("point");
		division.text = ""+PlayerPrefs.GetString ("division");

		if (PlayerPrefs.GetString ("division") == "Teeth") {
			theRequest.sprite = teethSymbol;
			theRequest.transform.localScale = new Vector2 (0.4f, 0.4f);
			theRequest.transform.eulerAngles = new Vector3 (0, 0, 0);
		}

		if (PlayerPrefs.GetString ("division") == "Eye") {
			theRequest.sprite = eyeSymbol;
			theRequest.transform.localScale = new Vector2 (0.75f, 0.75f);
			theRequest.transform.eulerAngles = new Vector3 (0, 0, 0);
		}

		if (PlayerPrefs.GetString ("division") == "Bone") {
			theRequest.sprite = boneSymbol;
			theRequest.transform.localScale = new Vector2 (1f, 1f);
			theRequest.transform.eulerAngles = new Vector3 (0, 0, -59.111f);
		}

		if (PlayerPrefs.GetString ("division") == "Skin") {
			theRequest.sprite = skinSymbol;
			theRequest.transform.localScale = new Vector2 (0.55f, 0.55f);
			theRequest.transform.eulerAngles = new Vector3 (0, 0, 0);
		}
	}

	public void hideRequest()
	{
		theRequest.color = new Color (1, 1, 1, 0);
		division.color = new Color (0, 0, 0, 0);
		mind.SetActive (false);
	}

	public IEnumerator Move(bool fadeIn)
	{
		exitButton.color = new Color (1, 1, 1, 0);
		if (fadeIn) {
			exitButton.color = new Color (1, 1, 1, 0);
			for (float i = 1; i >= 0f; i -= Time.deltaTime) {
				fader.color = new Color (0, 0, 0, i);
				yield return null;
			}
			exitButton.color = new Color (1, 1, 1, 1);

		} else {
			exitButton.color = new Color (1, 1, 1, 0);
			for (float i = 0; i <= 1f; i += Time.deltaTime) {
				fader.color = new Color (0, 0, 0, i);
				yield return null;
			}
		}
	}

	public IEnumerator backToMainMenu()
	{
		exitButton.color = new Color (1, 1, 1, 0);
		for (float i = 0; i <= 1f; i += Time.deltaTime) {
			fader.color = new Color (0, 0, 0, i);
			yield return null;
		}
		Application.LoadLevel ("MainMenuB");
	}

	public void ExitToMenu()
	{
		StartCoroutine("backToMainMenu");
	}
}
