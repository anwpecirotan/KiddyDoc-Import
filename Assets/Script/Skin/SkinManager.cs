using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour {

	public GameObject[] dust;
	public GameObject[] muds;
	public GameObject scar;
	public GameObject winScreen;
	public Image fader;
	public int stage = 1;
	public GameObject cloth;
	public GameObject bandages;

	public GameObject[] bandageTray;

	public bool released;

	public GameObject Instruction1;
	public GameObject Instruction2;
	public GameObject Instruction3;

	public GameObject particle;
	public GameObject particlePos;
	public Text addPoints;

	[SerializeField]
	private int dustSum;
	public int dustCount;
	public int[] dustPosCurrent = {-1, -1, -1, -1, -1, -1, -1};
	public GameObject[] dustPos;

	[SerializeField]
	private int mudSum;
	public int mudCount;
	public int[] mudPosCurrent = {-1, -1, -1, -1, -1};
	public GameObject[] mudPos;

	[SerializeField]
	public int scarSum;
	public int scarCount;
	public int[] scarPosCurrent = {-1, -1, -1, -1, -1};
	public GameObject[] scarPos;

	public int bandageCount;
	// Use this for initialization
	void Start () {
		StartCoroutine ("fadeIn");
		int myDustCount=0;
		int myMudCount=0;
		int myScarCount=0;
		int x = 0;

		dustSum = Random.Range (2, 4);
		mudSum = Random.Range (1, 3);
		scarSum = Random.Range (3, 5);

		for (int i = 0; i < dustSum; i++) {
			do {
				x = Random.Range (0, 7);	
			} while(x == dustPosCurrent [0] || x == dustPosCurrent [1] || x == dustPosCurrent [2] || x == dustPosCurrent [3] || x == dustPosCurrent [4] ||  x == dustPosCurrent [5] ||  x == dustPosCurrent [6]);
			Instantiate (dust [Random.Range (0, 3)], dustPos [x].transform.position, transform.rotation);
			dustPosCurrent [myDustCount] = x;
			myDustCount++;
		}

		for (int i = 0; i < mudSum; i++) {
			do {
				x = Random.Range (0, 5);	
			} while(x == mudPosCurrent [0] || x == mudPosCurrent [1] || x == mudPosCurrent [2] || x == mudPosCurrent [3] || x == mudPosCurrent [4]);
			Instantiate (muds [Random.Range (0, 2)], mudPos [x].transform.position, transform.rotation);
			mudPosCurrent [myMudCount] = x;
			myMudCount++;
		}

		for (int i = 0; i < scarSum; i++) {
			do {
				x = Random.Range (0, 5);	
			} while(x == scarPosCurrent [0] || x == scarPosCurrent [1] || x == scarPosCurrent [2] || x == scarPosCurrent [3] || x == scarPosCurrent [4]);
			Instantiate (scar, scarPos [x].transform.position, transform.rotation);
			scarPosCurrent [myScarCount] = x;
			myScarCount++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (stage == 1) {
			cloth.SetActive (true);
			bandages.SetActive (false);

			Instruction1.SetActive (true);
			Instruction2.SetActive (false);
			Instruction3.SetActive (false);
		}

		if (stage == 2) {
			cloth.SetActive (false);
			bandages.SetActive (true);

			Instruction1.SetActive (false);
			Instruction2.SetActive (false);
			Instruction3.SetActive (true);
		}

		if (stage == 3) {
			cloth.SetActive (false);
			bandages.SetActive (false);

			Instruction1.SetActive (false);
			Instruction2.SetActive (false);
			Instruction3.SetActive (true);
		}

		if (dustCount == dustSum && mudCount == mudSum) {
			stage++;
			dustCount = mudCount = 10;
		}

		if (scarCount == scarSum) {
			scarCount++;
			stage++;
			cloth.SetActive (false);
			bandages.SetActive (false);
			StartCoroutine ("ShowTray");
			//StartCoroutine ("YouWin");
		}

		if (bandageCount == scarSum) {
			bandageCount++;
			StartCoroutine ("YouWin");
		}
	}

	public IEnumerator YouWin()
	{
		int x = 0;
		do {
			x = Random.Range (1, 11);
		} while(x == PlayerPrefs.GetInt ("playerColor"));
		PlayerPrefs.SetInt ("playerColor", x);
		yield return new WaitForSeconds (0.5f);
		Instantiate (particle, particlePos.transform.position, transform.rotation);
		yield return new WaitForSeconds (1);
		winScreen.SetActive (true);
		int pts = Random.Range (50, 101);
		addPoints.text = "+"+pts+" Points";
		PlayerPrefs.SetInt ("point", (PlayerPrefs.GetInt ("point") + pts));
		PlayerPrefs.SetInt ("days", (PlayerPrefs.GetInt ("days") + 1));
		yield return new WaitForSeconds (1.5f);
		for (float i = 0; i <= 1f; i += Time.deltaTime) {
			fader.color = new Color (0, 0, 0, i);
			yield return null;
		}
		Application.LoadLevel ("Clinic");
	}

	public IEnumerator fadeIn()
	{
		for (float i = 1; i >= 0f; i -= Time.deltaTime) {
			fader.color = new Color (0, 0, 0, i);
			yield return null;
		}
	}

	public IEnumerator ShowTray()
	{
		yield return new WaitForSeconds (0.5f);
		for (int i = 0; i < bandageTray.Length; i++) {
			bandageTray [i].SetActive (true);
		}
	}
}
