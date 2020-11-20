using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class VariablePasser : MonoBehaviour
{
	public static VariablePasser Instance;

	public bool underTween = false;

	public enum PreviousRotation
	{
		Landscape =0,
		Portrait}
	;

	public  PreviousRotation previousRotation = PreviousRotation.Landscape;

	public CardGame.GameMode gameMode;
	public int drawCardNumber;
	public bool isResumable;
	public int looks;
	public bool playSound;
	public bool playEffects;
	public bool showRich;

	void Awake ()
	{
		if (Instance == null) {
			Instance = this;
			new Stats ();
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}

		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			System.Environment.SetEnvironmentVariable ("MONO_REFLECTION_SERIALIZER", "yes");
		}

		previousRotation = PreviousRotation.Landscape;

		//Load Stats File Here
		//For More Updated Stats
		LoadStats ();

		if (!PlayerPrefs.HasKey ("VolumeControl")) {
			PlayerPrefs.SetInt ("VolumeControl", 1);
			PlayerPrefs.SetInt ("EffectsControl", 1);
			PlayerPrefs.SetInt ("ShowRichFeatures", 1);
		}

		if (PlayerPrefs.GetInt ("VolumeControl") == 1) {
			playSound = true;
		} else
			playSound = false;
		if (PlayerPrefs.GetInt ("EffectsControl") == 1) {
			playEffects = true;
		} else
			playEffects = false;

		if (PlayerPrefs.GetInt ("ShowRichFeatures") == 1) {
			showRich = true;
		} else
			showRich = false;
	}

	// Use this for initialization
	void Start ()
	{

		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToPortrait = true;
	}

	public void SaveStats ()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/saveStats");
		bf.Serialize (file, Stats.instance);
		file.Close ();
	}

	public void LoadStats ()
	{
		if (File.Exists (Application.persistentDataPath + "/saveStats")) {
			//			NGUIDebug.Log("Level Load");
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/saveStats", FileMode.Open);
			Stats.instance = (Stats)bf.Deserialize (file);
			file.Close ();
		}
	}
	void OnApplicationPause ()
	{

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

	}
}