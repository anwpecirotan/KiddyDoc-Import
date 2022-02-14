using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpiredManager : MonoBehaviour {

	//PLAYERPREFS
	//deadline int [Untuk tentuin kapan bakal hangus promonya]

	public int day0, day1;
	public Text expiredText;
	public VoucherManager theVoucher;

	// Use this for initialization
	void Start () {
		theVoucher = FindObjectOfType<VoucherManager> ();
		if (PlayerPrefs.GetInt ("deadline") == 0) {
			day0 = System.DateTime.Now.Day;
			day1 = day0 + 5;
			PlayerPrefs.SetInt ("deadline", day1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		expiredText.text = "Offers Expired in: " + (PlayerPrefs.GetInt("deadline") - System.DateTime.Now.Day)+" days";
		if (System.DateTime.Now.Day >= PlayerPrefs.GetInt("deadline")) {
			theVoucher.ResetVouchers ();
			day0 = System.DateTime.Now.Day;
			day1 = day0 + 5;
			PlayerPrefs.SetInt ("deadline", day1);
		}
	}
}
