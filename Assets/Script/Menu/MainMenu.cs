using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Text pointText;
	public bool stageActive;
	public bool voucherActive;
	public Image fader;
	public GameObject stageSelect;
	public GameObject voucherSelect;

	public Animator myAnim;
	// Use this for initialization
	void Start () {
		StartCoroutine ("Fadein");
		pointText.text = "Points: " + PlayerPrefs.GetInt ("point");
		myAnim = GetComponent<Animator> ();
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void loadscene(string x)
	{
		fader.gameObject.SetActive (true);
		StartCoroutine (loadNext (x));
	}

	public void showHideStage()
	{
		if (!stageActive) {
			myAnim.SetBool ("show", true);
			stageSelect.SetActive (true);
			stageActive = true;
		} else {
			myAnim.SetBool ("show", false);
			myAnim.SetBool ("reset", true);
			stageSelect.SetActive (false);
			stageActive = false;
		}
	}

	public void showHideVoucher()
	{
		if (!voucherActive) {
			myAnim.SetBool ("voucher", true);
			voucherSelect.SetActive (true);
			voucherActive = true;
		} else {
			myAnim.SetBool ("voucher", false);
			myAnim.SetBool ("reset", true);
			voucherSelect.SetActive (false);
			voucherActive = false;
		}
	}

	public void exit()
	{
		Application.Quit ();
	}

	public IEnumerator Fadein()
	{
		fader.gameObject.SetActive (true);
		for (float i = 1; i >= 0f; i -= Time.deltaTime) {
			fader.color = new Color (0, 0, 0, i);
			yield return null;
		}
		fader.gameObject.SetActive (false);
	}

	public IEnumerator loadNext(string x)
	{
		for (float i = 0; i <= 1f; i += Time.deltaTime) {
			fader.color = new Color (0, 0, 0, i);
			yield return null;
		}
		Application.LoadLevel (x);
	}
}
