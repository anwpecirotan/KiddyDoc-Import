using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour {

	public GameObject[] puzzles;
	public int counter;
	public Image fader;
	public int x;

	// Use this for initialization
	void Start () {
		StartCoroutine (Move (true));
		x = Random.Range (0, 4);
		PlayerPrefs.SetInt ("puzzle", x);
		puzzles [x].SetActive (true);
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (x >= 2) {
			if (counter == 4) {
				counter = 5;
				StartCoroutine (Move (false));
			}
		} else {
			if (counter == 3) {
				counter = 5;
				StartCoroutine (Move (false));
			}
		}
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
