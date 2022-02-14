using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayController : MonoBehaviour {

	public GameObject[] pos;
	public GameObject[] tools;

	[SerializeField]
	private int[] usedTools = { -1, -1, -1, -1 };
	private int x;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 4; i++) {
			do {
				x = Random.Range (0, tools.Length);
			} while(x == usedTools [0] || x == usedTools [1] || x == usedTools [2] || x == usedTools [3]);
			usedTools [i] = x;
			Instantiate (tools [x], pos [i].transform.position, transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
