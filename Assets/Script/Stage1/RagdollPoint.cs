using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollPoint : MonoBehaviour {

	public bool touched;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		touched = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		touched = false;
	}
}
