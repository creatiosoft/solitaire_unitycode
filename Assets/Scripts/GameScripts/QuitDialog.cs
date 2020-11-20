using UnityEngine;
using System.Collections;

public class QuitDialog : MonoBehaviour
{
	void Start ()
	{
		DontDestroyOnLoad (gameObject);
	}

	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.Escape)) {
			if (Application.loadedLevel == 1 && GUIClass.instance != null) {

				if (GUIClass.instance.MenuHUDL.activeSelf)
					StartCoroutine ("ShowQuitGamePopUp");
				else if (GUIClass.instance.OptionsMenuL.activeSelf)
					GUIClass.instance.OnClickBackOptions ();
				else if (GUIClass.instance.StatsHUDL.activeSelf)
					GUIClass.instance.OnClickBackStats ();
				else if (GUIClass.instance.HelpHUDL.activeSelf)
					GUIClass.instance.OnClickBackHelp ();
				else if (GUIClass.instance.LooksHUDL.activeSelf)
					GUIClass.instance.OnClickBackLooks ();
				else if (GUIClass.instance.ModeHUDL.activeSelf)
					GUIClass.instance.OnClickHome ();
			}

			if (Application.loadedLevel == 2 && HUD.instance != null) {
				HUD.instance.OnClickHome ();
			}
		}
	}

	public IEnumerator ShowQuitGamePopUp ()
	{
		yield return null;
		DialogManager.Instance.SetLabel ("Yes", "No", "No");
		DialogManager.Instance.ShowSelectDialog ("Application Quit", "Do you really want to quit?", (bool result) => {
			if (result) {
				Application.Quit ();
			}
		});
	}
}