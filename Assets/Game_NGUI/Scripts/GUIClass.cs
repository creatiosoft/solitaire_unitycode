using UnityEngine;
using System.Collections;
using System.IO;
public class GUIClass : MonoBehaviour
{
		public static GUIClass instance;
		public GameObject LandscapeHUD;
		public GameObject PortraitHUD;
		public GameObject ModeHUD;
		public GameObject ModeHUDL;
		public GameObject MenuHUD;
		public GameObject MenuHUDL;
		public GameObject ResumeButton;
		public GameObject ResumeButtonL;
		public GameObject DrawOneButton;
		public GameObject DrawOneButtonL;
		public GameObject DrawThreeButton;
		public GameObject DrawThreeButtonL;
		public GameObject OptionsMenu;
		public GameObject OptionsMenuL;
		public GameObject LooksHUD;
		public GameObject LooksHUDL;
		public GameObject HelpHUD;
		public GameObject HelpHUDL;
		public GameObject StatsHUD;
		public GameObject StatsHUDL;
		public GameObject BackGroundP;
		public GameObject BackGroundL;
		private bool changeOrientation = true;
		//Play Button
		void Awake ()
		{
				instance = this;
//		PlayerPrefs.DeleteAll();
				if (!PlayerPrefs.HasKey ("Slider")) {
						PlayerPrefs.SetInt ("Slider", 1);
						PlayerPrefs.SetInt ("Slider1", 1);
						PlayerPrefs.SetInt ("Slider2", 1);
				}
				if (!PlayerPrefs.HasKey ("Looks")) {
						PlayerPrefs.SetInt ("Looks", 1);
						PlayerPrefs.SetInt ("DrawCardNumber", 3);
						VariablePasser.Instance.looks = 1;
				}
				VariablePasser.Instance.looks = PlayerPrefs.GetInt ("Looks");
				VariablePasser.Instance.drawCardNumber = PlayerPrefs.GetInt ("DrawCardNumber");
				bVolume = PlayerPrefs.GetInt ("Slider");
				bEffects = PlayerPrefs.GetInt ("Slider1");
				bRich = PlayerPrefs.GetInt ("Slider2");
				if (VariablePasser.Instance.drawCardNumber == 3) {

						//DrawThreeButton.SetActive (true);
						//DrawOneButton.SetActive (false);
						DrawThreeButtonL.SetActive (true);
						DrawOneButtonL.SetActive (false);
				} else {

						//DrawThreeButton.SetActive (false);
						//DrawOneButton.SetActive (true);
						DrawThreeButtonL.SetActive (false);
						DrawOneButtonL.SetActive (true);

				}
				ChangeBackground ();
		}

		void ChangeBackground ()
		{
				if (VariablePasser.Instance.looks == 1) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");
			
				} else if (VariablePasser.Instance.looks == 2) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");
						;
			
			
				} else if (VariablePasser.Instance.looks == 3) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");
			
			
				} else if (VariablePasser.Instance.looks == 4) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");

				} else if (VariablePasser.Instance.looks == 5) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");

				} else if (VariablePasser.Instance.looks == 6) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");

				} else if (VariablePasser.Instance.looks == 7) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");

				} else if (VariablePasser.Instance.looks == 8) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");

				} else if (VariablePasser.Instance.looks == 9) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");

				} else if (VariablePasser.Instance.looks == 10) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");

				} else if (VariablePasser.Instance.looks == 11) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");

				} else if (VariablePasser.Instance.looks == 12) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");

				} else if (VariablePasser.Instance.looks == 13) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");

				} else if (VariablePasser.Instance.looks == 14) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");

			
				} else if (VariablePasser.Instance.looks == 15) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");

				} else if (VariablePasser.Instance.looks == 16) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");

				} else if (VariablePasser.Instance.looks == 17) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");

			
				} else if (VariablePasser.Instance.looks == 18) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");

			
				} else if (VariablePasser.Instance.looks == 19) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");

			
				} else if (VariablePasser.Instance.looks == 20) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");

			
				} else if (VariablePasser.Instance.looks == 21) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");

			
				} else if (VariablePasser.Instance.looks == 22) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");
			
			
				} else if (VariablePasser.Instance.looks == 23) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");

			
				} else if (VariablePasser.Instance.looks == 24) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");

			
				} else if (VariablePasser.Instance.looks == 25) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");

			
				} else if (VariablePasser.Instance.looks == 26) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");

			
				} else if (VariablePasser.Instance.looks == 27) {
						BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");
						BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");

			
				}
		}
		void Start ()
		{
				changeOrientation = false;
				VariablePasser.Instance.previousRotation = VariablePasser.PreviousRotation.Landscape;
				ChangeOrientation ();
				if (VariablePasser.Instance.playSound) {
						Volume.sliderValue = 1;
						VolumeL.sliderValue = 1;
				} else {
						Volume.sliderValue = 0;
						VolumeL.sliderValue = 0;
				}
				if (VariablePasser.Instance.playEffects) {
						EffectsVolume.sliderValue = 1;
						EffectsVolumeL.sliderValue = 1;
				} else {
						EffectsVolume.sliderValue = 0;
						EffectsVolumeL.sliderValue = 0;
				}
				if (VariablePasser.Instance.showRich) {
						RichFeatures.sliderValue = 1;
						RichFeaturesL.sliderValue = 1;
				} else {
						RichFeatures.sliderValue = 0;
						RichFeaturesL.sliderValue = 0;
				}
		}
		void Update ()
		{
				Screen.orientation = ScreenOrientation.LandscapeLeft;
		}
	
		void ChangeOrientation ()
		{
		
//				if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft && VariablePasser.Instance.previousRotation == VariablePasser.PreviousRotation.Portrait) {
//						VariablePasser.Instance.previousRotation = VariablePasser.PreviousRotation.Landscape;
//						changeOrientation = true;
//				}
		
//				if (Input.deviceOrientation == DeviceOrientation.Portrait && VariablePasser.Instance.previousRotation == VariablePasser.PreviousRotation.Landscape) {
//						VariablePasser.Instance.previousRotation = VariablePasser.PreviousRotation.Portrait;
//						changeOrientation = true;
//				}
				//For Landscape
				if (VariablePasser.Instance.previousRotation == VariablePasser.PreviousRotation.Landscape && changeOrientation) {
						LandscapeHUD.SetActive (true);
						PortraitHUD.SetActive (false);
						changeOrientation = false;
			
				}
		
				//For Potrait 
//				if (VariablePasser.Instance.previousRotation == VariablePasser.PreviousRotation.Portrait && changeOrientation) {
//						LandscapeHUD.SetActive (false);
//						;
//						PortraitHUD.SetActive (true);
//						changeOrientation = false;
//				}
		
		}
		public void OnClickPlay ()
		{
				if (File.Exists (Application.persistentDataPath + "/SaveData")) {
						ResumeButton.SetActive (true);
						ResumeButtonL.SetActive (true);
				} else {
						ResumeButton.SetActive (false);
						ResumeButtonL.SetActive (false);
				}
				ModeHUD.SetActive (true);
				MenuHUD.SetActive (false);
				ModeHUDL.SetActive (true);
				MenuHUDL.SetActive (false);
		}

		public void OnClickOptions ()
		{
				MenuHUD.SetActive (false);
				OptionsMenu.SetActive (true);
				MenuHUDL.SetActive (false);
				OptionsMenuL.SetActive (true);
		}
		public void OnClickLooks ()
		{
				LooksHUD.SetActive (true);
				LooksHUDL.SetActive (true);		
				MenuHUD.SetActive (false);
				MenuHUDL.SetActive (false);
		}
		public void OnClickStats ()
		{
				StatsHUD.SetActive (true);
				MenuHUD.SetActive (false);
				StatsHUDL.SetActive (true);
				MenuHUDL.SetActive (false);
		}
		public void OnClickHelp ()
		{
				HelpHUD.SetActive (true);
				MenuHUD.SetActive (false);
				HelpHUDL.SetActive (true);
				MenuHUDL.SetActive (false);
		}
//Mode Menu
		//Resume Button
		public void OnClickResume ()
		{
				VariablePasser.Instance.isResumable = true;
				Application.LoadLevel (2);
		}
		//Easy Button
		public void OnClickEasy ()
		{
				VariablePasser.Instance.isResumable = false;
				VariablePasser.Instance.gameMode = CardGame.GameMode.Easy;
				Stats.instance.totalGamesPlayed += 1;
				if (VariablePasser.Instance.drawCardNumber == 1) {
						Stats.instance.ESDOGamesPlayed += 1;
				} else {
						Stats.instance.ESDTGamesPlayed += 1;
				}
				Application.LoadLevel (2);
		}
	
		//Medium Button
		public void OnClickMedium ()
		{
				VariablePasser.Instance.isResumable = false;
				VariablePasser.Instance.gameMode = CardGame.GameMode.Medium;
				Stats.instance.totalGamesPlayed += 1;
				if (VariablePasser.Instance.drawCardNumber == 1) {
						Stats.instance.MSDOGamesPlayed += 1;
				} else {
						Stats.instance.MSDTGamesPlayed += 1;
				}
				Application.LoadLevel (2);
		}
	
		//Hard Button
		public void OnClickHard ()
		{
				VariablePasser.Instance.isResumable = false;
				VariablePasser.Instance.gameMode = CardGame.GameMode.Hard;
				Stats.instance.totalGamesPlayed += 1;
				if (VariablePasser.Instance.drawCardNumber == 1) {
						Stats.instance.HSDOGamesPlayed += 1;
				} else {
						Stats.instance.HSDTGamesPlayed += 1;
				}
				Application.LoadLevel (2);
		}
	
		//Draw One Card Button
		public void OnClickDrawOne ()
		{
				//DrawThreeButton.SetActive (true);
				//DrawOneButton.SetActive (false);
				DrawThreeButtonL.SetActive (true);
				DrawOneButtonL.SetActive (false);
				VariablePasser.Instance.drawCardNumber = 3;
				SavePrefs ();
		}
	
		//Draw Three Card Button
		public void OnClickDrawThree ()
		{
				//DrawThreeButton.SetActive (false);
				//DrawOneButton.SetActive (true);
				DrawThreeButtonL.SetActive (false);
				DrawOneButtonL.SetActive (true);
				VariablePasser.Instance.drawCardNumber = 1;
				SavePrefs ();
		}

		public void OnClickHome ()
		{
				ModeHUD.SetActive (false);
				MenuHUD.SetActive (true);
				ModeHUDL.SetActive (false);
				MenuHUDL.SetActive (true);
		}
//End
//Looks Menu
		public void OnClickBackLooks ()
		{
				LooksHUD.SetActive (false);
				LooksHUDL.SetActive (false);		
				MenuHUD.SetActive (true);
				MenuHUDL.SetActive (true);
		}
//Stats Menu
		public void OnClickBackStats ()
		{
				StatsHUD.SetActive (false);
				MenuHUD.SetActive (true);
				StatsHUDL.SetActive (false);
				MenuHUDL.SetActive (true);
		}
//Help Menu

		public void OnClickBackHelp ()
		{
				HelpHUD.SetActive (false);
				MenuHUD.SetActive (true);
				HelpHUDL.SetActive (false);
				MenuHUDL.SetActive (true);
		}
//Options Menu
		public void OnClickBackOptions ()
		{
				MenuHUD.SetActive (true);
				OptionsMenu.SetActive (false);
				MenuHUDL.SetActive (true);
				OptionsMenuL.SetActive (false);
		}
		public UISlider Volume;
		public UISlider EffectsVolume;
		public UISlider RichFeatures;
		public UISlider VolumeL;
		public UISlider EffectsVolumeL;
		public UISlider RichFeaturesL;
		private int bVolume = 1;
		private int bEffects = 1;
		private int bRich = 1;

		public void OnClickVolume ()
		{
				if (VariablePasser.Instance.playSound) {
						bVolume = 0;
						VariablePasser.Instance.playSound = false;
						Volume.sliderValue = 0;
						VolumeL.sliderValue = 0;
				} else {
						bVolume = 1;
						VariablePasser.Instance.playSound = true;
						Volume.sliderValue = 1;
						VolumeL.sliderValue = 1;
				}
				SavePrefs ();
		}
		public void OnClickEffects ()
		{
				if (VariablePasser.Instance.playEffects) {
						bEffects = 0;
						VariablePasser.Instance.playEffects = false;
						EffectsVolume.sliderValue = 0;
						EffectsVolumeL.sliderValue = 0;
				} else {
						bEffects = 1;
						VariablePasser.Instance.playEffects = true;
						EffectsVolume.sliderValue = 1;
						EffectsVolumeL.sliderValue = 1;
				}
				SavePrefs ();
		}
		public void OnClickRich ()
		{
				if (VariablePasser.Instance.showRich) {
						bRich = 0;
						VariablePasser.Instance.showRich = false;
						RichFeatures.sliderValue = 0;
						RichFeaturesL.sliderValue = 0;
				} else {
						bRich = 1;
						VariablePasser.Instance.showRich = true;
						RichFeatures.sliderValue = 1;
						RichFeaturesL.sliderValue = 1;
				}
				SavePrefs ();
		}
//Looks Menu
		public void OnClickLook1 ()
		{
				VariablePasser.Instance.looks = 1;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");

				SavePrefs ();
		}
		public void OnClickLook2 ()
		{
				VariablePasser.Instance.looks = 2;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");
				SavePrefs ();
		}
		public void OnClickLook3 ()
		{
				VariablePasser.Instance.looks = 3;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");
				SavePrefs ();
		}
		public void OnClickLook4 ()
		{
				VariablePasser.Instance.looks = 4;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");
				SavePrefs ();
		}
		public void OnClickLook5 ()
		{
				VariablePasser.Instance.looks = 5;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");
				SavePrefs ();
		}
		public void OnClickLook6 ()
		{
				VariablePasser.Instance.looks = 6;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");
				SavePrefs ();
		}
		public void OnClickLook7 ()
		{
				VariablePasser.Instance.looks = 7;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");
				SavePrefs ();
		}
		public void OnClickLook8 ()
		{
				VariablePasser.Instance.looks = 8;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");
				SavePrefs ();
		}
		public void OnClickLook9 ()
		{
				VariablePasser.Instance.looks = 9;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");
				SavePrefs ();
		}
		public void OnClickLook10 ()
		{
				VariablePasser.Instance.looks = 10;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");
				SavePrefs ();
		}
		public void OnClickLook11 ()
		{
				VariablePasser.Instance.looks = 11;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");
				SavePrefs ();
		}
		public void OnClickLook12 ()
		{
				VariablePasser.Instance.looks = 12;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");
				SavePrefs ();
		}
		public void OnClickLook13 ()
		{
				VariablePasser.Instance.looks = 13;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");
				SavePrefs ();
		}
		public void OnClickLook14 ()
		{
				VariablePasser.Instance.looks = 14;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");
				SavePrefs ();
		}
		public void OnClickLook15 ()
		{
				VariablePasser.Instance.looks = 15;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");
				SavePrefs ();
		}
		public void OnClickLook16 ()
		{
				VariablePasser.Instance.looks = 16;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");
				SavePrefs ();
		}
		public void OnClickLook17 ()
		{
				VariablePasser.Instance.looks = 17;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");

				SavePrefs ();
		}
		public void OnClickLook18 ()
		{
				VariablePasser.Instance.looks = 18;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");

				SavePrefs ();
		}
		public void OnClickLook19 ()
		{
				VariablePasser.Instance.looks = 19;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");

				SavePrefs ();
		}
		public void OnClickLook20 ()
		{
				VariablePasser.Instance.looks = 20;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");

				SavePrefs ();
		}
		public void OnClickLook21 ()
		{
				VariablePasser.Instance.looks = 21;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");

				SavePrefs ();
		}
		public void OnClickLook22 ()
		{
				VariablePasser.Instance.looks = 21;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");

				SavePrefs ();
		}
		public void OnClickLook23 ()
		{
				VariablePasser.Instance.looks = 21;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");

				SavePrefs ();
		}
		public void OnClickLook24 ()
		{
				VariablePasser.Instance.looks = 21;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");

				SavePrefs ();
		}
		public void OnClickLook25 ()
		{
				VariablePasser.Instance.looks = 21;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");

				SavePrefs ();
		}
		public void OnClickLook26 ()
		{
				VariablePasser.Instance.looks = 21;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");

				SavePrefs ();
		}
		public void OnClickLook27 ()
		{
				VariablePasser.Instance.looks = 21;
				BackGroundP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");
				BackGroundL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");

				SavePrefs ();
		}

		public void OnClickMoreGames ()
		{
		          
				//Application.OpenURL ("itms-apps://itunes.apple.com/us/artist/oets-games/id901669312");
				Application.OpenURL (GameConstants.MORE_GAMES_URL);
		}

		public void OnClickRateUs ()
		{
				Application.OpenURL (GameConstants.RATE_US_URL);
		}
		public void OnClickGameCenter ()
		{
		
				//GameCenterBinding.showLeaderboardWithTimeScope( GameCenterLeaderboardTimeScope.AllTime );
		}

//End
		void SavePrefs ()
		{
				PlayerPrefs.SetInt ("Slider", bVolume);
				PlayerPrefs.SetInt ("Slider1", bEffects);
				PlayerPrefs.SetInt ("Slider2", bRich);
				PlayerPrefs.SetInt ("Looks", VariablePasser.Instance.looks);
				PlayerPrefs.SetInt ("DrawCardNumber", VariablePasser.Instance.drawCardNumber);
		}

}
