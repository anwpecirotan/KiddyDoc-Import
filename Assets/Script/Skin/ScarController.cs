using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarController : MonoBehaviour {

	public bool active;
	public BandageController theBandage;
	public SpriteRenderer mySprite;
	public Sprite type1;
	public Sprite type2;
	public Sprite type3;
	public bool wrapped;
	private SkinManager mySkin;

	public GameObject shadow;
	public GameObject ointment;

	// Use this for initialization
	void Start () {
		theBandage = FindObjectOfType<BandageController> ();
		mySprite = GetComponent<SpriteRenderer> ();
		active = false;
		wrapped = false;
		mySkin = FindObjectOfType<SkinManager> ();
		int y = Random.Range (0, 3);
		switch (y) {
		case 1: 
			{
				mySprite.sprite = type1;
				break;	
			}
		case 2:
			{
				mySprite.sprite = type2;
				break;
			}
		case 3:
			{
				mySprite.sprite = type3;
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		theBandage = FindObjectOfType<BandageController> ();
		if (active && theBandage.released == true && wrapped == false) {
			//mySprite.sprite = bandaged;
			StartCoroutine("DestroyOintment");
			ointment.SetActive(true);
			wrapped = true;
		}

		if (mySkin.scarCount >= mySkin.scarSum) {
			StartCoroutine ("ShowBandages");
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Bandage") {
			active = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == "Bandage") {
			active = false;
		}
	}

	public IEnumerator DestroyOintment()
	{
		yield return new WaitForSeconds (0.6f);
		Destroy (ointment);
		mySprite.color = new Color (1, 1, 1, 0.4f);
		transform.localScale = new Vector2 (0.59f, 0.25f);
		mySkin.scarCount++;
	}

	public IEnumerator ShowBandages()
	{
		yield return new WaitForSeconds (0.5f);
		shadow.SetActive (true);
	}
}
