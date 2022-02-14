using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedController : MonoBehaviour {

	public int health;
	public SpriteRenderer mySprite;
	public GameObject winScreen;
	public Image fader;

	public GameObject particle;
	public GameObject particlePos;
	public Text addPoints;

	// Use this for initialization
	void Start () {
		health = 3;
		mySprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (health >= 3) {
			mySprite.color = new Color (1, 1, 1, 1);
		} else if (health == 2) {
			mySprite.color = new Color (1, 1, 1, 0.75f);
		} else if (health == 1) {
			mySprite.color = new Color (1, 1, 1, 0.5f);
		} else if (health == 0) {
			health = -1;
			mySprite.color = new Color (1, 1, 1, 0);
			StartCoroutine ("Done");
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Drop") {
			health--;
		}
	}

	public IEnumerator Done()
	{
		int x = 0;
		do {
			x = Random.Range (1, 11);
		} while(x == PlayerPrefs.GetInt ("playerColor"));
		PlayerPrefs.SetInt ("playerColor", x);
		Instantiate (particle, particlePos.transform.position, transform.rotation);
		yield return new WaitForSeconds (1f);
		int pts = Random.Range (50, 101);
		winScreen.SetActive (true);
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
		
}
