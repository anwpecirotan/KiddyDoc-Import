using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsController : MonoBehaviour {

	private float deltaX, deltaY;
	private Vector2 mousePosition;
	private Vector2 initialPosition;
	public RagdollManager theRagdoll;
	public bool released;
	public RagdollPoint thePoint;
	public bool BandageEye, MedPilTermo, Hands, Stetos, Infuse, Syringe, Tensi;

	// Use this for initialization
	void Start () {
		released = true;
		initialPosition = transform.position;
		theRagdoll = FindObjectOfType<RagdollManager> ();
	}

	private void OnMouseDown()
	{
		if (BandageEye) {
			theRagdoll.BandageEyeActive = true;
		} else if (MedPilTermo) {
			theRagdoll.MedPilTermoActive = true;
		} else if (Hands) {
			theRagdoll.HandsActive = true;
		} else if (Stetos) {
			theRagdoll.StetosActive = true;
		} else if (Infuse) {
			theRagdoll.InfuseActive = true;
		} else if (Syringe) {
			theRagdoll.SyringeActive = true;
		} else if (Tensi) {
			theRagdoll.TensiActive = true;
		}
		deltaX = Camera.main.ScreenToWorldPoint (Input.mousePosition).x - transform.position.x;
		deltaY = Camera.main.ScreenToWorldPoint (Input.mousePosition).y - transform.position.y;
		released = false;
	}

	private void OnMouseDrag()
	{
		mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = new Vector2 (mousePosition.x - deltaX, mousePosition.y - deltaY);
		released = false;
	}

	private void OnMouseUp()
	{
		if (BandageEye) {
			theRagdoll.BandageEyeActive = false;
		} else if (MedPilTermo) {
			theRagdoll.MedPilTermoActive = false;
		} else if (Hands) {
			theRagdoll.HandsActive = false;
		} else if (Stetos) {
			theRagdoll.StetosActive = false;
		} else if (Infuse) {
			theRagdoll.InfuseActive = false;
		} else if (Syringe) {
			theRagdoll.SyringeActive = false;
		} else if (Tensi) {
			theRagdoll.TensiActive = false;
		}
		transform.position = new Vector2 (initialPosition.x, initialPosition.y);
		released = true;

		thePoint = FindObjectOfType<RagdollPoint> ();
		if (thePoint.touched) {
			theRagdoll.counter++;
			Destroy (gameObject);
		}
	}
}
