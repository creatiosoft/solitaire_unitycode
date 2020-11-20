using UnityEngine;
using System.Collections;

public class ScreenDetails : MonoBehaviour {


	public enum PreviousRotation
	{
		Landscape =0,
		Portrait
	}
	;
	

	public PreviousRotation previousRotation;

	public float screenAspectRatio = 0;
	public float screenAspectRatioL = 0;

	public static ScreenDetails Instance;

	void Awake ()
	{
		previousRotation = PreviousRotation.Landscape;
		screenAspectRatio = (float)((float)Screen.width / (float)Screen.height);
		screenAspectRatioL = (float)((float)Screen.height / (float)Screen.width);
	}

}
