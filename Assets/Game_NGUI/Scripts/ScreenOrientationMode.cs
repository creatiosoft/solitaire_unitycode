using UnityEngine;
using System.Collections;

public class ScreenOrientationMode : MonoBehaviour
{

			
		public Transform MenuButtons;
		public Transform MoveButton;
		public Transform SpritesOther;
		public Transform LookButton;
		public Transform HomeButton;
		private bool changeOrientation = true;

		float screenAspectRatio = 0;
		float screenAspectRatioL = 0;

		void Awake ()
		{
				if (VariablePasser.Instance.previousRotation == VariablePasser.PreviousRotation.Landscape) {
						screenAspectRatio = (float)((float)Screen.height / (float)Screen.width);
						screenAspectRatioL = (float)((float)Screen.width / (float)Screen.height);
				} else {
						screenAspectRatio = (float)((float)Screen.width / (float)Screen.height);
						screenAspectRatioL = (float)((float)Screen.height / (float)Screen.width);
				}
				changeOrientation = false;
				ChangeOrientation ();
		}
	
		// Update is called once per frame
//		void Update ()
//		{
//			ChangeOrientation();
//		}

		void ChangeOrientation ()
		{
				if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft && VariablePasser.Instance.previousRotation == VariablePasser.PreviousRotation.Portrait) {
						VariablePasser.Instance.previousRotation = VariablePasser.PreviousRotation.Landscape;
						changeOrientation = false;
				}
		
				if (Input.deviceOrientation == DeviceOrientation.Portrait && VariablePasser.Instance.previousRotation == VariablePasser.PreviousRotation.Landscape) {
						VariablePasser.Instance.previousRotation = VariablePasser.PreviousRotation.Portrait;
						changeOrientation = false;
				}
				//For Landscape
				if (VariablePasser.Instance.previousRotation == VariablePasser.PreviousRotation.Landscape && changeOrientation) {
						MenuButtons.GetComponent<UIAnchor> ().side = UIAnchor.Side.Right;
						MoveButton.localPosition = MoveButton.localPosition + new Vector3 (-0.5372f * screenAspectRatioL, 0.222f * screenAspectRatioL, 0);
						MoveButton.localScale = MoveButton.localScale * screenAspectRatioL;
						SpritesOther.localPosition = SpritesOther.localPosition + new Vector3 (-400f * screenAspectRatioL, -400f * screenAspectRatioL, 0);
						SpritesOther.localScale = SpritesOther.localScale * screenAspectRatioL;
						LookButton.localPosition = LookButton.localPosition + new Vector3 (-30f * screenAspectRatioL, 0, 0);
						LookButton.localScale = LookButton.localScale * screenAspectRatioL;
						HomeButton.localPosition = HomeButton.localPosition + new Vector3 (30f * screenAspectRatioL, -20f * screenAspectRatioL, 0);
						HomeButton.localScale = HomeButton.localScale * screenAspectRatioL;
						changeOrientation = false;

				}
		
				//For Potrait 
				if (VariablePasser.Instance.previousRotation == VariablePasser.PreviousRotation.Portrait && changeOrientation) {
						MenuButtons.GetComponent<UIAnchor> ().side = UIAnchor.Side.Center;
						MoveButton.localPosition = Vector3.zero;
						MoveButton.localScale = new Vector3 (1, 1, 1);
						SpritesOther.localPosition = Vector3.zero;
						SpritesOther.localScale = new Vector3 (1, 1, 1);
						SpritesOther.localPosition = Vector3.zero;
						LookButton.localPosition = Vector3.zero;
						LookButton.localScale = new Vector3 (1, 1, 1);
						HomeButton.localPosition = Vector3.zero;
						HomeButton.localScale = new Vector3 (1, 1, 1);
						changeOrientation = false;

				}

		}
}
