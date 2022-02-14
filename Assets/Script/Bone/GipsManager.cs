using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GipsManager : MonoBehaviour {

	public GameObject[] gipsPoint;
	public GameObject winScreen;
	public Image fader;
	public GameObject particles;
	public GameObject particlePos;
	public Text addPoints;

	// Use this for initialization
	void Start () {
		StartCoroutine (Move (true));
		gipsPoint [PlayerPrefs.GetInt ("puzzle")].SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator Win()
	{
		int x = 0;
		do {
			x = Random.Range (1, 11);
		} while(x == PlayerPrefs.GetInt ("playerColor"));
		PlayerPrefs.SetInt ("playerColor", x);
		yield return new WaitForSeconds (0.5f);
		Instantiate (particles, particlePos.transform.position, transform.rotation);
		yield return new WaitForSeconds (1f);
		winScreen.SetActive (true);
		int pts = Random.Range (50, 101);
		addPoints.text = "+"+pts+" Points";
		yield return new WaitForSeconds (1.5f);
		PlayerPrefs.SetInt ("point", (PlayerPrefs.GetInt ("point") + pts));
		PlayerPrefs.SetInt ("days", (PlayerPrefs.GetInt ("days") + 1));
		for (float i = 0; i <= 1f; i += Time.deltaTime) {
			fader.color = new Color (0, 0, 0, i);
			yield return null;
		}
		Application.LoadLevel ("Clinic");
	}

	public IEnumerator Move(bool fadeIn)
	{
		if (fadeIn) {
			for (float i = 1; i >= 0f; i -= Time.deltaTime) {
				fader.color = new Color (0, 0, 0, i);
				yield return null;
			}
		} else {
			for (float i = 0; i <= 1f; i += Time.deltaTime) {
				fader.color = new Color (0, 0, 0, i);
				yield return null;
			}
			Application.LoadLevel ("BoneC");
		}
	}
}
