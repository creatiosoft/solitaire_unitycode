using UnityEngine;
using System.Collections;

public class ScreenOrientationMenu : MonoBehaviour
{			
		public Transform MenuButtons;
		public Transform MoveButton;
		public Transform SpritesOther;
		public Transform LookButton;
		private bool changeOrientation = true;
		float screenAspectRatio = 0;
		float screenAspectRatioL = 0;

		void Start ()
		{
				if (VariablePasser.Instance.previousRotation == VariablePasser.PreviousRotation.Landscape) {
						screenAspectRatio = (float)((float)Screen.height / (float)Screen.width);
						screenAspectRatioL = (float)((float)Screen.width / (float)Screen.height);
				} else {
						screenAspectRatio = (float)((float)Screen.width / (float)Screen.height);
						screenAspectRatioL = (float)((float)Screen.height / (float)Screen.width);
				}
				changeOrientation = false;
//				ChangeOrientation();
		}
	

}
