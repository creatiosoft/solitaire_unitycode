using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUD : MonoBehaviour
{
	public static HUD instance;
	public GameObject masterGameObject;
	public GameObject backgroundMainP;
	public GameObject backgroundMainL;
	//Portrait
	public GameObject optionsHUD;
	public GameObject optionsBackCollider;
	public GameObject optionsScreenRotation;
	public GameObject optionsScreenRotationWithLock;
	public GameObject gamePlayHUD;
	public GameObject optionMenu;
	public UILabel moveLabel;
	public UILabel scoreLabel;
	public UILabel timeLabel;
	public UILabel multiplierLabel;
	public GameObject startPlayText;
	public GameObject gamePlayTopButtons;
	public GameObject gameCompleteHUDP;
	public GameObject richFeatures;
	//Game Complete Screen
	public UILabel bestScore;
	public UILabel gamesPlayed;
	public UILabel GamesWon;
	public UILabel gEndScore;
	public UILabel gEndPlayTime;
	public UILabel gEndMoves;
	//End
	//End
	//LandScape
	public GameObject optionsHUDL;
	public GameObject optionsBackColliderL;
	public GameObject optionsScreenRotationL;
	public GameObject optionsScreenRotationWithLockL;
	public GameObject gamePlayHUDL;
	public GameObject optionMenuL;
	public UILabel moveLabelL;
	public UILabel scoreLabelL;
	public UILabel timeLabelL;
	public UILabel multiplierLabelL;
	public GameObject startPlayTextL;
	public GameObject gamePlayTopButtonsL;
	public GameObject gameCompleteHUDL;
	public GameObject richFeaturesL;
	//Game Complete Screen
	public UILabel bestScoreL;
	public UILabel gamesPlayedL;
	public UILabel GamesWonL;
	public UILabel gEndScoreL;
	public UILabel gEndPlayTimeL;
	public UILabel gEndMovesL;
	//End
	public GameObject bgL;
	public GameObject bgP;
	public GameObject bg1L;
	public GameObject bg1P;
	private bool showOptions = true;
	//End
	private bool checkGameCompleted = true;
	public float startTextHideTime;
	public float hideTime;
	private DateTime startTime;
	private TimeSpan previousTime;
	private int previousMoves;
	private int previousScore;
	private int previousMultiplier;
	private float scoreMultiplierTimer;

	// Use this for initialization
	void Awake ()
	{
		instance = this;

		bVolume = PlayerPrefs.GetInt ("Slider");
		bEffects = PlayerPrefs.GetInt ("Slider1");
		bRich = PlayerPrefs.GetInt ("Slider2");
		//BackGround Settings
		if (VariablePasser.Instance.looks == 1) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");
		
		} else if (VariablePasser.Instance.looks == 2) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");
			
		} else if (VariablePasser.Instance.looks == 3) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");
			
		} else if (VariablePasser.Instance.looks == 4) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");

		} else if (VariablePasser.Instance.looks == 5) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");

		} else if (VariablePasser.Instance.looks == 6) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");

		} else if (VariablePasser.Instance.looks == 7) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");

		} else if (VariablePasser.Instance.looks == 8) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");

		} else if (VariablePasser.Instance.looks == 9) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");

		} else if (VariablePasser.Instance.looks == 10) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");

		} else if (VariablePasser.Instance.looks == 11) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");

		} else if (VariablePasser.Instance.looks == 12) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");

		} else if (VariablePasser.Instance.looks == 13) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");

		} else if (VariablePasser.Instance.looks == 14) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");
			
		} else if (VariablePasser.Instance.looks == 15) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");

		} else if (VariablePasser.Instance.looks == 16) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");

		} else if (VariablePasser.Instance.looks == 17) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");

			
		} else if (VariablePasser.Instance.looks == 18) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");			
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");

			
		} else if (VariablePasser.Instance.looks == 19) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");			
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_1");

			
		} else if (VariablePasser.Instance.looks == 20) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");
			
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_2");

			
		} else if (VariablePasser.Instance.looks == 21) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");
			
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_3");

			
		} else if (VariablePasser.Instance.looks == 22) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");
			
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_4");

			
		} else if (VariablePasser.Instance.looks == 23) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");
			
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_5");

			
		} else if (VariablePasser.Instance.looks == 24) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_6");

			
		} else if (VariablePasser.Instance.looks == 25) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_7");

			
		} else if (VariablePasser.Instance.looks == 26) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_8");

			
		} else if (VariablePasser.Instance.looks == 27) {
			bgP.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");
			bgL.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");
			bg1P.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");
			bg1L.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");
			backgroundMainP.renderer.sharedMaterial.mainTexture = Resources.Load<Texture2D> ("Textures/Bg_9");			
		}
	}
	void Start ()
	{
		startTime = DateTime.Now;
		if (VariablePasser.Instance.isResumable) {
			TimeSpan t1 = TimeSpan.FromMinutes (Stats.instance.currentTimeMinutes);
			TimeSpan t2 = TimeSpan.FromSeconds (Stats.instance.currentTimeSeconds);
			previousTime = previousTime.Add (t1);
			previousTime = previousTime.Add (t2);
			previousScore = Stats.instance.currentScore;
			previousMoves = Stats.instance.currentMoves;
			previousScore = Stats.instance.currentScore;
			previousMultiplier = Stats.instance.currentScoreMultiplier;
		
		} else {
			previousTime = new TimeSpan (0, 0, 0);
			previousScore = 0;
			previousMoves = 0;
			previousScore = 0;
			previousMultiplier = 100;
		}
//		Debug.Log ("previous Time" + previousTime.Minutes.ToString() +":" + previousTime.Seconds.ToString());
		CardGame.instance.moves += previousMoves;
		CardGame.instance.nScore += previousScore;
		CardGame.instance.scoreMultiplier = previousMultiplier;
		scoreMultiplierTimer = Time.time + 5.0f;
		//Option Menu
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
		//ENd
	}




//	
//	// Update is called once per frame
	void Update ()
	{
		if (startTextHideTime > 0)
			startTextHideTime -= Time.deltaTime;
		else {
			TweenAlpha.Begin (startPlayText.transform.GetChild (0).gameObject, hideTime, 0);
			TweenAlpha.Begin (startPlayText.transform.GetChild (1).gameObject, hideTime, 0);
			TweenAlpha.Begin (startPlayText.transform.GetChild (2).gameObject, hideTime, 0);
			TweenAlpha.Begin (startPlayTextL.transform.GetChild (0).gameObject, hideTime, 0);
			TweenAlpha.Begin (startPlayTextL.transform.GetChild (1).gameObject, hideTime, 0);
			TweenAlpha.Begin (startPlayTextL.transform.GetChild (2).gameObject, hideTime, 0);
		}

		TimeSpan t = DateTime.Now.Subtract (startTime);
		t = t.Add (previousTime);
		
		timeLabel.text = string.Format ("{0}:{1}", t.Minutes, t.Seconds);//,DateTime.Now.Millisecond);
		timeLabelL.text = string.Format ("{0}:{1}", t.Minutes, t.Seconds);
	
		moveLabel.text = (CardGame.instance.moves).ToString ();
		moveLabelL.text = (CardGame.instance.moves).ToString ();
		scoreLabel.text = CardGame.instance.nScore.ToString ();
		scoreLabelL.text = CardGame.instance.nScore.ToString ();
		multiplierLabel.text = "X " + CardGame.instance.scoreMultiplier.ToString ();
		multiplierLabelL.text = "X " + CardGame.instance.scoreMultiplier.ToString ();
		if (scoreMultiplierTimer <= Time.time) {
			scoreMultiplierTimer = (Time.time + 5f);
			if (CardGame.instance.scoreMultiplier > 0)
				CardGame.instance.scoreMultiplier -= 1;
		}

		//Game Complete Code
		if (CardGame.instance.bCheckGameOver () && checkGameCompleted) {
			checkGameCompleted = false;
//			Debug.Log ("Game Completed");
			gamePlayHUD.SetActive (false);
			gamePlayHUDL.SetActive (false);
			gamePlayTopButtons.SetActive (false);
			gamePlayTopButtonsL.SetActive (false);
			gameCompleteHUDL.SetActive (true);
			gameCompleteHUDP.SetActive (true);
			if (VariablePasser.Instance.playEffects)
				CardGame.instance.audio.PlayOneShot (CardGame.instance.applauseSound);
			//Game Completed
			//Stats
			Stats.instance.totalGamesWon += 1;
			if (CardGame.instance.nScore > Stats.instance.totalBestScore) {
				Stats.instance.totalBestScore = CardGame.instance.nScore;
			}
			if (VariablePasser.Instance.gameMode == CardGame.GameMode.Easy) {
				if (VariablePasser.Instance.drawCardNumber == 1) {
					Stats.instance.ESDOGamesWon += 1;
					if (CardGame.instance.nScore > Stats.instance.ESDOBestScore) {
						Stats.instance.ESDOBestScore = CardGame.instance.nScore;
					}
					if (CardGame.instance.moves < Stats.instance.ESDOMoves) {
						Stats.instance.ESDOMoves = CardGame.instance.moves;
					}
				} else {
					Stats.instance.ESDTGamesWon += 1;
					if (CardGame.instance.nScore > Stats.instance.ESDTBestScore) {
						Stats.instance.ESDTBestScore = CardGame.instance.nScore;
					}
					if (CardGame.instance.moves < Stats.instance.ESDTMoves) {
						Stats.instance.ESDTMoves = CardGame.instance.moves;
					}
				}
			} else if (VariablePasser.Instance.gameMode == CardGame.GameMode.Medium) {
				if (VariablePasser.Instance.drawCardNumber == 1) {
					Stats.instance.MSDOGamesWon += 1;
					if (CardGame.instance.nScore > Stats.instance.MSDOBestScore) {
						Stats.instance.MSDOBestScore = CardGame.instance.nScore;
					}
					if (CardGame.instance.moves < Stats.instance.MSDOMoves) {
						Stats.instance.MSDOMoves = CardGame.instance.moves;
					}
				} else {
					Stats.instance.MSDTGamesWon += 1;
					if (CardGame.instance.nScore > Stats.instance.MSDTBestScore) {
						Stats.instance.MSDTBestScore = CardGame.instance.nScore;
					}
					if (CardGame.instance.moves < Stats.instance.MSDTMoves) {
						Stats.instance.MSDTMoves = CardGame.instance.moves;
					}
				}
			} else if (VariablePasser.Instance.gameMode == CardGame.GameMode.Hard) {
				if (VariablePasser.Instance.drawCardNumber == 1) {
					Stats.instance.HSDOGamesWon += 1;
					if (CardGame.instance.nScore > Stats.instance.HSDOBestScore) {
						Stats.instance.HSDOBestScore = CardGame.instance.nScore;
					}
					if (CardGame.instance.moves < Stats.instance.HSDOMoves) {
						Stats.instance.HSDOMoves = CardGame.instance.moves;
					}
				} else {
					Stats.instance.HSDTGamesWon += 1;
					if (CardGame.instance.nScore > Stats.instance.HSDTBestScore) {
						Stats.instance.HSDTBestScore = CardGame.instance.nScore;
					}
					if (CardGame.instance.moves < Stats.instance.HSDTMoves) {
						Stats.instance.HSDTMoves = CardGame.instance.moves;
					}
				}
			}
			//ENd
			//Stats System
			bestScore.text = Stats.instance.totalBestScore.ToString ();
			gamesPlayed.text = Stats.instance.totalGamesPlayed.ToString ();
			GamesWon.text = Stats.instance.totalGamesWon.ToString ();
			bestScoreL.text = Stats.instance.totalBestScore.ToString ();
			gamesPlayedL.text = Stats.instance.totalGamesPlayed.ToString ();
			GamesWonL.text = Stats.instance.totalGamesWon.ToString ();
			gEndScore.text = CardGame.instance.nScore.ToString ();
			gEndMoves.text = CardGame.instance.moves.ToString ();
			gEndScoreL.text = CardGame.instance.nScore.ToString ();
			gEndMovesL.text = CardGame.instance.moves.ToString ();
			//Time
			TimeSpan t2 = DateTime.Now.Subtract (startTime);
			TimeSpan t3 = previousTime.Add (t2);
			gEndPlayTime.text = string.Format ("{0}:{1}", t3.Minutes.ToString (), t3.Seconds.ToString ());
			gEndPlayTime.text = string.Format ("{0}:{1}", t3.Minutes.ToString (), t3.Seconds.ToString ());
			//End
			//Remove Save File
			if (File.Exists (Application.persistentDataPath + "/SaveData")) {
				File.Delete (Application.persistentDataPath + "/SaveData");
			}
			//Game Centre 
			//Hard
			//Stats.instance.HSDTBestScore
			//Easy
			
			if (VariablePasser.Instance.gameMode == CardGame.GameMode.Easy) {
				if (VariablePasser.Instance.drawCardNumber == 1) {
	
					//	Stats.instance.ESDOBestScore 
					if (!(iPhoneSettings.internetReachability == iPhoneNetworkReachability.NotReachable)) {
					}
					//GameCenterBinding.reportScore (Stats.instance.ESDOBestScore, gameCenterInit._leaderboards [2].leaderboardId);

				} else {

					//Stats.instance.ESDTBestScore 
					if (!(iPhoneSettings.internetReachability == iPhoneNetworkReachability.NotReachable)) {
					}
					//GameCenterBinding.reportScore (Stats.instance.ESDTBestScore, gameCenterInit._leaderboards [2].leaderboardId);
				}
			} else if (VariablePasser.Instance.gameMode == CardGame.GameMode.Medium) {
				if (VariablePasser.Instance.drawCardNumber == 1) {
					if (!(iPhoneSettings.internetReachability == iPhoneNetworkReachability.NotReachable)) {
					}
					//GameCenterBinding.reportScore (Stats.instance.MSDOBestScore, gameCenterInit._leaderboards [1].leaderboardId);

					//Stats.instance.MSDOBestScore 
				

				} else {
					if (!(iPhoneSettings.internetReachability == iPhoneNetworkReachability.NotReachable)) {
					}
					//GameCenterBinding.reportScore (Stats.instance.MSDTBestScore, gameCenterInit._leaderboards [1].leaderboardId);

					//Stats.instance.MSDTBestScore 
	
				}
			} else if (VariablePasser.Instance.gameMode == CardGame.GameMode.Hard) {
				if (VariablePasser.Instance.drawCardNumber == 1) {
					
					//Stats.instance.HSDOBestScore
					if (!(iPhoneSettings.internetReachability == iPhoneNetworkReachability.NotReachable)) {
					}
					//GameCenterBinding.reportScore (Stats.instance.HSDOBestScore, gameCenterInit._leaderboards [0].leaderboardId);
					
				} else {
					if (!(iPhoneSettings.internetReachability == iPhoneNetworkReachability.NotReachable)) {
					}
					//GameCenterBinding.reportScore (Stats.instance.HSDTBestScore, gameCenterInit._leaderboards [0].leaderboardId);

					//Stats.instance.HSDTBestScore
				

				}
			}
			//End
		}

		if (VariablePasser.Instance.showRich) {
			richFeaturesL.SetActive (true);
			richFeatures.SetActive (true);
		} else {
			richFeatures.SetActive (false);
			richFeaturesL.SetActive (false);
		}
	}


	void StopAutoRotate ()
	{
		//Only Effective for Game Scene
		//Can Work if AutoRotate stopped
		LayoutClass.instance.freezeRotation = !LayoutClass.instance.freezeRotation;
		Screen.autorotateToPortrait = !Screen.autorotateToPortrait;
		Screen.autorotateToLandscapeLeft = !Screen.autorotateToLandscapeLeft;

	}
	void OnClickUndo ()
	{
		UndoClass.instance.UndoMove ();
	}

	void OnClickHint ()
	{
		masterGameObject.GetComponent<Hint> ().CheckMoves ();
	}

	void OnClickRestart ()
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
				DialogManager.Instance.SetLabel ("Yes", "No", "No");
				DialogManager.Instance.ShowSelectDialog ("Restart Game", "Do you want to restart the game?", (bool result) => {
						if (result) {
								Debug.Log ("Restarting App");

								VariablePasser.Instance.isResumable = false;
								//Stats
								Stats.instance.totalGamesPlayed += 1;
								if (VariablePasser.Instance.gameMode == CardGame.GameMode.Easy) {
										if (VariablePasser.Instance.drawCardNumber == 1) {
												Stats.instance.ESDOGamesPlayed += 1;
										} else {
												Stats.instance.ESDTGamesPlayed += 1;
										}
								} else if (VariablePasser.Instance.gameMode == CardGame.GameMode.Medium) {
										if (VariablePasser.Instance.drawCardNumber == 1) {
												Stats.instance.MSDOGamesPlayed += 1;
										} else {
												Stats.instance.MSDTGamesPlayed += 1;
										}
								} else if (VariablePasser.Instance.gameMode == CardGame.GameMode.Hard) {
										if (VariablePasser.Instance.drawCardNumber == 1) {
												Stats.instance.HSDOGamesPlayed += 1;
										} else {
												Stats.instance.HSDTGamesPlayed += 1;
										}
								}
								//ENd
								VariablePasser.Instance.previousRotation = (VariablePasser.PreviousRotation)LayoutClass.instance.previousRotation;
								VariablePasser.Instance.SaveStats ();
								Application.LoadLevel (Application.loadedLevel);
						}
				});
		#elif UNITY_EDITOR
		VariablePasser.Instance.isResumable = false;
		//Stats
		Stats.instance.totalGamesPlayed += 1;
		if (VariablePasser.Instance.gameMode == CardGame.GameMode.Easy) {
			if (VariablePasser.Instance.drawCardNumber == 1) {
				Stats.instance.ESDOGamesPlayed += 1;
			} else {
				Stats.instance.ESDTGamesPlayed += 1;
			}
		} else if (VariablePasser.Instance.gameMode == CardGame.GameMode.Medium) {
			if (VariablePasser.Instance.drawCardNumber == 1) {
				Stats.instance.MSDOGamesPlayed += 1;
			} else {
				Stats.instance.MSDTGamesPlayed += 1;
			}
		} else if (VariablePasser.Instance.gameMode == CardGame.GameMode.Hard) {
			if (VariablePasser.Instance.drawCardNumber == 1) {
				Stats.instance.HSDOGamesPlayed += 1;
			} else {
				Stats.instance.HSDTGamesPlayed += 1;
			}
		}
		//ENd
		VariablePasser.Instance.previousRotation = (VariablePasser.PreviousRotation)LayoutClass.instance.previousRotation;
		VariablePasser.Instance.SaveStats ();
		Application.LoadLevel (Application.loadedLevel);
		#endif
	}

	public void OnClickHome ()
	{		
		#if UNITY_ANDROID && !UNITY_EDITOR
				DialogManager.Instance.SetLabel ("Yes", "No", "No");
				DialogManager.Instance.ShowSelectDialog ("Back to Main Menu", "Do you want to go back to the main menu?", (bool result) => {
						if (result) {
								Debug.Log ("Back To Main Menu");
								PlayerPrefs.SetInt ("firstdisplay", 1);// code used by nishank for ad
								PlayerPrefs.SetInt ("addisplay", 0);// code used by nishank for ad
        
								Screen.autorotateToPortrait = true;
								Screen.autorotateToLandscapeLeft = true;
								LayoutClass.instance.freezeRotation = false;
								//Save Time
								TimeSpan t2 = DateTime.Now.Subtract (startTime);
								previousTime = previousTime.Add (t2);
								Stats.instance.currentTimeMinutes = previousTime.Minutes;
								Stats.instance.currentTimeSeconds = previousTime.Seconds;
								//End
								//Save Moves
								Stats.instance.currentMoves = CardGame.instance.moves;
								//End
								//Save Score and Multiplier
								Stats.instance.currentScoreMultiplier = CardGame.instance.scoreMultiplier;
								Stats.instance.currentScore = CardGame.instance.nScore;
								//End
								SaveGameClass.instance.SaveGame ();
								VariablePasser.Instance.previousRotation = (VariablePasser.PreviousRotation)LayoutClass.instance.previousRotation;
								VariablePasser.Instance.SaveStats ();
								Application.LoadLevel (1);
						}
				});
		#elif UNITY_EDITOR
		PlayerPrefs.SetInt ("firstdisplay", 1);// code used by nishank for ad
		PlayerPrefs.SetInt ("addisplay", 0);// code used by nishank for ad
		
		Screen.autorotateToPortrait = true;
		Screen.autorotateToLandscapeLeft = true;
		LayoutClass.instance.freezeRotation = false;
		//Save Time
		TimeSpan t2 = DateTime.Now.Subtract (startTime);
		previousTime = previousTime.Add (t2);
		Stats.instance.currentTimeMinutes = previousTime.Minutes;
		Stats.instance.currentTimeSeconds = previousTime.Seconds;
		//End
		//Save Moves
		Stats.instance.currentMoves = CardGame.instance.moves;
		//End
		//Save Score and Multiplier
		Stats.instance.currentScoreMultiplier = CardGame.instance.scoreMultiplier;
		Stats.instance.currentScore = CardGame.instance.nScore;
		//End
		SaveGameClass.instance.SaveGame ();
		VariablePasser.Instance.previousRotation = (VariablePasser.PreviousRotation)LayoutClass.instance.previousRotation;
		VariablePasser.Instance.SaveStats ();
		Application.LoadLevel (1);
		#endif				
	}

	void OnClickShowOptions ()
	{
		if (showOptions) {
			showOptions = false;
			gamePlayHUD.SetActive (false);
			gamePlayHUDL.SetActive (false);
			optionsBackCollider.SetActive (true);
			optionsBackColliderL.SetActive (true);
			iTween.MoveTo (optionsHUD.transform.GetChild (0).gameObject, iTween.Hash ("y", 191.0f, "islocal", true, "time", 0.7f));
			iTween.MoveTo (optionsHUDL.transform.GetChild (0).gameObject, iTween.Hash ("y", 260.0f, "islocal", true, "time", 0.7f));
		} else {
			showOptions = true;
			gamePlayHUD.SetActive (true);
			gamePlayHUDL.SetActive (true);
			optionsBackCollider.SetActive (false);
			optionsBackColliderL.SetActive (false);
			iTween.MoveTo (optionsHUD.transform.GetChild (0).gameObject, iTween.Hash ("y", -254.0f, "islocal", true, "time", 0.7f, "ignoretimescale", true));
			iTween.MoveTo (optionsHUDL.transform.GetChild (0).gameObject, iTween.Hash ("y", -372.0f, "islocal", true, "time", 0.7f, "ignoretimescale", true));
		}
	}

	void OnClickOptions ()
	{
		Time.timeScale = 0;
		TimeSpan t2 = DateTime.Now.Subtract (startTime);
		previousTime = previousTime.Add (t2);
		optionsBackCollider.SetActive (false);
		optionsBackColliderL.SetActive (false);
//		Debug.Log ("previous Time" + previousTime.Minutes.ToString() +":" + previousTime.Seconds.ToString());
//		Debug.Log ("previous Time" + t2.Minutes.ToString() +":" + t2.Seconds.ToString());

		Stats.instance.currentTimeMinutes = previousTime.Minutes;
		Stats.instance.currentTimeSeconds = previousTime.Seconds;
	
//		Debug.Log ("previous Time" + Stats.instance.currentTimeMinutes +":" + Stats.instance.currentTimeSeconds);
		iTween.MoveTo (optionsHUD.transform.GetChild (0).gameObject, iTween.Hash ("y", -254.0f, "islocal", true, "time", 0.3f, "ignoretimescale", true));
		iTween.MoveTo (optionsHUDL.transform.GetChild (0).gameObject, iTween.Hash ("y", -372.0f, "islocal", true, "time", 0.3f, "ignoretimescale", true));
		gamePlayTopButtons.SetActive (false);
		gamePlayTopButtonsL.SetActive (false);
		optionMenu.SetActive (true);
		optionMenuL.SetActive (true);
		bgL.SetActive (true);
		bgP.SetActive (true);
	}


	void OnClickStopAutoRotate ()
	{
		bool isActive = optionsScreenRotation.activeSelf;
		optionsScreenRotation.SetActive (!isActive);
		optionsScreenRotationWithLock.SetActive (isActive);
		optionsScreenRotationL.SetActive (!isActive);
		optionsScreenRotationWithLockL.SetActive (isActive);
		StopAutoRotate ();
	}

	//Options Menu
	void OnClickBackOptions ()
	{
		startTime = DateTime.Now;
		bgL.SetActive (false);
		bgP.SetActive (false);
		Time.timeScale = 1;
		gamePlayHUD.SetActive (true);
		gamePlayHUDL.SetActive (true);
		gamePlayTopButtons.SetActive (true);
		gamePlayTopButtonsL.SetActive (true);
		optionMenu.SetActive (false);
		optionMenuL.SetActive (false);
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
	
	void OnClickVolume ()
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
	void OnClickEffects ()
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
	void OnClickRich ()
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
	void SavePrefs ()
	{
		PlayerPrefs.SetInt ("Slider", bVolume);
		PlayerPrefs.SetInt ("Slider1", bEffects);
		PlayerPrefs.SetInt ("Slider2", bRich);
	}
	//Game Complete
	void OnClickNewGameGP ()
	{
		VariablePasser.Instance.isResumable = false;
		//Stats
		Stats.instance.totalGamesPlayed += 1;
		if (VariablePasser.Instance.gameMode == CardGame.GameMode.Easy) {
			if (VariablePasser.Instance.drawCardNumber == 1) {
				Stats.instance.ESDOGamesPlayed += 1;
			} else {
				Stats.instance.ESDTGamesPlayed += 1;
			}
		} else if (VariablePasser.Instance.gameMode == CardGame.GameMode.Medium) {
			if (VariablePasser.Instance.drawCardNumber == 1) {
				Stats.instance.MSDOGamesPlayed += 1;
			} else {
				Stats.instance.MSDTGamesPlayed += 1;
			}
		} else if (VariablePasser.Instance.gameMode == CardGame.GameMode.Hard) {
			if (VariablePasser.Instance.drawCardNumber == 1) {
				Stats.instance.HSDOGamesPlayed += 1;
			} else {
				Stats.instance.HSDTGamesPlayed += 1;
			}
		}
		//ENd
		VariablePasser.Instance.previousRotation = (VariablePasser.PreviousRotation)LayoutClass.instance.previousRotation;
		VariablePasser.Instance.SaveStats ();
		Application.LoadLevel (Application.loadedLevel);
	}
	void OnClickHomeGP ()
	{
//		//Save Time
//		TimeSpan t2 = DateTime.Now.Subtract(startTime);
//		previousTime = previousTime.Add(t2);
//		Stats.instance.currentTimeMinutes = previousTime.Minutes;
//		Stats.instance.currentTimeSeconds = previousTime.Seconds;
//		//End
//		//Save Moves
//		Stats.instance.currentMoves = CardGame.instance.moves;
//		//End
//		//Save Score and Multiplier
//		Stats.instance.currentScoreMultiplier = CardGame.instance.scoreMultiplier;
//		Stats.instance.currentScore = CardGame.instance.nScore;
//		//End
		VariablePasser.Instance.SaveStats ();
		VariablePasser.Instance.previousRotation = (VariablePasser.PreviousRotation)LayoutClass.instance.previousRotation;
		Application.LoadLevel (1);
	}
	void OnApplicationPause (bool pauseStatus)
	{

		//Time Save
		if (pauseStatus) {
			TimeSpan t2 = DateTime.Now.Subtract (startTime);
			previousTime = previousTime.Add (t2);
			Stats.instance.currentTimeMinutes = previousTime.Minutes;
			Stats.instance.currentTimeSeconds = previousTime.Seconds;
			//End
			//Save Moves
			Stats.instance.currentMoves = CardGame.instance.moves;
			//End
			//Save Score and Multiplier
			Stats.instance.currentScoreMultiplier = CardGame.instance.scoreMultiplier;
			Stats.instance.currentScore = CardGame.instance.nScore;

			if (VariablePasser.Instance.playEffects) {
				PlayerPrefs.SetInt ("EffectsControl", 1);
			} else
				PlayerPrefs.SetInt ("EffectsControl", 0);
		
			if (VariablePasser.Instance.playSound) {
				PlayerPrefs.SetInt ("VolumeControl", 1);
			} else
				PlayerPrefs.SetInt ("VolumeControl", 0);

			if (VariablePasser.Instance.showRich) {
				PlayerPrefs.SetInt ("ShowRichFeatures", 1);
			} else
				PlayerPrefs.SetInt ("ShowRichFeatures", 0);

			//End
		} else
			startTime = DateTime.Now;
	}
}
