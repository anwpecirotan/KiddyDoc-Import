using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage1Clinic : MonoBehaviour {

	public Text dayText;
	public Text pointText;
	public Image fader;
	private bool able;

	// Use this for initialization
	void Start () {
		StartCoroutine ("Fadein");
		if (PlayerPrefs.GetInt ("daysB") == 0) {
			PlayerPrefs.SetInt ("daysB", 1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			StartCoroutine ("backToMainMenu");
		}

		dayText.text = "Day " + PlayerPrefs.GetInt ("daysB");
		pointText.text = "Points: " + PlayerPrefs.GetInt ("point");
	}

	private void OnMouseDown()
	{
		if (!able) {
			StartCoroutine ("LoadStage");
			able = true;
		}
	}

	public IEnumerator LoadStage()
	{
		for (float i = 0; i <= 1f; i += Time.deltaTime) {
			fader.color = new Color (0, 0, 0, i);
			yield return null;
		}
		Application.LoadLevel ("Stage1");
	}

	public IEnumerator Fadein()
	{
		for (float i = 1; i >= 0f; i -= Time.deltaTime) {
			fader.color = new Color (0, 0, 0, i);
			yield return null;
		}
	}

	public IEnumerator backToMainMenu()
	{
		for (float i = 0; i <= 1f; i += Time.deltaTime) {
			fader.color = new Color (0, 0, 0, i);
			yield return null;
		}
		Application.LoadLevel ("MainMenu");
	}
}
