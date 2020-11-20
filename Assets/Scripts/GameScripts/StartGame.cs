using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour
{
	void Awake ()
	{
		DontDestroyOnLoad (this.gameObject);
	}

	// Use this for initialization
	void Start ()
	{
		StartCoroutine ("Loadlevel");				
	}

	/// <summary>
	/// Loadlevel this instance of game.
	/// </summary>
	IEnumerator Loadlevel ()
	{
		yield return new WaitForSeconds (1);
		Application.LoadLevel (1);
	}
}