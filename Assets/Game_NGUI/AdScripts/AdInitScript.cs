using UnityEngine;
using System.Collections;

/// <summary>
/// Ad init script.This script is used to display intestitial ads on Main menu
/// </summary>
public class AdInitScript : MonoBehaviour
{

		//private RevMobScript revMobRef;  //ref of RevMob Script

		void Awake ()
		{
				

		}

		void OnEnable ()
		{

	
				if (PlayerPrefs.GetInt ("addisplay2") == 0) {
//			NGUIDebug.Log("ad");
						if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork || Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork) {		
								// StartAppWrapperiOS.showAd();
								// StartAppWrapperiOS.loadAd(StartAppWrapperiOS.AdType.STAAdType_FullScreen);

						}
						PlayerPrefs.SetInt ("addisplay2", 1);
				}
	
		}
	

}
