using UnityEngine;
using System.Collections;

public class TouchDragDrop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.touchCount != 0)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit,100) && Input.GetTouch(0).phase == TouchPhase.Began)
			{
				if(hit.collider.GetComponent<CardDragDrop>())
				{
					OnFingerDown();
				}
			}
		}
	}
	void OnFingerDown()
	{

	}

	void OnFingerDrag()
	{

	}

	void onFingerUp()
	{

	}
}
