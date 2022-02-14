using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaqueTapper : MonoBehaviour {

	[SerializeField]
	private float health;
	private ToothManager theTooth;
	private bool dropped;
	private bool holdDown;
	private Animator myAnim;
	private BoxCollider2D myBox;
	public GameObject droppedPlaque;
	public GameObject spark;
	public GameObject drill;
	// Use this for initialization
	void Start () {
		myAnim = GetComponent<Animator> ();
		health = 1.5f;
		theTooth = FindObjectOfType<ToothManager> ();
		myBox = GetComponent<BoxCollider2D> ();
		myBox.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (theTooth.stage == 2) {
			myBox.enabled = true;	
		}

		if (health <= 0) {	
			myAnim.SetBool ("active", false);
			Destroy (spark);
			Destroy (drill);
			if (!dropped) {
				dropped = true;
				Instantiate (droppedPlaque, transform.position, transform.rotation);
				theTooth.plackCount++;
				Destroy (gameObject);
			}
		}

		if (holdDown && theTooth.stage == 2) {
			health -= Time.deltaTime;
			spark.SetActive (true);
			drill.SetActive (true);
			Handheld.Vibrate ();
		} else {
			spark.SetActive (false);
			drill.SetActive (false);
		}
	}

	private void OnMouseDown()
	{
		holdDown = true;
		if (health > 0) {
			myAnim.SetBool ("active", true);
		}
	}

	private void OnMouseUp()
	{
		holdDown = false;
		myAnim.SetBool ("active", false);
	}
}
