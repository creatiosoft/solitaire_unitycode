using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveGameClass : MonoBehaviour
{
	public static SaveGameClass instance;
	public bool Save = false;
	public bool Load = false;
	public bool cOrientation = false;

	void Awake ()
	{
		instance = this;

		if (VariablePasser.Instance.isResumable)
			LoadGame ();
	}

	[System.Serializable]
	public class SaveData
	{
		//Card Game Variables
		public bool bSetupDone = false;
		public CardGame.Deck oDrawDeck;
		public CardGame.Deck oDrawDeckHidden;
		public CardGame.Deck oDrawDeckCards;
		
		public CardGame.Deck oDiscardDeck;
		public List <CardGame.Deck> oGameDecks = new List<CardGame.Deck> ();
		public float bStartTime, bEndTime;
		public int nScore = 0;
		public CardGame.GameMode gameMode;
		public int drawCardNumber;
		//End

		//Undo Class
		public Stack<UndoClass.UndoVariables> bUndoStack = new Stack<UndoClass.UndoVariables> ();
		//End

		public SaveData (bool setupDone, CardGame.Deck drawDeck, CardGame.Deck drawDeckHidden, CardGame.Deck drawDeckCards,
		                 CardGame.Deck discardDeck, List<CardGame.Deck> gameDecks, float startTime, float endTime,
		                 int score, Stack<UndoClass.UndoVariables> undoStack, CardGame.GameMode tGameMode, int tDrawCardNumber)
		{
			bSetupDone = setupDone;
			oDrawDeck = drawDeck;
			oDrawDeckHidden = drawDeckHidden;
			oDrawDeckCards = drawDeckCards;
			oDiscardDeck = discardDeck;
			oGameDecks = gameDecks;
			bStartTime = startTime;
			bEndTime = endTime;
			nScore = score;
			bUndoStack = undoStack;
			gameMode = tGameMode;
			drawCardNumber = tDrawCardNumber;
		}
	}

	[HideInInspector]
	public SaveData
		data;
	[HideInInspector]
	public SaveData
		loadData;

	public void SaveGame ()
	{
		CardGame instance = CardGame.instance;
		UndoClass undoClassInstance = UndoClass.instance;
		data = new SaveData (true, instance.oDrawDeck, instance.oDrawDeckHidden, instance.oDrawDeckCards,
			instance.oDiscardDeck, instance.oGameDecks, instance.startTime, instance.endTime,
			instance.nScore, undoClassInstance.UndoStack, instance.gameMode, instance.drawCardNumber);

		//Saving To File
		SaveFile ();
		//End
	}

	public void LoadGame ()
	{
		ReadFile ();
	}

	void SaveFile ()
	{
		FileStream f = new FileStream (Application.persistentDataPath + "/SaveData", FileMode.Create, FileAccess.Write, FileShare.Write);
		BinaryFormatter b = new BinaryFormatter ();
		b.Serialize (f, data);
		f.Close ();
	}

	void ReadFile ()
	{
		if (File.Exists (Application.persistentDataPath + "/SaveData")) {
//			FileStream f = new FileStream(Application.persistentDataPath + "/SaveData",FileMode.Open);
			FileStream f = File.Open (Application.persistentDataPath + "/SaveData", FileMode.Open);
			BinaryFormatter b = new BinaryFormatter ();
			loadData = (SaveData)b.Deserialize (f);
			f.Close ();
			Debug.Log ("File Loaded");
		
		}
	}

	//	//Card Game Variables
	//	public bool bSetupDone = false;
	//	public CardGame.Deck oDrawDeck;
	//	public CardGame.Deck oDrawDeckHidden;
	//	public CardGame.Deck oDrawDeckCards;
	//
	//	public CardGame.Deck oDiscardDeck;
	//	public List <CardGame.Deck> oGameDecks = new List<CardGame.Deck>();
	//	public float bStartTime, bEndTime;
	//	public int nScore = 0;
	//
	//	//End
	//
	//	//Undo Class
	//	public Stack<UndoClass.UndoVariables> bUndoStack = new Stack<UndoClass.UndoVariables>();
	//End
	public void LoadVariables ()
	{
		CardGame.instance.bSetupDone = true;
		CardGame.instance.oDrawDeck.cards.Clear ();
		CardGame.instance.oDrawDeck = loadData.oDrawDeck;
		CardGame.instance.oDrawDeckHidden.cards.Clear ();
		CardGame.instance.oDrawDeckHidden = loadData.oDrawDeckHidden;
		CardGame.instance.oDrawDeckCards.cards.Clear ();
		CardGame.instance.oDrawDeckCards = loadData.oDrawDeckCards;
		CardGame.instance.oDiscardDeck.cards.Clear ();
		CardGame.instance.oDiscardDeck = loadData.oDiscardDeck;
		CardGame.instance.oGameDecks.Clear ();
		CardGame.instance.oGameDecks = loadData.oGameDecks;
		CardGame.instance.startTime = loadData.bStartTime;
		CardGame.instance.endTime = loadData.bEndTime;
		CardGame.instance.nScore = loadData.nScore;
		;
		UndoClass.instance.UndoStack = loadData.bUndoStack;
		ChangeCardDeck ();
		CardGame.instance.ChangeOrientation (false, true);


	}

	void ChangeCardDeck ()
	{
		int cardCount = 0;
		List<CardGame.Card> tempCards = new List<CardGame.Card> ();
		for (int k = 0; k < CardGame.instance.oDrawDeck.cards.Count; k++) {
			tempCards.Add (CardGame.instance.oDrawDeck.cards [k]);
		}
		cardCount = tempCards.Count;
		CardGame.instance.oDrawDeck.cards.Clear ();
		Debug.Log ("actual card count" + tempCards.Count);
		Debug.Log ("temp card count" + cardCount);
		for (int i = 0; i < cardCount; i++) {
			CardGame.instance.dragDropScriptAll [tempCards [i].gameobjectNumber].currentCard.Deck = CardGame.instance.oDrawDeck;
			CardGame.instance.dragDropScriptAll [tempCards [i].gameobjectNumber].currentCard.bUsed = tempCards [i].bUsed;
			CardGame.instance.dragDropScriptAll [tempCards [i].gameobjectNumber].currentCard.enabled = tempCards [i].enabled;

		}
		//
		tempCards.Clear ();
		for (int k = 0; k < CardGame.instance.oDrawDeckHidden.cards.Count; k++) {
			tempCards.Add (CardGame.instance.oDrawDeckHidden.cards [k]);
		}
		cardCount = tempCards.Count;
		CardGame.instance.oDrawDeckHidden.cards.Clear ();
		for (int i = 0; i < cardCount; i++) {
			CardGame.instance.dragDropScriptAll [tempCards [i].gameobjectNumber].currentCard.Deck = CardGame.instance.oDrawDeckHidden;
			CardGame.instance.dragDropScriptAll [tempCards [i].gameobjectNumber].currentCard.bUsed = tempCards [i].bUsed;
			CardGame.instance.dragDropScriptAll [tempCards [i].gameobjectNumber].currentCard.enabled = tempCards [i].enabled;
		}
		//
		tempCards.Clear ();
		for (int k = 0; k < CardGame.instance.oDrawDeckCards.cards.Count; k++) {
			tempCards.Add (CardGame.instance.oDrawDeckCards.cards [k]);
		}
		cardCount = tempCards.Count;
		CardGame.instance.oDrawDeckCards.cards.Clear ();
		for (int i = 0; i < cardCount; i++) {
			CardGame.instance.dragDropScriptAll [tempCards [i].gameobjectNumber].currentCard.Deck = CardGame.instance.oDrawDeckCards;
			CardGame.instance.dragDropScriptAll [tempCards [i].gameobjectNumber].currentCard.bUsed = tempCards [i].bUsed;
			CardGame.instance.dragDropScriptAll [tempCards [i].gameobjectNumber].currentCard.enabled = tempCards [i].enabled;
		}
		//
		tempCards.Clear ();
		for (int k = 0; k < CardGame.instance.oDiscardDeck.cards.Count; k++) {
			tempCards.Add (CardGame.instance.oDiscardDeck.cards [k]);
		}
		cardCount = tempCards.Count;
		CardGame.instance.oDiscardDeck.cards.Clear ();
		for (int i = 0; i < cardCount; i++) {
			CardGame.instance.dragDropScriptAll [tempCards [i].gameobjectNumber].currentCard.Deck = CardGame.instance.oDiscardDeck;
			CardGame.instance.dragDropScriptAll [tempCards [i].gameobjectNumber].currentCard.bUsed = tempCards [i].bUsed;
			CardGame.instance.dragDropScriptAll [tempCards [i].gameobjectNumber].currentCard.enabled = tempCards [i].enabled;
		}
		//
		for (int i = 0; i < CardGame.instance.oGameDecks.Count; i++) {
			tempCards.Clear ();
			for (int k = 0; k < CardGame.instance.oGameDecks [i].cards.Count; k++) {
				tempCards.Add (CardGame.instance.oGameDecks [i].cards [k]);
			}
			cardCount = tempCards.Count;
			CardGame.instance.oGameDecks [i].cards.Clear ();
//			Debug.Log ("Deck 	Number Card Count 1:+ " + i.ToString()+ " :" + CardGame.instance.oGameDecks[i].cards.Count);
			for (int j = 0; j < cardCount; j++) {
				CardGame.instance.dragDropScriptAll [tempCards [j].gameobjectNumber].currentCard.Deck = CardGame.instance.oGameDecks [i];
				CardGame.instance.dragDropScriptAll [tempCards [j].gameobjectNumber].currentCard.bUsed = tempCards [j].bUsed;
				CardGame.instance.dragDropScriptAll [tempCards [j].gameobjectNumber].currentCard.enabled = tempCards [j].enabled;
			}

//			Debug.Log ("Deck Number Card Count 2:+ " + i.ToString()+" :"  + CardGame.instance.oGameDecks[i].cards.Count);
		}
	}
	// Update is called once per frame
	void Update ()
	{
		if (Save) {
//			Debug.Log ("Saved Game");
			SaveGame ();
			Save = false;
		}
		if (Load) {
			LoadGame ();
			Load = false;
		}
		if (cOrientation) {
			ChangeCardDeck ();
			CardGame.instance.ChangeOrientation (false, true);
			cOrientation = false;
		}
	}

	void OnApplicationPause ()
	{
		SaveGame ();
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
		VariablePasser.Instance.SaveStats ();
	}
}
