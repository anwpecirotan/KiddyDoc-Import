using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeOpener : MonoBehaviour {

	public GameObject[] eye;
	public bool fullyOpened;
	public float diff;
	private AudioSource theSFX;
	private bool sounded;
    public int phase;

    public Vector2 posX;
    public bool touchHold;

	// Use this for initialization
	void Start () {
		fullyOpened = false;
		theSFX = GetComponent<AudioSource> ();
		eye [0].SetActive (true);
		eye [1].SetActive (false);
		eye [2].SetActive (false);
		eye [3].SetActive (false);
		eye [4].SetActive (false);
		eye [5].SetActive (false);
 
    }
	
	// Update is called once per frame
	void Update () {

		if (fullyOpened && !sounded) {
			theSFX.Play ();
			sounded = true;
		}
        print(Input.touchCount);
		//if (Input.touchCount > 0 && !fullyOpened) {
  //          Touch touchZero = Input.GetTouch (0);
  //          print("Wow");
		//    //Touch touchOne = Input.GetTouch (1);
  //          if(touchHold == false)
  //          {
  //              posX = touchZero.position;
  //              touchHold = true;
  //          }
  //          Debug.Log("Hey");
  //          if (diff <= 1) {
  //              //diff = Mathf.Abs (touchOne.position.y - touchZero.position.y);
  //              diff = 1;
		//	}

  //          if (Mathf.Abs(touchZero.position.y - posX.y) >= (110 + diff) && Mathf.Abs(touchZero.position.y - posX.y) < (220 + diff))
  //          {
  //              eye[0].SetActive(false);
  //              eye[1].SetActive(true);
  //              eye[2].SetActive(false);
  //              eye[3].SetActive(false);
  //              eye[4].SetActive(false);
  //              eye[5].SetActive(false);
  //          }
  //          else if (Mathf.Abs(touchZero.position.y - posX.y) >= (220 + diff) && Mathf.Abs(touchZero.position.y - posX.y) < (330 + diff))
  //          {
  //              eye[0].SetActive(false);
  //              eye[1].SetActive(false);
  //              eye[2].SetActive(true);
  //              eye[3].SetActive(false);
  //              eye[4].SetActive(false);
  //              eye[5].SetActive(false);
  //          }
  //          else if (Mathf.Abs(touchZero.position.y - posX.y) >= (330 + diff) && Mathf.Abs(touchZero.position.y - posX.y) < (440 + diff))
  //          {
  //              eye[0].SetActive(false);
  //              eye[1].SetActive(false);
  //              eye[2].SetActive(false);
  //              eye[3].SetActive(true);
  //              eye[4].SetActive(false);
  //              eye[5].SetActive(false);
  //          }
  //          else if (Mathf.Abs(touchZero.position.y - posX.y) >= (440 + diff) && Mathf.Abs(touchZero.position.y - posX.y) < (550 + diff))
  //          {
  //              eye[0].SetActive(false);
  //              eye[1].SetActive(false);
  //              eye[2].SetActive(false);
  //              eye[3].SetActive(false);
  //              eye[4].SetActive(true);
  //              eye[5].SetActive(false);
  //          }
  //          else if (Mathf.Abs(touchZero.position.y - posX.y) >= (550 + diff))
  //          {
  //              eye[0].SetActive(false);
  //              eye[1].SetActive(false);
  //              eye[2].SetActive(false);
  //              eye[3].SetActive(false);
  //              eye[4].SetActive(false);
  //              eye[5].SetActive(true);
  //              fullyOpened = true;
  //          }

  //          //if (Mathf.Abs (touchZero.position.y - touchOne.position.y) >= (110 + diff) && Mathf.Abs (touchZero.position.y - touchOne.position.y) < (220+diff) ) {
  //          //	eye [0].SetActive (false);
  //          //	eye [1].SetActive (true);
  //          //	eye [2].SetActive (false);
  //          //	eye [3].SetActive (false);
  //          //	eye [4].SetActive (false);
  //          //	eye [5].SetActive (false);
  //          //}
  //          //else if (Mathf.Abs (touchZero.position.y - touchOne.position.y) >= (220+diff) && Mathf.Abs (touchZero.position.y - touchOne.position.y) < (330+diff)) {
  //          //	eye [0].SetActive (false);
  //          //	eye [1].SetActive (false);
  //          //	eye [2].SetActive (true);
  //          //	eye [3].SetActive (false);
  //          //	eye [4].SetActive (false);
  //          //	eye [5].SetActive (false);
  //          //}
  //          //else if (Mathf.Abs (touchZero.position.y - touchOne.position.y) >= (330+diff) && Mathf.Abs (touchZero.position.y - touchOne.position.y) < (440+diff)) {
  //          //	eye [0].SetActive (false);
  //          //	eye [1].SetActive (false);
  //          //	eye [2].SetActive (false);
  //          //	eye [3].SetActive (true);
  //          //	eye [4].SetActive (false);
  //          //	eye [5].SetActive (false);
  //          //}
  //          //else if (Mathf.Abs (touchZero.position.y - touchOne.position.y) >= (440+diff) && Mathf.Abs (touchZero.position.y - touchOne.position.y) < (550+diff)) {
  //          //	eye [0].SetActive (false);
  //          //	eye [1].SetActive (false);
  //          //	eye [2].SetActive (false);
  //          //	eye [3].SetActive (false);
  //          //	eye [4].SetActive (true);
  //          //	eye [5].SetActive (false);
  //          //}
  //          //else if (Mathf.Abs (touchZero.position.y - touchOne.position.y) >= (550+diff)) {
  //          //	eye [0].SetActive (false);
  //          //	eye [1].SetActive (false);
  //          //	eye [2].SetActive (false);
  //          //	eye [3].SetActive (false);
  //          //	eye [4].SetActive (false);
  //          //	eye [5].SetActive (true);
  //          //	fullyOpened = true;
  //          //}


  //      } else {
  //          touchHold = false;
		//	if (!fullyOpened) {
		//		diff = 0;
		//		eye [0].SetActive (true);
		//		eye [1].SetActive (false);
		//		eye [2].SetActive (false);
		//		eye [3].SetActive (false);
		//		eye [4].SetActive (false);
		//		eye [5].SetActive (false);

		//	} else {
		//		diff = 0;
		//		eye [0].SetActive (false);
		//		eye [1].SetActive (false);
		//		eye [2].SetActive (false);
		//		eye [3].SetActive (false);
		//		eye [4].SetActive (false);
		//		eye [5].SetActive (true);
		//	}
		//}

	}



    private void OnMouseUpAsButton()
    {
        if (phase >= eye.Length-1)
        {
            fullyOpened = true;
        }
        else
        {
            phase++;
            eye[phase].SetActive(true);
            for (int i = 0; i < eye.Length; i++)
            {
                if (i != phase)
                {
                    eye[i].SetActive(false);
                }
            }
        }

    }
}
