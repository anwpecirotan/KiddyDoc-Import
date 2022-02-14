using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoucherManager : MonoBehaviour {

	//PLAYERPREFS
	//voucher1 int
	//voucher2 int
	//voucher3 int

	public Image[] voucherImages;

	public Image voucher1, voucher2, voucher3;
	public int[] voucherNumber;

	public GameObject voucherInfo;
	public string[] titleVoucher;
	public string[] descriptionVoucher;
	public int[] priceVoucher;
	public Text titleText;
	public Text descText;
	public Button redeemBtn;
	public Text BtnText;
	private int selectedVoucher;

	public Text pointText;
	public GameObject successScreen;

	// Use this for initialization
	void Start () {
		//ResetVouchers ();
		print ("Voucher 1: " + PlayerPrefs.GetInt ("voucher1"));
		print ("Voucher 2: " + PlayerPrefs.GetInt ("voucher2"));
		print ("Voucher 3: " + PlayerPrefs.GetInt ("voucher3"));
	}
	
	// Update is called once per frame
	void Update () {
		pointText.text = "Points: " + PlayerPrefs.GetInt ("point");
		voucher1.sprite = voucherImages [voucherNumber [0]].sprite;
		voucher2.sprite = voucherImages [voucherNumber [1]].sprite;
		voucher3.sprite = voucherImages [voucherNumber [2]].sprite;

		if (Input.GetKeyDown (KeyCode.Escape)) {
//			PlayerPrefs.SetInt ("point", 100000);
//			PlayerPrefs.SetInt ("voucher1", 0);
//			PlayerPrefs.SetInt ("voucher2", 0);
//			PlayerPrefs.SetInt ("voucher3", 0);
			Application.LoadLevel ("MainMenuB");
		}
	}

	public void ResetVouchers()
	{
		voucherNumber [0] = Random.Range (0, 6);
		do {
			voucherNumber [1] = Random.Range (0, 6);
		} while(voucherNumber [1] == voucherNumber [0]);

		do {
			voucherNumber [2] = Random.Range (0, 6);
		} while(voucherNumber [2] == voucherNumber [1] || voucherNumber [2] == voucherNumber [0]);
	}

	public void ShowInfo(int x)
	{
		voucherInfo.SetActive (true);
		selectedVoucher = voucherNumber [x];
		titleText.text = titleVoucher [voucherNumber [x]];
		descText.text = descriptionVoucher [voucherNumber [x]];
		BtnText.text = "REDEEM\r\n"+priceVoucher[voucherNumber[x]] + " pts";
		if (PlayerPrefs.GetInt ("point") < priceVoucher [voucherNumber [x]] || PlayerPrefs.GetInt ("voucher3") != 0) {
			redeemBtn.interactable = false;
		} else {
			redeemBtn.interactable = true;
		}
	}

	public void RedeemPoints()
	{
		if (PlayerPrefs.GetInt ("voucher1") == 0) {
			PlayerPrefs.SetInt ("voucher1", selectedVoucher + 1);
			PlayerPrefs.SetInt ("point", (PlayerPrefs.GetInt ("point") - priceVoucher [selectedVoucher]));
		}
		else if (PlayerPrefs.GetInt ("voucher2") == 0) {
			PlayerPrefs.SetInt ("voucher2", selectedVoucher + 1);
			PlayerPrefs.SetInt ("point", (PlayerPrefs.GetInt ("point") - priceVoucher [selectedVoucher]));
		}else{
			PlayerPrefs.SetInt ("voucher3", selectedVoucher + 1);
			PlayerPrefs.SetInt ("point", (PlayerPrefs.GetInt ("point") - priceVoucher [selectedVoucher]));
		}
		successScreen.SetActive (true);

	}

	public void CloseInfo()
	{
		voucherInfo.SetActive (false);
		successScreen.SetActive (false);
	}

	public void LihatVoucher()
	{
		Application.LoadLevel ("UseVoucher");
	}

	public void BackToMenu()
	{
		Application.LoadLevel("MainMenuB");
	}
}
