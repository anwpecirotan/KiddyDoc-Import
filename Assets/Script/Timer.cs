using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Slider slide;

	// Use this for initialization
	void Start () {
		slide = GetComponent<Slider> ();
		slide.value = slide.maxValue;
	}
	
	// Update is called once per frame
	void Update () {
		slide.value -= Time.deltaTime;
	}
}
