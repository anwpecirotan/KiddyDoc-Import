using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RagdollManager : MonoBehaviour {

	public GameObject BandageEye, MedPilTermo, Hands, Stetos, Infuse, Syringe, Tensi;

	public bool BandageEyeActive, MedPilTermoActive, HandsActive, StetosActive, InfuseActive, SyringeActive, TensiActive;
	public int counter;
	public GameObject winScreen;
	public Image fader;
	public GameObject particle;
	public int scoreAdd;
	public Text scoreAddText;

	// Use this for initialization
	void Start () {
		StartCoroutine ("Fadein");
	}
	
	// Update is called once per frame
	void Update () {

		if (BandageEyeActive) {
			BandageEye.SetActive (true);
		} else {
			BandageEye.SetActive (false);
		}

		if (MedPilTermoActive) {
			MedPilTermo.SetActive (true);
		} else {
			MedPilTermo.SetActive (false);
		}

		if (HandsActive) {
			Hands.SetActive (true);
		} else {
			Hands.SetActive (false);
		}

		if (StetosActive) {
			Stetos.SetActive (true);
		} else {
			Stetos.SetActive (false);
		}

		if (InfuseActive) {
			Infuse.SetActive (true);
		} else {
			Infuse.SetActive (false);
		}

		if (SyringeActive) {
			Syringe.SetActive (true);
		} else {
			Syringe.SetActive (false);
		}

		if (TensiActive) {
			Tensi.SetActive (true);
		} else {
			Tensi.SetActive (false);
		}

		if (counter == 4) {
			counter = 100;
			StartCoroutine ("Winning");
		}
	}

	public IEnumerator Winning()
	{
		Instantiate (particle, transform.position, transform.rotation);
		scoreAdd = Random.Range (10, 31);
		yield return new WaitForSeconds (1);
		winScreen.SetActive (true);
		scoreAddText.text = "+ "+ scoreAdd +" Points";
		PlayerPrefs.SetInt ("point", (PlayerPrefs.GetInt ("point") + scoreAdd));
		PlayerPrefs.SetInt ("daysB", (PlayerPrefs.GetInt ("daysB") + 1));
		yield return new WaitForSeconds (1.5f);
		for (float i = 0; i <= 1f; i += Time.deltaTime) {
			fader.color = new Color (0, 0, 0, i);
			yield return null;
		}
		Application.LoadLevel ("ClinicEasy");
	}

	public IEnumerator Fadein()
	{
		for (float i = 1; i >= 0f; i -= Time.deltaTime) {
			fader.color = new Color (0, 0, 0, i);
			yield return null;
		}
	}


}
