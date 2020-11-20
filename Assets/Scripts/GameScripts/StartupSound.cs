using UnityEngine;
using System.Collections;

public class StartupSound : MonoBehaviour {
	public AudioClip applauseSound;
	// Use this for initialization
	void Start () {
		if(VariablePasser.Instance.playEffects)
		audio.PlayOneShot(applauseSound);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
