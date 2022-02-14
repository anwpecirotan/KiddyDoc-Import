using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerticleKiller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("KillMe");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator KillMe()
	{
		yield return new WaitForSeconds (1.5f);
		Destroy (gameObject);
	}
}
