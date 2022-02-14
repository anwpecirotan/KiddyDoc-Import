using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyeManager : MonoBehaviour {

	public int stage;
	public GameObject eyeDrop;
	public GameObject cloth;
	private EyeOpener theEyeOpen;
	public GameObject inst1, inst2, inst3;
	public Image fader;

	[SerializeField]
	private int yellowSum;
	public int yellowCount;
	public GameObject[] yellowish;
	public int[] yellowCurrentSpot = {-1, -1, -1, -1, -1, -1};
	public GameObject[] yellowSpot;
	public int yellowPosCount;
	public int x;

	// Use this for initialization
	void Start () {
		StartCoroutine (fade (true));
		stage = 1;
		inst1.SetActive (true);
		inst2.SetActive (false);
		inst3.SetActive (false);

		eyeDrop.SetActive (false);
		cloth.SetActive (false);
		theEyeOpen = FindObjectOfType<EyeOpener> ();
		yellowSum = Random.Range (1, 6);

	}
	
	// Update is called once per frame
	void Update () {
		if (theEyeOpen.fullyOpened && stage < 2) {
			stage++;
		}

		if (stage == 2) {
			inst1.SetActive (false);
			inst2.SetActive (true);
			inst3.SetActive (false);

			cloth.SetActive (true);
			for (int i = 0; i < yellowSum; i++) {
				do {
					x = Random.Range (0, 5);
				} while(x == yellowCurrentSpot [0] || x == yellowCurrentSpot [1] || x == yellowCurrentSpot [2] || x == yellowCurrentSpot [3] || x == yellowCurrentSpot [4] || x == yellowCurrentSpot [5]);
				if (x == 1 || x == 0) {
					Instantiate (yellowish [2], yellowSpot [x].transform.position, yellowSpot [x].transform.rotation);
				} else {
					Instantiate (yellowish [Random.Range (0, 5)], yellowSpot [x].transform.position, yellowSpot [x].transform.rotation);
				}
				yellowCurrentSpot [yellowPosCount] = x;
				yellowPosCount++;
			}
			stage++;
		}

		if (yellowCount == yellowSum) {
			stage++;
		}

		if (stage == 4) {
			inst1.SetActive (false);
			inst2.SetActive (false);
			inst3.SetActive (true);

			eyeDrop.SetActive (true);
			cloth.SetActive (false);
		}
	}

	public IEnumerator fade(bool fadein)
	{
		if (fadein) {
			for (float i = 1; i >= 0f; i -= Time.deltaTime) {
				fader.color = new Color (0, 0, 0, i);
				yield return null;
			}
		} else {
			for (float i = 0; i <= 1f; i += Time.deltaTime) {
				fader.color = new Color (0, 0, 0, i);
				yield return null;
			}
		}
	}
}
