using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RontgenManager : MonoBehaviour {

	public GameObject[] point;
	public int x;

	public int[] usedPoints = { -1, -1, -1};
	public int usedCount=0;
	public int scannedCount;
	public Image fader;

	// Use this for initialization
	void Start () {
		StartCoroutine ("fadeIn");
		for (int i = 0; i < 3; i++) {
			do {
				x = Random.Range (0, 6);
			} while(x == usedPoints [0] || x == usedPoints [1] || x == usedPoints [2]);
			usedPoints [i] = x;
			point [x].SetActive (true);
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		if (scannedCount == 3) {
			scannedCount = 5;
			StartCoroutine ("Move");
		}
	}

	public IEnumerator Move()
	{
		yield return new WaitForSeconds(1);
		for (float i = 0; i <= 1f; i += Time.deltaTime) {
			fader.color = new Color (0, 0, 0, i);
			yield return null;
		}
		Application.LoadLevel ("BoneB");
	}

	public IEnumerator fadeIn()
	{
		for (float i = 1; i >= 0f; i -= Time.deltaTime) {
			fader.color = new Color (0, 0, 0, i);
			yield return null;
		}
	}
}
