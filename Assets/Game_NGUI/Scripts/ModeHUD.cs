using UnityEngine;
using System.Collections;

public class ModeHUD : MonoBehaviour {

	public GameObject MenuHUD;
	// Use this for initialization
	void Start () {
	
	}

	void OnClickHome(){
		MenuHUD.SetActive (true);
		this.gameObject.SetActive (false);
	}

}
