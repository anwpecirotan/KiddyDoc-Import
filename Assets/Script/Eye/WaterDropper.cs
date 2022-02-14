using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropper : MonoBehaviour {

	private EyeDropper theDropper;
	private Rigidbody2D myBody;
	private bool dropped;

	// Use this for initialization
	void Start () {
		theDropper = FindObjectOfType<EyeDropper> ();
		myBody = FindObjectOfType<Rigidbody2D> ();
		myBody.mass = 0;
		myBody.gravityScale = 0;
		transform.localScale = new Vector3 (0.1f, 0.1f, 1);
		dropped = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (theDropper.counter >= 2 && theDropper.counter < 4) {
			transform.localScale = new Vector3 (0.2f, 0.2f, 1);
		} else if (theDropper.counter >= 4 && theDropper.counter < 6) {
			transform.localScale = new Vector3 (0.3f, 0.3f, 1);
		} else if (theDropper.counter >= 6 && theDropper.counter < 8) {
			transform.localScale = new Vector3 (0.4f, 0.4f, 1);
		} else if (theDropper.counter > 8) {
			theDropper.counter = 0;
			myBody.mass = 10;
			dropped = true;
			myBody.gravityScale = 10;
			StartCoroutine ("KillMe");
		}
	}

	public IEnumerator KillMe()
	{
		yield return new WaitForSeconds (0.5f);
		theDropper.CreateWater ();
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "RedLayer") {
			StopCoroutine ("KillMe");
			theDropper.CreateWater ();
			Destroy (gameObject);
		}
	}
}
