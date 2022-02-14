using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class UseManager : MonoBehaviour {

	public GameObject[] vouchers;
	public GameObject noVoucher;

	public Image[] voucherImages;

	public Image voucher1, voucher2, voucher3;

	public GameObject voucherInfo;
	public string[] titleVoucher;
	public string[] descriptionVoucher;
	public Text titleText;
	public Text descText;
	private int selectedVoucher;
	public GameObject sureScreen;
	public GameObject successScreen;
	public GameObject failedScreen;
	public int selectedVoucherNumber;
	public string selectedVoucherName;

	public string mailBody;
	public GameObject loadingScreen;
	// Use this for initialization
	void Start () {
		print ("Voucher 1: " + PlayerPrefs.GetInt ("voucher1"));
		print ("Voucher 2: " + PlayerPrefs.GetInt ("voucher2"));
		print ("Voucher 3: " + PlayerPrefs.GetInt ("voucher3"));
	}
	
	// Update is called once per frame
	void Update () {
		
		if (PlayerPrefs.GetInt ("voucher1") != 0) {
			noVoucher.SetActive (false);
			vouchers [0].SetActive (true);
			voucher1.sprite = voucherImages [PlayerPrefs.GetInt("voucher1")-1].sprite;
		} else {
			noVoucher.SetActive (true);
			vouchers [0].SetActive (false);
			vouchers [1].SetActive (false);
			vouchers [2].SetActive (false);
		}

		if (PlayerPrefs.GetInt ("voucher2") != 0) {
			vouchers [1].SetActive (true);
			voucher2.sprite = voucherImages [PlayerPrefs.GetInt ("voucher2") - 1].sprite;
		} else {
			vouchers [1].SetActive (false);
			vouchers [2].SetActive (false);
		}

		if (PlayerPrefs.GetInt ("voucher3") != 0) {
			vouchers [2].SetActive (true);
			voucher3.sprite = voucherImages [PlayerPrefs.GetInt ("voucher3") - 1].sprite;
		} else {
			vouchers [2].SetActive (false);
		}

		if (Input.GetKey (KeyCode.Escape)) {
			Application.LoadLevel ("MainMenuB");
		}
	}

	public void ShowInfo(int x)
	{
		voucherInfo.SetActive (true);
		string voucherName = "voucher"+ (x+1);
		selectedVoucherNumber = x + 1;
		selectedVoucher = PlayerPrefs.GetInt(voucherName);
		titleText.text = titleVoucher [PlayerPrefs.GetInt (voucherName) - 1];
		selectedVoucherName = titleVoucher [PlayerPrefs.GetInt (voucherName) - 1];
		descText.text = descriptionVoucher [PlayerPrefs.GetInt (voucherName)- 1];
	}

	public void MakeSure(bool close)
	{
		if (close) {
			sureScreen.SetActive (false);
			voucherInfo.SetActive (false);
			successScreen.SetActive (false);
			failedScreen.SetActive (false);
		} else {
			sureScreen.SetActive (true);
		}
	}

	public void UseVoucher()
	{
		StartCoroutine ("SendMyMail");
	}

	public IEnumerator SendMyMail()
	{
		loadingScreen.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		SendMail ();
	}

	public void ManageVoucher()
	{
		//successScreen.SetActive (true);
		if (selectedVoucherNumber == 3) {
			PlayerPrefs.SetInt ("voucher3", 0);
		} else if (selectedVoucherNumber == 2) {
			PlayerPrefs.SetInt ("voucher2", PlayerPrefs.GetInt ("voucher3"));
			PlayerPrefs.SetInt ("voucher3", 0);
		} else {
			PlayerPrefs.SetInt ("voucher1", PlayerPrefs.GetInt ("voucher2"));
			PlayerPrefs.SetInt ("voucher2", PlayerPrefs.GetInt ("voucher3"));
			PlayerPrefs.SetInt ("voucher3", 0);
		}

	}

	public void BackToMenu()
	{
		Application.LoadLevel("MainMenuB");
	}

	public void SendMail()
	{
		loadingScreen.SetActive (true);
		mailBody = 
		"===================================" + "\n\r" +
		"= VOUCHER BETHSAIDA HAS BEEN USED =" + "\n\r" +
		"===================================" + "\n\r" + "\n\r" +
		"Voucher Name: " + selectedVoucherName;
			//"Customer Name: " + PlayerPrefs.GetString ("PlayerName") + "\n\r" +
			//"Customer Mail: " + PlayerPrefs.GetString ("PlayerMail") + "\n\r" +
			//"Customer Phone: " + PlayerPrefs.GetString ("PlayerPhone");

		MailMessage mail = new MailMessage ();

		mail.From = new MailAddress ("argarevata@gmail.com");
		mail.To.Add ("argarevata@gmail.com");
		mail.Subject = "VOUCHER BETHSAIDA USED BY A CUSTOMER";
		mail.Body = mailBody;

		SmtpClient smtpServer = new SmtpClient ("smtp.gmail.com");
		smtpServer.Port = 587;
		smtpServer.Credentials = new System.Net.NetworkCredential ("argarevata@gmail.com", "ikanasin1") as ICredentialsByHost;
		smtpServer.EnableSsl = true;
		ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
			return true;
		};

		try{
			loadingScreen.SetActive(true);
			smtpServer.Send(mail);
			ManageVoucher();
			loadingScreen.SetActive(false);
			successScreen.SetActive(true);
		}
		catch(Exception e) {
			print ("FAILED SEND EMAIL");
			loadingScreen.SetActive(false);
			failedScreen.SetActive (true);
		}

	}
}
