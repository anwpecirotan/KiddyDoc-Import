using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour {

	public AudioSource hospitalBGM;
	public AudioSource playBGM;
	public BGMController theBGM;

	private int locationDetector; //1 = di hospital, 0 = di game
	private float hospitalMaxValue=0.4f;
	void Awake()
	{
		if (theBGM == null) {
			theBGM = this;
			hospitalBGM.Play ();
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	void Update()
	{
		if (Application.loadedLevelName == "MainMenu" || Application.loadedLevelName == "Clinic" || Application.loadedLevelName == "ClinicEasy" || Application.loadedLevelName == "MainMenuB" || Application.loadedLevelName == "UseVoucher" || Application.loadedLevelName == "RedeemPoints") {
			if (!hospitalBGM.isPlaying) {
				StartCoroutine ("FadeToHospital");
				hospitalBGM.Play ();
			}
			playBGM.Stop ();
		} else {
			if (!playBGM.isPlaying) {
				StartCoroutine ("FadeToPlay");
				playBGM.Play ();
			}
			hospitalBGM.Stop ();
		}
	}

	public IEnumerator FadeToHospital()
	{
		hospitalBGM.volume = 0;
		playBGM.volume = 1;
		for (float i = 1; i >= 0f; i -= Time.deltaTime) {
			playBGM.volume = i;
			yield return null;
		}
		for (float i = 0; i <= 0.4f; i += Time.deltaTime/2) {
			hospitalBGM.volume = i;
			yield return null;
		}
	}

	public IEnumerator FadeToPlay()
	{
		hospitalBGM.volume = 0.4f;
		playBGM.volume = 0;
		for (float i = 0.4f; i >= 0f; i -= Time.deltaTime/2) {
			hospitalBGM.volume = i;
			yield return null;
		}
		for (float i = 0; i <= 1; i += Time.deltaTime) {
			playBGM.volume = i;
			yield return null;
		}
	}
}
