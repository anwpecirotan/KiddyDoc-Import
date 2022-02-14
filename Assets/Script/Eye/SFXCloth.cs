using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCloth : MonoBehaviour {

	public AudioSource wipeSFX1;
	public AudioSource wipeSFX2;
	public int x;

	// Use this for initialization
	void Start () {
		x = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (x % 2 == 0) {
			if (!wipeSFX1.isPlaying && !wipeSFX2.isPlaying) {
				wipeSFX1.Stop ();
				wipeSFX2.Stop ();
				wipeSFX1.Play ();
				x++;
			}
		} else{
			if (!wipeSFX1.isPlaying && !wipeSFX2.isPlaying) {
				wipeSFX1.Stop ();
				wipeSFX2.Stop ();
				wipeSFX2.Play ();
				x++;
			}
		}
	}
}
