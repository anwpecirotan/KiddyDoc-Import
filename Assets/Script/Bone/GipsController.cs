using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GipsController : MonoBehaviour {

	private float deltaX, deltaY;
	private Vector2 mousePosition;
	private Vector2 initialPosition;
	public bool released;
    public bool clinicTrayItem;
    public SpriteRenderer clinicTraySymbol;

    // Use this for initialization
    void Start () {
		released = true;
		//initialPosition = transform.position;
		StartCoroutine ("SetInitPos");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown()
	{
		deltaX = Camera.main.ScreenToWorldPoint (Input.mousePosition).x - transform.position.x;
		deltaY = Camera.main.ScreenToWorldPoint (Input.mousePosition).y - transform.position.y;
		released = false;
        if (clinicTrayItem)
        {
            transform.localScale = new Vector3(0.42f, 0.38f, 1);
            clinicTraySymbol.sortingOrder = 10;
            SpriteRenderer mybox = gameObject.GetComponent<SpriteRenderer>();
            mybox.sortingOrder = 9;
        }
	}

	private void OnMouseDrag()
	{
		mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = new Vector2 (mousePosition.x - deltaX, mousePosition.y - deltaY);
		released = false;
	}

	private void OnMouseUp()
	{
		transform.position = new Vector2 (initialPosition.x, initialPosition.y);
		released = true;
        if (clinicTrayItem)
        {
            transform.localScale = new Vector3(0.21f, 0.19f, 1);
            clinicTraySymbol.sortingOrder = 5;
            SpriteRenderer mybox = gameObject.GetComponent<SpriteRenderer>();
            mybox.sortingOrder = 4;
        }
    }

	public IEnumerator SetInitPos()
	{
		yield return new WaitForSeconds (1.5f);
		initialPosition = transform.position;
	}
}
