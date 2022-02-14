using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeDropper : MonoBehaviour {

	public int counter;
	public GameObject pos, water;
	public AudioSource popSFX;

	// Use this for initialization
	void Start () {
		counter = 0;
		CreateWater ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown()
	{
		popSFX.Play ();
		counter+=2;
	}

	public void CreateWater()
	{
		Instantiate (water, pos.transform.position, pos.transform.rotation);
	}
}
