using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CardGame : MonoBehaviour
{
		
	public static CardGame instance = null;
		
	public bool bSetupDone = false;
	//[HideInInspector]
	public GameObject[] cardGameObject = new GameObject[52];
	//		[HideInInspector]
	public Collider[]
		cardCollider = new Collider[52];
	//		[HideInInspector]
	public CardDragDrop[]
		dragDropScriptAll = new CardDragDrop[52];
	//		[HideInInspector]
	public Deck
		oDrawDeck;
	//		[HideInInspector]
	public Deck
		oDrawDeckHidden;
	//		[HideInInspector]
	public Deck
		oDrawDeckCards;
	//		[HideInInspector]
	
	public Deck
		oDiscardDeck;
	//		[HideInInspector]
	public List <Deck>
		oGameDecks = new List<Deck> ();

	public AudioClip cardsSound;
	public AudioClip clickSound;
	public AudioClip applauseSound;
	
	static System.Random random;
	static public bool bUpdateCastleDeck = false;
	public float startTime, endTime;
	public int nScore = 0;
	public int scoreMultiplier = 100;
	public GameMode gameMode;
	[NonSerialized]
	public int
		moves;
	public bool autoComplete = false;

	public enum GameMode
	{
		Easy = 0,
		Medium,
		Hard}

	;

	public int drawCardNumber = 3;

	public enum DeckScoreLevel
	{
		Score_Unknown = -1,
		Score_Tableau = 0,
		Score_Foundation = 1,
		Score_Waste = 2,
	};

	public enum DeckType
	{
		Type_Deck1 = 1,
		Type_Deck2 = 2,
		Type_Deck3 = 3,
		Type_Deck4 = 4,
		Type_Deck5 = 5,
		Type_Deck6 = 6,
		Type_Deck7 = 7,
		Type_DeckDiamond = 8,
		Type_DeckClub = 9,
		Type_DeckSpad = 10,
		Type_DeckHeart = 11,
		Type_DiscardDeck = 13,
		DeckType = 14,
		Type_DrawDeck = 15,
		Type_DrawDeck1 = 16,
		Type_DrawDeckCards = 17,
	};

	public enum CardSuit
	{
		special = 0,
		s = 1,
		h,
		d,
		c}

	;

	public enum CardRank
	{
		special = 0,
		a = 1,
		Deuce,
		Three,
		Four,
		Five,
		Six,
		Seven,
		Eight,
		Nine,
		Ten,
		j,
		q,
		k}

	;

	public enum CardColor
	{
		Black = 0,
		Red = 1}

	;
	//Sprite Variables
	[NonSerialized]
	private Sprite[]
		sprites;
	[NonSerialized]
	private string[]
		names;
	//End
	// Returns time since game started
	private string CurrentTime ()
	{
		TimeSpan t = TimeSpan.FromSeconds (Mathf.RoundToInt (Time.time - startTime));
		return String.Format ("Time: {0:D2}:{1:D2}", t.Minutes, t.Seconds);
	}
	
	// Returns game finish time
	private string FinalTime ()
	{
		TimeSpan t = TimeSpan.FromSeconds (Mathf.RoundToInt (endTime - startTime));
		return String.Format ("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
	}

	public void Initializer ()
	{
		if (!VariablePasser.Instance.isResumable) {
			gameMode = VariablePasser.Instance.gameMode;
			drawCardNumber = VariablePasser.Instance.drawCardNumber;
		} else {
			gameMode = SaveGameClass.instance.loadData.gameMode;
			drawCardNumber = SaveGameClass.instance.loadData.drawCardNumber;
		}
		startTime = Time.time;
		int seed = (int)DateTime.Now.Ticks;
		random = new System.Random (seed);
		oDrawDeck = new Deck (1, 0, this, DeckType.Type_DrawDeck);	
		oDrawDeckHidden = new Deck (0, 0, this, DeckType.Type_DrawDeck1);	
		oDrawDeckCards = new Deck (0, 0, this, DeckType.Type_DrawDeckCards);
		
		oDiscardDeck = new Deck (0, 0, this, DeckType.Type_DiscardDeck);
		
		oGameDecks.Add (new Deck (0, 0, this, DeckType.Type_Deck1));
		oGameDecks.Add (new Deck (0, 0, this, DeckType.Type_Deck2));
		oGameDecks.Add (new Deck (0, 0, this, DeckType.Type_Deck3));
		oGameDecks.Add (new Deck (0, 0, this, DeckType.Type_Deck4));
		oGameDecks.Add (new Deck (0, 0, this, DeckType.Type_Deck5));
		oGameDecks.Add (new Deck (0, 0, this, DeckType.Type_Deck6));
		oGameDecks.Add (new Deck (0, 0, this, DeckType.Type_Deck7));

		oGameDecks.Add (new Deck (0, 0, this, DeckType.Type_DeckDiamond));
		oGameDecks.Add (new Deck (0, 0, this, DeckType.Type_DeckClub));
		oGameDecks.Add (new Deck (0, 0, this, DeckType.Type_DeckHeart));
		oGameDecks.Add (new Deck (0, 0, this, DeckType.Type_DeckSpad));

		if (gameMode == GameMode.Medium) {
			oDrawDeck.Draw (oGameDecks [10], 1, false);
			oDrawDeck.Draw (oGameDecks [9], 1, false);
			oDrawDeck.Draw (oGameDecks [7], 1, false);
			oDrawDeck.Draw (oGameDecks [8], 1, false);
			oGameDecks [7].Cards [0].bUsed = true;
			oGameDecks [8].Cards [0].bUsed = true;
			oGameDecks [9].Cards [0].bUsed = true;
			oGameDecks [10].Cards [0].bUsed = true;

		}
		if (gameMode == GameMode.Easy) {
			oDrawDeck.Draw (oGameDecks [10], 1, false);
			oDrawDeck.Draw (oGameDecks [9], 1, false);
			oDrawDeck.Draw (oGameDecks [7], 1, false);
			oDrawDeck.Draw (oGameDecks [8], 1, false);
			oDrawDeck.Draw (oGameDecks [10], 1, false);
			oDrawDeck.Draw (oGameDecks [9], 1, false);
			oDrawDeck.Draw (oGameDecks [7], 1, false);
			oDrawDeck.Draw (oGameDecks [8], 1, false);
			oDrawDeck.Draw (oGameDecks [10], 1, false);
			oDrawDeck.Draw (oGameDecks [9], 1, false);
			oDrawDeck.Draw (oGameDecks [7], 1, false);
			oDrawDeck.Draw (oGameDecks [8], 1, false);
			foreach (Card c in oGameDecks[10].Cards)
				c.bUsed = true;
			foreach (Card c in oGameDecks[9].Cards)
				c.bUsed = true;
			foreach (Card c in oGameDecks[8].Cards)
				c.bUsed = true;
			foreach (Card c in oGameDecks[7].Cards)
				c.bUsed = true;
		}
		oDrawDeck.Shuffle (1);
		
		oGameDecks [0].nDeckScoreLevel = DeckScoreLevel.Score_Tableau;
		oGameDecks [1].nDeckScoreLevel = DeckScoreLevel.Score_Tableau;
		oGameDecks [2].nDeckScoreLevel = DeckScoreLevel.Score_Tableau;
		oGameDecks [3].nDeckScoreLevel = DeckScoreLevel.Score_Tableau;
		oGameDecks [4].nDeckScoreLevel = DeckScoreLevel.Score_Tableau;
		oGameDecks [5].nDeckScoreLevel = DeckScoreLevel.Score_Tableau;
		oGameDecks [6].nDeckScoreLevel = DeckScoreLevel.Score_Tableau;
		
		
		oGameDecks [7].nDeckScoreLevel = DeckScoreLevel.Score_Foundation;
		oGameDecks [8].nDeckScoreLevel = DeckScoreLevel.Score_Foundation;
		oGameDecks [9].nDeckScoreLevel = DeckScoreLevel.Score_Foundation;
		oGameDecks [10].nDeckScoreLevel = DeckScoreLevel.Score_Foundation;
		
		if (gameMode != GameMode.Easy) {
			oDrawDeck.Draw (oGameDecks [0], 1, false);
			oDrawDeck.Draw (oGameDecks [1], 2, false);
			oDrawDeck.Draw (oGameDecks [2], 3, false);
			oDrawDeck.Draw (oGameDecks [3], 4, false);
			oDrawDeck.Draw (oGameDecks [4], 5, false);
			oDrawDeck.Draw (oGameDecks [5], 6, false);
			oDrawDeck.Draw (oGameDecks [6], 7, false);
		} else {
			oDrawDeck.Draw (oGameDecks [0], 1, false);
			oDrawDeck.Draw (oGameDecks [1], 1, false);
			oDrawDeck.Draw (oGameDecks [2], 2, false);
			oDrawDeck.Draw (oGameDecks [3], 3, false);
			oDrawDeck.Draw (oGameDecks [4], 4, false);
			oDrawDeck.Draw (oGameDecks [5], 5, false);
			oDrawDeck.Draw (oGameDecks [6], 6, false);
		}
		//Club, Diamond, Heart, Spades
		if (gameMode == GameMode.Hard) {
			oDrawDeck.Draw (oGameDecks [7], 0, false);
			oDrawDeck.Draw (oGameDecks [8], 0, false);
			oDrawDeck.Draw (oGameDecks [9], 0, false);
			oDrawDeck.Draw (oGameDecks [10], 0, false);
		}
		
		oGameDecks [7].DeckSuit = CardSuit.d;
		oGameDecks [8].DeckSuit = CardSuit.c;
		oGameDecks [9].DeckSuit = CardSuit.h;
		oGameDecks [10].DeckSuit = CardSuit.s;
		
		oDrawDeck.Draw (oDrawDeckHidden, 0, false);
		oDrawDeck.Draw (oDrawDeckCards, drawCardNumber, false);
		oDrawDeckCards.TopCard.bUsed = true;
		
		oDrawDeckCards.nDeckScoreLevel = DeckScoreLevel.Score_Waste;
		
		bSetupDone = true;
		if (VariablePasser.Instance.isResumable)
			InitialDeckSetup (false);
		else
			InitialDeckSetup (true);
		if (VariablePasser.Instance.isResumable)
			SaveGameClass.instance.LoadVariables ();
	}

	public void ChangeOrientation (bool doTween, bool doRotationTween)
	{
		Vector3 cardScale = new Vector3 (LayoutClass.instance.cardScaleRatio.x,
			                    LayoutClass.instance.cardScaleRatio.y,
			                    1.0f);
		foreach (Deck oDeck in oGameDecks) {
			oDeck.UpdateCardDecks (doTween, doRotationTween);
			foreach (Card c in oDeck.Cards) {
				instance.cardGameObject [c.gameobjectNumber].transform.localScale = cardScale;
			}
		}
			
		oDrawDeck.UpdateCardDecks (doTween, doRotationTween);
		foreach (Card c in oDrawDeck.Cards) {
			instance.cardGameObject [c.gameobjectNumber].transform.localScale = cardScale;
		}
		oDrawDeckHidden.UpdateCardDecks (doTween, doRotationTween);
		foreach (Card c in oDrawDeckHidden.Cards) {
			instance.cardGameObject [c.gameobjectNumber].transform.localScale = cardScale;
		}
		oDrawDeckCards.UpdateCardDecks (doTween, doRotationTween);
		foreach (Card c in oDrawDeckCards.Cards) {
			instance.cardGameObject [c.gameobjectNumber].transform.localScale = cardScale;
		}
	}
	//Initial Deck Setup
	//for stopping movement in draw deck make false here
	public void InitialDeckSetup (bool doTween)
	{
		Vector3 cardScale = new Vector3 (LayoutClass.instance.cardScaleRatio.x,
			                    LayoutClass.instance.cardScaleRatio.y,
			                    1.0f);
		foreach (Deck oDeck in oGameDecks) {
			oDeck.vDrawDeck (false, true);
			foreach (Card c in oDeck.Cards) {
				instance.cardGameObject [c.gameobjectNumber].transform.localScale = cardScale;
			}
		}
		
		oDrawDeck.vDrawDeck (false, true);
		foreach (Card c in oDrawDeck.Cards) {
			instance.cardGameObject [c.gameobjectNumber].transform.localScale = cardScale;
		}
		oDrawDeckHidden.vDrawDeck (false, true);
		foreach (Card c in oDrawDeckHidden.Cards) {
			instance.cardGameObject [c.gameobjectNumber].transform.localScale = cardScale;
		}
		oDrawDeckCards.vDrawDeck (false, true);
		foreach (Card c in oDrawDeckCards.Cards) {
			instance.cardGameObject [c.gameobjectNumber].transform.localScale = cardScale;
		}
	}
	// Use this for initialization
	public void Start ()
	{
		instance = this;
		sprites = Resources.LoadAll<Sprite> ("Cards/Atlas"); 
		names = new string[sprites.Length];
		
		for (int i = 0; i < names.Length; i++) {
			names [i] = sprites [i].name;
		}
	}



	public void vProcDrop (String oName, GameObject gameObject, CardGame.Card oSrcCard, out CardGame.Deck oDeck, out Card oDestCard)
	{
		oDeck = null;
		oDestCard = null;
		int nResult = oName.IndexOf ("Deck", 0);
			
		//In Deck
		if (nResult >= 0) {
			oDeck = oGetDeck (oName, oSrcCard);
//				print("**** Found Deck " + oDeck.oDeckType.ToString());
		} else {
			CardDragDrop oDestDrag = (CardDragDrop)gameObject.GetComponent ("CardDragDrop") as CardDragDrop;
			oDestCard = oDestDrag.currentCard;
		}
	}

	public Deck oGetDeck (String oName, CardGame.Card oCard)
	{		
		if (oName == "Deck1") {
			return oGameDecks [0];
		} else if (oName == "Deck2") {
			return oGameDecks [1];
		} else if (oName == "Deck3") {
			return oGameDecks [2];
		} else if (oName == "Deck4") {
			return oGameDecks [3];
		} else if (oName == "Deck5") {
			return oGameDecks [4];
		} else if (oName == "Deck6") {
			return oGameDecks [5];
		} else if (oName == "Deck7") {
			return oGameDecks [6];
		} else if (oName == "DeckDiscard") {
			if (oCard.Suit == CardSuit.d) {
				return oGameDecks [7];
			} else if (oCard.Suit == CardSuit.c) {
				return oGameDecks [8];
			} else if (oCard.Suit == CardSuit.h) {
				return oGameDecks [9];
			} else if (oCard.Suit == CardSuit.s) {
				return oGameDecks [10];
			}
			
		}		
		
		return null;
	}

	public void vPlayClick ()
	{
		if (VariablePasser.Instance.playSound)
			audio.PlayOneShot (clickSound);
	}

	public void vTurnDeckClick (bool isPressed)
	{
		if (oDrawDeck.cards.Count <= 0) {

			if (VariablePasser.Instance.playSound)
			if (oDrawDeck.cards.Count != 0 || oDrawDeckCards.cards.Count != 0 || oDrawDeckHidden.cards.Count != 0)
				audio.PlayOneShot (clickSound);
				
//						oDrawDeckHidden.Shuffle(1);
//						oDrawDeckHidden.Draw(oDrawDeck,oDrawDeckHidden.cards.Count,true);
			
			if (oDrawDeckCards.cards.Count > 0) {
				oDrawDeckCards.Draw (oDrawDeckHidden, CardGame.instance.drawCardNumber, true);
				oDrawDeckHidden.TopCard.bUsed = false;
			}
			

			
			oDrawDeckHidden.Draw (oDrawDeck, oDrawDeckHidden.cards.Count, true);
//				oDrawDeck.Shuffle(1);
			foreach (Card otCard in oDrawDeck.cards) {
				otCard.bUsed = false;
			}
			oDrawDeck.Draw (oDrawDeckCards, CardGame.instance.drawCardNumber, true);
				
			if (oDrawDeckCards.Cards.Count > 0) {
				oDrawDeckCards.TopCard.bUsed = true;
			}
		}
	}




	public void vProcCard (bool isPressed, CardGame.Card oCard1)
	{
		Debug.Log ("Proc Card DeckType = " + oCard1.Deck.oDeckType.ToString ());    
		
		if (oCard1.Deck.oDeckType == DeckType.Type_DrawDeck) {
			Debug.Log ("Proc Card1 = " + oDrawDeckCards.cards.Count + " = " + oDrawDeck.cards.Count);    
			//Get rid of current draw card
			if (oDrawDeckCards.cards.Count > 0) {
				oDrawDeckCards.Draw (oDrawDeckHidden, CardGame.instance.drawCardNumber, true);
				oDrawDeckHidden.TopCard.bUsed = false;
				
				oDrawDeck.Draw (oDrawDeckCards, CardGame.instance.drawCardNumber, true);
				oDrawDeckCards.TopCard.bUsed = true;	
			} else if (oDrawDeckCards.cards.Count <= 0) {
				oDrawDeck.Draw (oDrawDeckCards, CardGame.instance.drawCardNumber, true);
				oDrawDeckCards.TopCard.bUsed = true;	
			}
		}
	}

	public static Transform CardSelected = null;
	public Transform ShowCardSelected;
	// Update is called once per frame
	void Update ()
	{
		if (bSetupDone == false) {
			return;
		}
		InitialDeckSetup (true);
		CardGame.bUpdateCastleDeck = false;
		CheckAutoComplete ();
		if (autoComplete) {
			RunAutoComplete ();
		}		
		ShowCardSelected = CardSelected;
//			if(Input.GetKeyDown(KeyCode.Escape))
//			{
//			//Game Save
////			SaveGameClass.instance.Save = true;
//			SaveGameClass.instance.SaveGame();
//			Application.LoadLevel(0);
//			VariablePasser.Instance.previousRotation = (VariablePasser.PreviousRotation)LayoutClass.instance.previousRotation;
//			}

			
		if (Input.touchCount != 0) {
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				if (releaseTime == 0f) {
					isPressable = true;
					return;
				} else {
					if (Mathf.Abs (Time.time - releaseTime) <= approxgaptime) {
						isPressable = false;												
					} else
						isPressable = true;
				}
			}
			if (Input.GetTouch (0).phase == TouchPhase.Ended || Input.GetTouch (0).phase == TouchPhase.Canceled) {
				releaseTime = Time.time;
			}
		}
		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor) {
			if (Input.GetMouseButtonDown (0)) {
				if (releaseTime == 0f) {
					isPressable = true;
					return;
				} else {
					if (Mathf.Abs (Time.time - releaseTime) <= approxgaptime) {
						isPressable = false;												
					} else
						isPressable = true;
				}
			}
			if (Input.GetMouseButtonUp (0)) {
				releaseTime = Time.time;
			}
		}

		
	}

	public float approxgaptime = 0.02f;
	public float releaseTime;
	public static bool isPressable = false;

		
		
		
	void RunAutoComplete ()
	{
	}

	void CheckAutoComplete ()
	{
		foreach (CardGame.Deck d in oGameDecks) {
			foreach (CardGame.Card c in d.Cards) {
				if (c.enabled == false) {
					return;
				}
			}
		}
		if (oDrawDeck.cards.Count != 0)
			return;
		if (oDrawDeckCards.cards.Count != 0)
			return;
		if (oDrawDeckHidden.cards.Count != 0)
			return;

		autoComplete = true;
	}

	public bool bCheckGameOver ()
	{
		int nTotal = 0;
		
		nTotal += oGameDecks [0].cards.Count;
		nTotal += oGameDecks [1].cards.Count;
		nTotal += oGameDecks [2].cards.Count;
		nTotal += oGameDecks [3].cards.Count;
		nTotal += oGameDecks [4].cards.Count;
		nTotal += oGameDecks [5].cards.Count;
		nTotal += oGameDecks [6].cards.Count;
		
		nTotal += oDrawDeck.cards.Count;
		nTotal += oDrawDeckCards.cards.Count;
		nTotal += oDrawDeckHidden.cards.Count;
		
		if (nTotal > 0) {
			return false;
		}
		
		endTime = Time.time;
//			if(VariablePasser.Instance.playEffects)
//			audio.PlayOneShot(applauseSound);
		return true;
	}
	

	
	/********************************************
	/ Card Class
	/********************************************/
	[System.Serializable]
	public class Deck
	{
		public List<Card> cards = new List<Card> ();
		//        private CardGame game;
		public DeckType oDeckType;
		public bool bUpdate = false;
		public CardSuit DeckSuit;
		public DeckScoreLevel nDeckScoreLevel = DeckScoreLevel.Score_Unknown;

		public List<Card> Cards {
			get {
				return cards;
			}
		}

		//        public CardGame Game
		//        {
		//            get
		//            {
		//                return game;
		//            }
		//        }

		public Card TopCard {
			get {
				if (Cards.Count > 0)
					return Cards [Cards.Count - 1];
				else
					return null;
			}
			set {
				if (Cards.Count > 0)
					Cards [Cards.Count - 1] = value;
			}
		}

		public Card BottomCard {
			get {
				if (Cards.Count > 0)
					return Cards [0];
				else
					return null;
			}
		}

		public bool HasCards {
			get {
				if (Cards.Count > 0)
					return true;
				else
					return false;
			}
		}

		public void vSetTransform (float fX, float fY, float fZ, bool doTween, bool doRotationTween)
		{
//			float fSpacer = 0.19f;
			float fSpacer = LayoutClass.instance.spacerInPlayDeck;
			float delay = 0;
			foreach (Card otCard in Cards) {

				fZ -= 0.5f;
				if (!doTween) {
					instance.cardGameObject [otCard.gameobjectNumber].transform.position = new Vector3 (fX, fY, fZ);
					if (otCard.bUsed && doRotationTween) {
						VariablePasser.Instance.underTween = true;
						iTween.RotateAdd (instance.cardGameObject [otCard.gameobjectNumber], iTween.Hash ("z", 360.0f, "time", 0.7f, "oncomplete", "ResetRotation", "oncompletetarget", instance.cardGameObject [otCard.gameobjectNumber]));
					}

				} else {
					delay += .01f;
					VariablePasser.Instance.underTween = true;
					iTween.MoveTo (instance.cardGameObject [otCard.gameobjectNumber], iTween.Hash ("position", new Vector3 (fX, fY, fZ), "time", 0.5f, "delay", delay, "oncomplete", "ResetPosition", "oncompletetarget", instance.cardGameObject [TopCard.gameobjectNumber]));
				}
				instance.cardCollider [otCard.oCollider].enabled = true;
				otCard.enabled = otCard.bUsed;
//				otCard.Visible = true;
				otCard.vUpdateCardTexture ();
				if (otCard.enabled)
					fY -= fSpacer;
				else
					fY -= fSpacer * 0.5f;
			}
	
			if (Cards.Count <= 0) {
				return;
			}
		
			TopCard.enabled = true;
			TopCard.bUsed = true;
		
			TopCard.vUpdateCardTexture ();
		}

		public void vSetTransformStack (float fX, float fY, float fZ, bool bflip, bool doTween, bool doRotationTween)
		{
			float delay = 0;
			foreach (Card otCard in Cards) {
				fZ -= 0.5f;
				if (!doTween) {
					instance.cardGameObject [otCard.gameobjectNumber].transform.position = new Vector3 (fX, fY, fZ); 
				} else {
					delay += .01f;
					VariablePasser.Instance.underTween = true;
					iTween.MoveTo (instance.cardGameObject [otCard.gameobjectNumber], iTween.Hash ("position", new Vector3 (fX, fY, fZ), "time", 0.5f, "delay", delay, "oncomplete", "ResetPosition", "oncompletetarget", instance.cardGameObject [TopCard.gameobjectNumber]));

				}

//				
//				iTween.MoveTo(otCard.gameobject,new Vector3(fX,fY,fZ),0.2f);
				instance.cardCollider [otCard.oCollider].enabled = true;
				otCard.enabled = bflip;
//				otCard.Visible = bflip;
				otCard.vUpdateCardTexture ();
			}
			if (TopCard != null && doTween && doRotationTween) {
				VariablePasser.Instance.underTween = true;
				iTween.RotateAdd (instance.cardGameObject [TopCard.gameobjectNumber], iTween.Hash ("z", 360.0f, "time", 0.7f, "oncomplete", "ResetRotation", "oncompletetarget", instance.cardGameObject [TopCard.gameobjectNumber]));
			}
		}


		public void vSetTransformStackDrawDeckCards (float fX, float fY, float fZ, bool bflip, bool doTween)
		{
			float delay = 0;
			int nCnt = 0;
//			fZ +=4;
//			int sortingOrder = 0;
			if (instance.drawCardNumber == 3) {
				if (LayoutClass.instance.previousRotation == LayoutClass.PreviousRotation.Portrait)
					fX -= (2 * LayoutClass.instance.spacerDrawDeckCards.x);
				else
					fY += (2 * LayoutClass.instance.spacerDrawDeckCards.y);
			}
			foreach (Card otCard in Cards) {
				fZ -= 1.0f;
				
				if (nCnt > 0) {
					if (LayoutClass.instance.previousRotation == LayoutClass.PreviousRotation.Portrait)
						fX += LayoutClass.instance.spacerDrawDeckCards.x;
					else
						fY -= LayoutClass.instance.spacerDrawDeckCards.y;
				}
				if (!doTween) {
					instance.cardGameObject [otCard.gameobjectNumber].transform.position = new Vector3 (fX, fY, fZ); 
				} else {
					delay += .01f;	
					VariablePasser.Instance.underTween = true;
					iTween.MoveTo (instance.cardGameObject [otCard.gameobjectNumber], iTween.Hash ("position", new Vector3 (fX, fY, fZ), "time", 0.5f, "delay", delay, "oncomplete", "ResetPosition", "oncompletetarget", instance.cardGameObject [TopCard.gameobjectNumber]));
				}

				instance.cardCollider [otCard.oCollider].enabled = true;
				otCard.enabled = bflip;
//				SpriteRenderer[] tempSprites = instance.cardGameObject[otCard.gameobjectNumber].transform.GetComponentsInChildren<SpriteRenderer>();
//				NGUIDebug.Log (tempSprites.Length.ToString());
//				foreach(SpriteRenderer s in tempSprites)
//				{
//					s.sortingOrder = sortingOrder;
//				}
//				sortingOrder+=1;
//				otCard.Visible = bflip;
				otCard.vUpdateCardTexture ();
				nCnt++;
			}
		}
		//Card Placement Fix Value
		public void vDrawDeck (bool doTween, bool doRotationTween)
		{
			if (cards.Count <= 0) {
				return;
			}
			
			if (bUpdate == true) {
				UpdateCardDecks (doTween, doRotationTween);
			}
	
			bUpdate = false;		
		}

		public void UpdateCardDecks (bool doTween, bool doRotationTween)
		{
			float fOffset = LayoutClass.instance.spacerPlayDeck.x;
			float fOffsetDiscard = 0;
			float fXStart = LayoutClass.instance.playDeckStartPos.x;
			if (LayoutClass.instance.previousRotation == LayoutClass.PreviousRotation.Portrait)
				fOffsetDiscard = LayoutClass.instance.spacerInDiscardDeck.x;
			else
				fOffsetDiscard = LayoutClass.instance.spacerInDiscardDeck.y;
//			float fOffset = 1.24f;
//			float fXStart = 4.15f;
			switch (oDeckType) {
			case DeckType.Type_Deck1:
				{
					float fZ = 17.0f;
					float fY = LayoutClass.instance.playDeckStartPos.y;
//				float fY = -0.1f;
					float fX = fXStart - (fOffset * 6);
					vSetTransform (fX, fY, fZ, doTween, doRotationTween);
				}
				break;
//				
			case DeckType.Type_Deck2:
				{
					float fZ = 17.0f;
					float fY = LayoutClass.instance.playDeckStartPos.y;
//				float fY = -0.1f;
					float fX = fXStart - (fOffset * 5);
					vSetTransform (fX, fY, fZ, doTween, doRotationTween);
				
				}
				break;
				
			case DeckType.Type_Deck3:
				{
//				float fZ = -1.3f;
//				float fY = -0.1f;
					float fZ = 17.0f;
					float fY = LayoutClass.instance.playDeckStartPos.y;
					float fX = fXStart - (fOffset * 4);
					vSetTransform (fX, fY, fZ, doTween, doRotationTween);
				}
				break;	
				
			case DeckType.Type_Deck4:
				{
//				float fZ = -1.3f;
//				float fY = -0.1f;
					float fZ = 17.0f;
					float fY = LayoutClass.instance.playDeckStartPos.y;
					float fX = fXStart - (fOffset * 3);
					vSetTransform (fX, fY, fZ, doTween, doRotationTween);
				}
				break;	
//				
			case DeckType.Type_Deck5:
				{
//				float fZ = -1.3f;
//				float fY = -0.1f;
					float fZ = 17.0f;
					float fY = LayoutClass.instance.playDeckStartPos.y;
					float fX = fXStart - (fOffset * 2);
					vSetTransform (fX, fY, fZ, doTween, doRotationTween);
				}
				break;	
//				
			case DeckType.Type_Deck6:
				{
//				float fZ = -1.3f;
//				float fY = -0.1f;
					float fZ = 17.0f;
					float fY = LayoutClass.instance.playDeckStartPos.y;
					float fX = fXStart - (fOffset * 1);
					vSetTransform (fX, fY, fZ, doTween, doRotationTween);
				}
				break;						
				
			case DeckType.Type_Deck7:
				{
//				float fZ = -1.3f;
//				float fY = -0.1f;
					float fZ = 17.0f;
					float fY = LayoutClass.instance.playDeckStartPos.y;
					float fX = fXStart - (fOffset * 0);
					vSetTransform (fX, fY, fZ, doTween, doRotationTween);
				}
				break;	
//			
//Start from here
			case DeckType.Type_DeckDiamond:
				{
//				float fX = 0.472f;
//				float fZ = -2.75f;
//				float fY = -0.226f;
//				float fOffsetX = LayoutClass.instance.spacerInDiscardDeck.x;
					float fZ = 17.0f;
					float fX, fY = 0;
					if (LayoutClass.instance.previousRotation == LayoutClass.PreviousRotation.Portrait) {
						fX = LayoutClass.instance.discardDeckStartPosRatio.x - (fOffsetDiscard * 3.0f);
						fY = LayoutClass.instance.discardDeckStartPosRatio.y;
					} else {
						fX = LayoutClass.instance.discardDeckStartPosRatio.x;
						fY = LayoutClass.instance.discardDeckStartPosRatio.y + (fOffsetDiscard * 3.0f);
					}
					vSetTransformStack (fX, fY, fZ, true, doTween, doRotationTween);
				}
				break;
				
			case DeckType.Type_DeckClub:
				{
//				float fX = -0.81f;
//				float fZ = -2.75f;
//				float fY = -0.226f;
					float fOffsetX = LayoutClass.instance.spacerInDiscardDeck.x;
					float fZ = 17.0f;
					float fX, fY = 0;
					if (LayoutClass.instance.previousRotation == LayoutClass.PreviousRotation.Portrait) {
						fX = LayoutClass.instance.discardDeckStartPosRatio.x - (fOffsetDiscard * 2.0f);
						fY = LayoutClass.instance.discardDeckStartPosRatio.y;
					} else {
						fX = LayoutClass.instance.discardDeckStartPosRatio.x;
						fY = LayoutClass.instance.discardDeckStartPosRatio.y + (fOffsetDiscard * 2.0f);
					}
					vSetTransformStack (fX, fY, fZ, true, doTween, doRotationTween);
				}
				break;
				
			case DeckType.Type_DeckHeart:
				{
//				float fX = -2.11f;
//				float fZ = -2.75f;
//				float fY = -0.226f;
					float fOffsetX = LayoutClass.instance.spacerInDiscardDeck.x;
					float fZ = 17.0f;
					float fX, fY = 0;
					if (LayoutClass.instance.previousRotation == LayoutClass.PreviousRotation.Portrait) {
						fX = LayoutClass.instance.discardDeckStartPosRatio.x - (fOffsetDiscard * 1.0f);
						fY = LayoutClass.instance.discardDeckStartPosRatio.y;
					} else {
						fX = LayoutClass.instance.discardDeckStartPosRatio.x;
						fY = LayoutClass.instance.discardDeckStartPosRatio.y + (fOffsetDiscard * 1.0f);
					}
					vSetTransformStack (fX, fY, fZ, true, doTween, doRotationTween);
				}
				break;
				
			case DeckType.Type_DeckSpad:
				{
//				float fX = -3.41f;
//				float fZ = -2.75f;
//				float fY = -0.226f;

					float fZ = 17.0f;
					float fX, fY = 0;
					if (LayoutClass.instance.previousRotation == LayoutClass.PreviousRotation.Portrait) {
						fX = LayoutClass.instance.discardDeckStartPosRatio.x - (fOffsetDiscard * 0);
						fY = LayoutClass.instance.discardDeckStartPosRatio.y;
					} else {
						fX = LayoutClass.instance.discardDeckStartPosRatio.x;
						fY = LayoutClass.instance.discardDeckStartPosRatio.y + (fOffsetDiscard * 0);
					}
					vSetTransformStack (fX, fY, fZ, true, doTween, doRotationTween);
				}
				break;
				
			case DeckType.Type_DrawDeck:
				{
//				float fZ = -2.71f;
//				float fY = -0.1f;
//				float fX = fXStart;
					float fZ = 17.0f;
					float fX = LayoutClass.instance.drawDeckStartPosRatio.x;
					float fY = LayoutClass.instance.drawDeckStartPosRatio.y;
					vSetTransformStack (fX, fY, fZ, false, doTween, doRotationTween);
				}
				break;	
				
			case DeckType.Type_DrawDeck1:
				{
//				float fZ = -2.71f;
//				float fY = -1.1f;
//				float fX = fXStart;
					float fZ = 100.0f;
					float fX = LayoutClass.instance.drawDeckStartPosRatio.x;
					float fY = LayoutClass.instance.drawDeckStartPosRatio.y;
					vSetTransformStack (fX, fY, fZ, false, doTween, doRotationTween);
				}
				break;	
				
			case DeckType.Type_DrawDeckCards:
				{
//				float fZ = -2.71f;
//				float fY = -0.1f;
//				float fX = 2.9f;
					float fZ = 17.0f;
					float fX = LayoutClass.instance.drawDeckCardsStartPosRatio.x;
					float fY = LayoutClass.instance.drawDeckCardsStartPosRatio.y;
					vSetTransformStackDrawDeckCards (fX, fY, fZ, true, doTween);
				}
				break;	
				
			}
			;
		}

		public Deck (int numberOfDecks, int nWildCards, CardGame game, DeckType oType)
		{
			DeckSuit = CardGame.CardSuit.special;
			oDeckType = oType;
//            this.game = game;
			int cardGameobject = 0;
			for (int deck = 0; deck < numberOfDecks; deck++) {

				for (int number = 13; number >= 1; number--) {
					for (int suit = 4; suit >= 1; suit--) {
						Cards.Add (new Card (number, (CardSuit)suit, this, false, game, cardGameobject));
						cardGameobject++;
					}
				}

			
			}
		}

		public Deck (CardGame game, DeckType oType)
		{
			if (CardGame.instance.gameMode == GameMode.Medium) {
				if (oType == DeckType.Type_DeckDiamond) {
					Cards.Add (new Card (1, CardSuit.d, this, true, game, 48));
				}
				if (oType == DeckType.Type_DeckClub) {
					Cards.Add (new Card (1, CardSuit.c, this, true, game, 49));
				}
				if (oType == DeckType.Type_DeckHeart) {
					Cards.Add (new Card (1, CardSuit.h, this, true, game, 50));
				}
				if (oType == DeckType.Type_DeckSpad) {
					Cards.Add (new Card (1, CardSuit.s, this, true, game, 51));
				}
			}
			if (CardGame.instance.gameMode == GameMode.Easy) {
				if (oType == DeckType.Type_DeckDiamond) {
					for (int i = 1; i <= 3; i++)
						Cards.Add (new Card (i, CardSuit.d, this, true, game, 40 + i));
				}
				if (oType == DeckType.Type_DeckClub) {
					for (int i = 1; i <= 3; i++)
						Cards.Add (new Card (i, CardSuit.c, this, true, game, 43 + i));
				}
				if (oType == DeckType.Type_DeckHeart) {
					for (int i = 1; i <= 3; i++)
						Cards.Add (new Card (i, CardSuit.h, this, true, game, 46 + i));
				}
				if (oType == DeckType.Type_DeckSpad) {
					for (int i = 1; i <= 3; i++)
						Cards.Add (new Card (i, CardSuit.s, this, true, game, 49 + i));
				}
			}
		}

		public Deck (Deck copyDeck, List<Card> tCard)
		{
			DeckSuit = copyDeck.DeckSuit;
			oDeckType = copyDeck.oDeckType;
//			cards.Clear();

			foreach (CardGame.Card c in tCard) {
				cards.Add (c);
			}
			for (int i = 0; i < tCard.Count; i++) {
				cards [i].enabled = tCard [i].enabled;
//				Debug.Log ("Teset Enabled " + cards[i].enabled); 
			}
			bUpdate = copyDeck.bUpdate;
			nDeckScoreLevel = copyDeck.nDeckScoreLevel;

		}

		public bool Has (int number, CardSuit suit)
		{
			return Has ((CardRank)number, suit);
		}

		public bool Has (CardRank rank, CardSuit suit)
		{
			if (GetCard (rank, suit) != null)
				return true;
			else
				return false;
		}

		public Card GetCard (int number, CardSuit suit)
		{
			return GetCard ((CardRank)number, suit);
		}

		public Card GetCard (CardRank rank, CardSuit suit)
		{
			foreach (Card card in Cards) {
				if ((card.Rank == rank) && (card.Suit == suit))
					return card;
			}

			return null;
		}

		public void Shuffle (int times)
		{
			for (int time = 0; time < times; time++) {
				for (int i = 0; i < Cards.Count; i++) {
					Cards [i].Shuffle ();
				}
			}

			bUpdate = true;
		}

		public void Draw (Deck toDeck, Card oSrcCard)
		{
			foreach (Card oCard in cards) {
				if (oSrcCard == oCard) {
					oCard.Deck = toDeck;
					break;
				}
			}

			bUpdate = true;
			toDeck.bUpdate = true;
		}

		public void Draw (Deck toDeck, int count, bool forHint)
		{
			//Make sure enough cards
			List<Card> tempArray = new List<Card> ();
			//Source Card List
			List<CardGame.Card> tSourceCards = new List<CardGame.Card> ();
			//error
			if (TopCard == null || TopCard.Deck == null || TopCard.Deck.Cards == null) {
				return;
			}
			bool[] tUsed = new bool[TopCard.Deck.Cards.Count];
			bool[] tEnabled = new bool[TopCard.Deck.Cards.Count];
			int index1 = 0;
			foreach (CardGame.Card c in TopCard.Deck.Cards) {
				tSourceCards.Add (c);
				tUsed [index1] = c.bUsed;
				tEnabled [index1] = c.enabled;
				index1++;
			}
			//End

			//Destination Card List
			List<CardGame.Card> tDestinationCards = new List<CardGame.Card> ();
			foreach (CardGame.Card c in toDeck.Cards) {
				tDestinationCards.Add (c);
			}
			//End
			Deck sourceDeck = new Deck (TopCard.Deck, tSourceCards);
			Deck destinationDeck = new Deck (toDeck, tDestinationCards);
			if (forHint) {
				UndoClass.instance.AddMove (sourceDeck, destinationDeck, tempArray, TopCard, 0, tEnabled, tUsed);
			}
			if (cards.Count < count) {
				count = cards.Count;
			}
			
			for (int i = 0; i < count; i++) {
//				sourceDeck = TopCard.Deck;
				tempArray.Add (TopCard);
				TopCard.Deck = toDeck;
			}

			bUpdate = true;
			toDeck.bUpdate = true;
		}

		//        public void FlipAllCards()
		//        {
		//            for (int i = 0; i < Cards.Count; i++)
		//            {
		//                Cards[i].enabled = !Cards[i].enabled;
		//				Cards[i].Visible = !Cards[i].Visible;
		//            }
		//			bUpdate = true;
		//        }
		
	}
	
	/********************************************
	/ Card Class
	/********************************************/
	[System.Serializable]
	public class Card
	{
//      public static bool IsAceBiggest = true;
		public CardRank rank;
		public int gameobjectNumber;
		public bool enabled = false;
		//		public bool visible = false;
		public int nUID = -1;
		public float[] oOrigPosit = new float[3];
		public Deck oMoveSrcDeck = null;
		public Deck oMoveDestDeck = null;
		public int nSrcDeckIdx = 0;
		public int nDestDeckIdx = 0;
		public bool bPutInSrcIdx = false;
		public int nLastKeyIdx = -1;
		public bool bNeedReturn = false;
		public int nCardPosit = -1;
		//	    public CardGame oParent = null;
		public int oCollider;
		public int nRowIndex = -1;
		public bool bUsed = false;
		//		public int dragDropScript;
		public CardRank Rank {
			get {
				return rank;
			}
		}

		private CardSuit suit;

		public CardSuit Suit {
			get {
				return suit;
			}
			set {
				suit = value;
			}
		}

		public CardColor Color {
			get {
				if ((Suit == CardSuit.s) || (Suit == CardSuit.c))
					return CardColor.Black;
				else
					return CardColor.Red;
			}
		}

		public int Number {
			get {
				return (int)rank;
			}
		}

		public string NumberString {
			get {
				switch (rank) {
				case CardRank.a:
					return "a";
				case CardRank.j:
					return "j";
				case CardRank.q:
					return "q";
				case CardRank.k:
					return "k";
				case CardRank.special:
					return "special";
				default:
					return Number.ToString ();
				}
			}
		}

		private Deck deck;

		public Deck Deck {
			get {
				return deck;
			}
			set {
				if (deck != value) {
					deck.Cards.Remove (this);
					deck = value;
					deck.Cards.Add (this);
				}
			}
		}
	
		//        public bool Visible
		//        {
		//            get
		//            {
		//                return visible;
		//            }
		//            set
		//            {
		//                if (visible != value)
		//                {
		//                    visible = value;
		//                }
		//            }
		//        }

		public bool Enabled {
			get {
				return enabled;
			}
			set {
				enabled = value;
			}
		}

		public void vUpdateCardTexture ()
		{		
			if (enabled == true) {
				instance.cardGameObject [this.gameobjectNumber].GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "CardFront")];
				for (int i = 0; i < 3; i++)
					instance.cardGameObject [this.gameobjectNumber].transform.GetChild (i).gameObject.SetActive (true);
				instance.cardGameObject [this.gameobjectNumber].transform.GetChild (1).GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, ((int)this.rank).ToString ())];
				if (this.suit == CardSuit.c) {
					//Club
					instance.cardGameObject [this.gameobjectNumber].transform.GetChild (1).GetComponent<SpriteRenderer> ().color = UnityEngine.Color.black;
					instance.cardGameObject [this.gameobjectNumber].transform.GetChild (2).GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "ClubSmall")];
					if ((int)this.Rank <= 10)
						instance.cardGameObject [this.gameobjectNumber].transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "Club")];
					else if ((int)this.Rank == 11)
						instance.cardGameObject [this.gameobjectNumber].transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "Jack")];
					else if ((int)this.Rank == 12)
						instance.cardGameObject [this.gameobjectNumber].transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "Queen")];
					else if ((int)this.Rank == 13)
						instance.cardGameObject [this.gameobjectNumber].transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "King")];

				} else if (this.suit == CardSuit.d) {
					//Diamond
					instance.cardGameObject [this.gameobjectNumber].transform.GetChild (1).GetComponent<SpriteRenderer> ().color = UnityEngine.Color.red;

					instance.cardGameObject [this.gameobjectNumber].transform.GetChild (2).GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "DiamondSmall")];
					if ((int)this.Rank <= 10)
						instance.cardGameObject [this.gameobjectNumber].transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "Diamond")];
					else if ((int)this.Rank == 11)
						instance.cardGameObject [this.gameobjectNumber].transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "Jack")];
					else if ((int)this.Rank == 12)
						instance.cardGameObject [this.gameobjectNumber].transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "Queen")];
					else if ((int)this.Rank == 13)
						instance.cardGameObject [this.gameobjectNumber].transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "King")];

				} else if (this.suit == CardSuit.h) {
					//Heart
					instance.cardGameObject [this.gameobjectNumber].transform.GetChild (1).GetComponent<SpriteRenderer> ().color = UnityEngine.Color.red;

					instance.cardGameObject [this.gameobjectNumber].transform.GetChild (2).GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "HeartSmall")];
					if ((int)this.Rank <= 10)
						instance.cardGameObject [this.gameobjectNumber].transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "Heart")];
					else if ((int)this.Rank == 11)
						instance.cardGameObject [this.gameobjectNumber].transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "Jack")];
					else if ((int)this.Rank == 12)
						instance.cardGameObject [this.gameobjectNumber].transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "Queen")];
					else if ((int)this.Rank == 13)
						instance.cardGameObject [this.gameobjectNumber].transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "King")];

				} else if (this.suit == CardSuit.s) {
					//sSpade
					instance.cardGameObject [this.gameobjectNumber].transform.GetChild (1).GetComponent<SpriteRenderer> ().color = UnityEngine.Color.black;

					instance.cardGameObject [this.gameobjectNumber].transform.GetChild (2).GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "SpadeSmall")];
					if ((int)this.Rank <= 10)
						instance.cardGameObject [this.gameobjectNumber].transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "Spade")];
					else if ((int)this.Rank == 11)
						instance.cardGameObject [this.gameobjectNumber].transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "Jack")];
					else if ((int)this.Rank == 12)
						instance.cardGameObject [this.gameobjectNumber].transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "Queen")];
					else if ((int)this.Rank == 13)
						instance.cardGameObject [this.gameobjectNumber].transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "King")];

				}
			} else {
				if (VariablePasser.Instance.looks <= 9)
					instance.cardGameObject [this.gameobjectNumber].GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "CardBackBrown")];
				else if (VariablePasser.Instance.looks <= 18)
					instance.cardGameObject [this.gameobjectNumber].GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "CardBackGreen")];
				else
					instance.cardGameObject [this.gameobjectNumber].GetComponent<SpriteRenderer> ().sprite = CardGame.instance.sprites [Array.IndexOf (CardGame.instance.names, "CardBackRed")];

				for (int i = 0; i < 3; i++)
					instance.cardGameObject [this.gameobjectNumber].transform.GetChild (i).gameObject.SetActive (false);
				
			}

		
		}

		public Card (int tnumber, CardSuit tsuit, Deck tdeck, bool tEnabled, CardGame otp, int oGameobjectNumber)
		{			
//			oParent = otp;
			this.enabled = tEnabled;
			this.rank = (CardRank)tnumber;
			this.suit = tsuit;
			this.deck = tdeck;
			this.gameobjectNumber = oGameobjectNumber;
			this.oCollider = oGameobjectNumber;
			if (tnumber <= 10)
				instance.cardGameObject [this.gameobjectNumber] = Instantiate (Resources.Load ("Models/CardPrefab")) as GameObject;
			else
				instance.cardGameObject [this.gameobjectNumber] = Instantiate (Resources.Load ("Models/CardPrefabFace")) as GameObject;

			CardGame.instance.dragDropScriptAll [gameobjectNumber] = (CardDragDrop)instance.cardGameObject [this.gameobjectNumber].AddComponent ("CardDragDrop");
			CardGame.instance.dragDropScriptAll [gameobjectNumber].currentCard = this;
			instance.cardCollider [oCollider] = instance.cardGameObject [this.gameobjectNumber].collider;
		
			if (tnumber > 1 && tnumber < 11) {
				instance.cardGameObject [this.gameobjectNumber].name = String.Format ("{0}{1}", tnumber.ToString (), suit.ToString ());
			} else {
				instance.cardGameObject [this.gameobjectNumber].name = String.Format ("{0}{1}", rank.ToString (), suit.ToString ());
			}
			//Hard Coded Card Scale
			Vector3 cardScale = new Vector3 (LayoutClass.instance.cardScaleRatio.x,
				                    LayoutClass.instance.cardScaleRatio.y,
				                    1.3f);
			instance.cardGameObject [this.gameobjectNumber].transform.localScale = cardScale;
			instance.cardGameObject [this.gameobjectNumber].transform.position = new Vector3 (11114.15f, 21310, -232312.71f);
			vUpdateCardTexture ();
		}

		//        public int CompareTo(Card other)
		//        {
		//            int value1 = this.Number;
		//            int value2 = other.Number;
		//
		//            if (Card.IsAceBiggest)
		//            {
		//                if (value1 == 1)
		//                    value1 = 14;
		//
		//                if (value2 == 1)
		//                    value2 = 14;
		//            }
		//
		//            if (value1 > value2)
		//                return 1;
		//            else if (value1 < value2)
		//                return -1;
		//            else
		//                return 0;
		//        }

		public void MoveToFirst ()
		{
			MoveToIndex (0);
		}

		public void MoveToLast ()
		{
			MoveToIndex (Deck.Cards.Count);
		}

		public void Shuffle ()
		{
			MoveToIndex (random.Next (0, Deck.Cards.Count));
		}

		public void MoveToIndex (int index)
		{
			Deck.Cards.Remove (this);
			Deck.Cards.Insert (index, this);
		}

		public override string ToString ()
		{
			return this.NumberString + " of " + this.Suit.ToString ();
		}
	}
}