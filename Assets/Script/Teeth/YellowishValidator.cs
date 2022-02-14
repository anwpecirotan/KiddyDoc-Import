using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowishValidator : MonoBehaviour {

	public GameObject[] yellowish;
	public GameObject[] plaque;
	public ToothManager theTooth;

	// Use this for initialization
	void Start () {
		StartCoroutine ("Eraser");
	}


	public IEnumerator Eraser()
	{
		theTooth = FindObjectOfType<ToothManager> ();
		yield return new WaitForSeconds (0.1f);
		for (int i = 0; i < 2; i++) {
			if (theTooth.currentCrackNo [i] != -1) {
				yellowish [theTooth.currentCrackNo [i]].SetActive (false);
				theTooth.yellowCount++;
			}
		}
	}

}
