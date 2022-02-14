using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToothManager : MonoBehaviour {

	public int stage;

	public GameObject brush;
	public GameObject drill;

	public GameObject particle;
	public GameObject particlePos;

	public int yellowCount;
	public int plackCount;
	public int pickCount;
	public bool pickable;

	public Text addPoints;
	public Image fader;

	[SerializeField]
	private int plackSum;
	[SerializeField]
	private int crackSum;

	public GameObject[] placks;
	public PickTooth[] teeth;

	public int[] currentPlackNo = {-1,-1, -1, -1, -1};
	public int[] currentCrackNo = { -1, -1, -1 };
    public int usedCrackNo;

	public GameObject winScreen;

	public GameObject[] Instructions;

	// Use this for initialization
	void Start () {
		StartCoroutine ("fadein");
		stage = 1;
		brush.SetActive (false);
		drill.SetActive (false);
		pickable = false;
		plackSum = Random.Range (2, 5);
        crackSum = 2; //Random.Range (1, 3);
		int myCountPlack = 0;
		int myCountCrack = 0;
		yellowCount = 0;

		int x = 0;

		for (int i = 0; i < plackSum; i++) {
			do {
				x = Random.Range (0, 8);	
			} while(x == currentPlackNo [0] || x == currentPlackNo [1] || x == currentPlackNo [2] || x == currentPlackNo [3] || x == currentPlackNo [4]);
			placks [x].SetActive (true);
			currentPlackNo [myCountPlack] = x;
			myCountPlack++;
		}

		//for (int i = 0; i < 2; i++) {
		//	do {
		//		x = Random.Range (0, 8);
		//	} while(x == currentCrackNo [0] || x == currentCrackNo [1] || x == currentCrackNo [2]);
		//	teeth [x].broken = true;
		//	currentCrackNo [myCountCrack] = x;
		//	myCountCrack++;
		//}

        x = Random.Range(0, 8);
        teeth[x].broken = true;
        usedCrackNo = x;
        currentCrackNo[0] = x;
        myCountCrack++;

        do
        {
            x = Random.Range(0, 8);
        } while (x == usedCrackNo);
        teeth[x].broken = true;
        currentCrackNo[1] = x;
        myCountCrack++;
    }

	// Update is called once per frame
	void Update () {

		if (yellowCount == 8) {
			stage++;
			yellowCount = 100;
		}

		if (plackCount == plackSum) {
			stage++;
			plackCount = 100;
		}

		if (pickCount == crackSum) {
			pickCount = 100;
			StartCoroutine ("Winning");
		}

		if (stage == 1) {
			brush.SetActive (true);
			drill.SetActive (false);

			Instructions [0].SetActive (true);
			Instructions [1].SetActive (false);
			Instructions [2].SetActive (false);
		} else if (stage == 2) {
			brush.SetActive (false);
			drill.SetActive (true);

			Instructions [0].SetActive (false);
			Instructions [1].SetActive (true);
			Instructions [2].SetActive (false);
		} else {
			brush.SetActive (false);
			drill.SetActive (false);
			pickable = true;

			Instructions [0].SetActive (false);
			Instructions [1].SetActive (false);
			Instructions [2].SetActive (true);
		}
	}

	public IEnumerator Winning()
	{
		int x = 0;
		do {
			x = Random.Range (1, 11);
		} while(x == PlayerPrefs.GetInt ("playerColor"));
		PlayerPrefs.SetInt ("playerColor", x);

		Instantiate (particle, particlePos.transform.position, transform.rotation);
		yield return new WaitForSeconds (1f);
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

	public IEnumerator fadein()
	{
		for (float i = 1; i >= 0f; i -= Time.deltaTime) {
			fader.color = new Color (0, 0, 0, i);
			yield return null;
		}
	}
}
