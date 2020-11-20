using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class UndoClass : MonoBehaviour
{
	public static UndoClass instance = null;
	private Stack<UndoVariables> undoStack = new Stack<UndoVariables> ();
	public Stack<UndoVariables> UndoStack {
		get {
			return undoStack;
		}
		set {
			undoStack = value;
		}
	}

//	public UndoClass(CardGame.DeckType oSourceDeck,CardGame.DeckType oDestinationDeck,List<CardGame.Card> oCardList,float oScoreChange){
//		SourceDeck = oSourceDeck;
//		DestinationDeck = oDestinationDeck;
//		ScoreChange = oScoreChange;
//		CardList = oCardList;
//		undoStack.Push(this);
//	}
	public void Start ()
	{
		instance = this;
	}
	public void AddMove (CardGame.Deck oSourceDeck, CardGame.Deck oDestinationDeck, List<CardGame.Card> oCardList, CardGame.Card oPreviousCard, float oScoreChange, bool[] tEnabled, bool[] tUsed)
	{
//		undoStack.Push(new UndoVariables(oSourceDeck,oDestinationDeck,oCardList,oPreviousCard,oScoreChange));
		undoStack.Push (new UndoVariables (oSourceDeck, oDestinationDeck, oScoreChange, tEnabled, tUsed));
	}
	public void UndoMove ()
	{
//		foreach(UndoVariables u in undoStack){
//			//Debug.Log ("Destination DeckType = "+ u.DestinationDeck.oDeckType+" Source Deck Type = " + u.SourceDeck.oDeckType);
//		}

		Debug.Log ("UndoMove called...");

		if (undoStack.Count == 0)
			return;
		UndoVariables tempUndoVariables = undoStack.Pop ();
		//Debug
//		//Debug.Log (tempUndoVariables.DestinationDeck.oDeckType);
//		//Debug.Log (tempUndoVariables.SourceDeck.oDeckType);
		//End
		Reposition (tempUndoVariables);
		if (undoStack.Count == 0)
			return;
		UndoVariables temp2UndoVariables = undoStack.Pop ();

		if (temp2UndoVariables.DestinationDeck.oDeckType == CardGame.DeckType.Type_DrawDeck1 || temp2UndoVariables.DestinationDeck.oDeckType == CardGame.DeckType.Type_DrawDeck) {
			Reposition (temp2UndoVariables);
			if (undoStack.Count == 0)
				return;
			UndoVariables temp3UndoVariables = undoStack.Pop ();
			if (temp3UndoVariables.DestinationDeck.oDeckType == CardGame.DeckType.Type_DrawDeck1 || temp3UndoVariables.DestinationDeck.oDeckType == CardGame.DeckType.Type_DrawDeck) {
				Reposition (temp3UndoVariables);
				
			} else
				undoStack.Push (temp3UndoVariables);
		} else
			undoStack.Push (temp2UndoVariables);


	}

	void Reposition (UndoVariables uTemp)
	{
		oSetDeck (uTemp.SourceDeck.oDeckType, uTemp.SourceDeck, uTemp.EnableArray, uTemp.BUsedArray);
		oSetDeck (uTemp.DestinationDeck.oDeckType, uTemp.DestinationDeck, null, null);
//		oSetDeck(uTemp.SourceDeck.oDeckType,uTemp.SourceDeck);


//		//Debug.Log ("Reposition ended");
	}

	public void oSetDeck (CardGame.DeckType tDeckType, CardGame.Deck tDeck, bool[] tEnabled, bool[] tUsed)
	{			
		if (tDeckType == CardGame.DeckType.Type_Deck1) {
//			//Debug.Log (CardGame.instance.oGameDecks[0].cards.Count);
//			ReplaceDeck(CardGame.instance.oGameDecks[0],tDeck);
			ReplaceDeck (tDeck, 0, 50, tEnabled, tUsed);
//			//Debug.Log (CardGame.instance.oGameDecks[0].cards.Count);
		} else if (tDeckType == CardGame.DeckType.Type_Deck2) {
//			//Debug.Log (CardGame.instance.oGameDecks[1].cards.Count);
//			ReplaceDeck(CardGame.instance.oGameDecks[1],tDeck);
			ReplaceDeck (tDeck, 1, 50, tEnabled, tUsed);
			//Debug.Log (CardGame.instance.oGameDecks[1].cards.Count);
		} else if (tDeckType == CardGame.DeckType.Type_Deck3) {
			//Debug.Log (CardGame.instance.oGameDecks[2].cards.Count);
//			ReplaceDeck(CardGame.instance.oGameDecks[2],tDeck);
			ReplaceDeck (tDeck, 2, 50, tEnabled, tUsed);
			//Debug.Log (CardGame.instance.oGameDecks[2].cards.Count);
		} else if (tDeckType == CardGame.DeckType.Type_Deck4) {
			//Debug.Log (CardGame.instance.oGameDecks[3].cards.Count);
//			ReplaceDeck(CardGame.instance.oGameDecks[3],tDeck);
			ReplaceDeck (tDeck, 3, 50, tEnabled, tUsed);
			//Debug.Log (CardGame.instance.oGameDecks[3].cards.Count);
		} else if (tDeckType == CardGame.DeckType.Type_Deck5) {
			//Debug.Log (CardGame.instance.oGameDecks[4].cards.Count);
//			ReplaceDeck(CardGame.instance.oGameDecks[4],tDeck);
			ReplaceDeck (tDeck, 4, 50, tEnabled, tUsed);
			//Debug.Log (CardGame.instance.oGameDecks[4].cards.Count);
		} else if (tDeckType == CardGame.DeckType.Type_Deck6) {
			//Debug.Log (CardGame.instance.oGameDecks[5].cards.Count);
//			ReplaceDeck(CardGame.instance.oGameDecks[5],tDeck);
			ReplaceDeck (tDeck, 5, 50, tEnabled, tUsed);
			//Debug.Log (CardGame.instance.oGameDecks[5].cards.Count);
		} else if (tDeckType == CardGame.DeckType.Type_Deck7) {
			//Debug.Log (CardGame.instance.oGameDecks[6].cards.Count);
//			ReplaceDeck(CardGame.instance.oGameDecks[6],tDeck);
			ReplaceDeck (tDeck, 6, 50, tEnabled, tUsed);
			//Debug.Log (CardGame.instance.oGameDecks[6].cards.Count);
		} else if (tDeckType == CardGame.DeckType.Type_DeckDiamond) {
			//Debug.Log (CardGame.instance.oGameDecks[7].cards.Count);
//			ReplaceDeck(CardGame.instance.oGameDecks[7],tDeck);
			ReplaceDeck (tDeck, 7, 50, tEnabled, tUsed);
			//Debug.Log (CardGame.instance.oGameDecks[7].cards.Count);
		} else if (tDeckType == CardGame.DeckType.Type_DeckClub) {
			//Debug.Log (CardGame.instance.oGameDecks[8].cards.Count);
//			ReplaceDeck(CardGame.instance.oGameDecks[8],tDeck);
			ReplaceDeck (tDeck, 8, 50, tEnabled, tUsed);
			//Debug.Log (CardGame.instance.oGameDecks[8].cards.Count);
		} else if (tDeckType == CardGame.DeckType.Type_DeckSpad) {
			//Debug.Log (CardGame.instance.oGameDecks[10].cards.Count);
//			ReplaceDeck(CardGame.instance.oGameDecks[10],tDeck);
			ReplaceDeck (tDeck, 10, 50, tEnabled, tUsed);
			//Debug.Log (CardGame.instance.oGameDecks[10].cards.Count);
		} else if (tDeckType == CardGame.DeckType.Type_DeckHeart) {
			//Debug.Log (CardGame.instance.oGameDecks[9].cards.Count);
//			ReplaceDeck(CardGame.instance.oGameDecks[9],tDeck);
			ReplaceDeck (tDeck, 9, 50, tEnabled, tUsed);
			//Debug.Log (CardGame.instance.oGameDecks[9].cards.Count);
		} else if (tDeckType == CardGame.DeckType.Type_DrawDeck) {
//			ReplaceDeck(CardGame.instance.oDrawDeck,tDeck);
			ReplaceDeck (tDeck, 50, 0, tEnabled, tUsed);
		} else if (tDeckType == CardGame.DeckType.Type_DrawDeck1) {
//			ReplaceDeck(CardGame.instance.oDrawDeckHidden,tDeck);
			ReplaceDeck (tDeck, 50, 1, tEnabled, tUsed);
		} else if (tDeckType == CardGame.DeckType.Type_DrawDeckCards) {
//			ReplaceDeck(CardGame.instance.oDrawDeckCards,tDeck);
			ReplaceDeck (tDeck, 50, 2, tEnabled, tUsed);
		}
	}


	void ReplaceDeck (CardGame.Deck tDeck, int playDeckNumber, int drawDeckNumber, bool[] tEnabled, bool[] tUsed)
	{
		int cardCount = 0;
		List<CardGame.Card> tCards = new List<CardGame.Card> ();
		if (playDeckNumber != 50) {

			CardGame.instance.oGameDecks [playDeckNumber] = tDeck;
			foreach (CardGame.Card c in tDeck.cards) {
				//Debug.Log ("tCard" + c.enabled);
			}
			for (int k=0; k<CardGame.instance.oGameDecks[playDeckNumber].cards.Count; k++) {
				tCards.Add (CardGame.instance.oGameDecks [playDeckNumber].cards [k]);
				//Debug.Log ("tCards[k].bUsed" + tCards[k].bUsed);
			}
			//
			cardCount = tCards.Count;
			CardGame.instance.oGameDecks [playDeckNumber].cards.Clear ();
			for (int i=0; i<cardCount; i++) {
				CardGame.instance.dragDropScriptAll [tCards [i].gameobjectNumber].currentCard.Deck = CardGame.instance.oGameDecks [playDeckNumber];
				if (tEnabled == null)
					CardGame.instance.dragDropScriptAll [tCards [i].gameobjectNumber].currentCard.bUsed = tDeck.cards [i].bUsed;
				else
					CardGame.instance.dragDropScriptAll [tCards [i].gameobjectNumber].currentCard.bUsed = tUsed [i];
				if (tUsed == null)
					CardGame.instance.dragDropScriptAll [tCards [i].gameobjectNumber].currentCard.enabled = tDeck.cards [i].enabled;
				else
					CardGame.instance.dragDropScriptAll [tCards [i].gameobjectNumber].currentCard.enabled = tEnabled [i];
				
			}
			//
			tCards.Clear ();
		}
		if (drawDeckNumber == 0) {
			//Draw Deck
			CardGame.instance.oDrawDeck = tDeck;
			
			for (int k=0; k<CardGame.instance.oDrawDeck.cards.Count; k++) {
				tCards.Add (CardGame.instance.oDrawDeck.cards [k]);
			}
			//
			cardCount = tCards.Count;
			CardGame.instance.oDrawDeck.cards.Clear ();
			for (int i=0; i<cardCount; i++) {
				CardGame.instance.dragDropScriptAll [tCards [i].gameobjectNumber].currentCard.Deck = CardGame.instance.oDrawDeck;
				CardGame.instance.dragDropScriptAll [tCards [i].gameobjectNumber].currentCard.bUsed = tCards [i].bUsed;
				CardGame.instance.dragDropScriptAll [tCards [i].gameobjectNumber].currentCard.enabled = tCards [i].enabled;
				
			}
			//
			tCards.Clear ();
		}
		if (drawDeckNumber == 1) {
			//drawDeck1
			CardGame.instance.oDrawDeckHidden = tDeck;
			
			for (int k=0; k<CardGame.instance.oDrawDeckHidden.cards.Count; k++) {
				tCards.Add (CardGame.instance.oDrawDeckHidden.cards [k]);
			}
			//
			cardCount = tCards.Count;
			CardGame.instance.oDrawDeckHidden.cards.Clear ();
			for (int i=0; i<cardCount; i++) {
				CardGame.instance.dragDropScriptAll [tCards [i].gameobjectNumber].currentCard.Deck = CardGame.instance.oDrawDeckHidden;
				CardGame.instance.dragDropScriptAll [tCards [i].gameobjectNumber].currentCard.bUsed = tCards [i].bUsed;
				CardGame.instance.dragDropScriptAll [tCards [i].gameobjectNumber].currentCard.enabled = tCards [i].enabled;
				
			}
			//
			tCards.Clear ();
		}
		if (drawDeckNumber == 2) {
			//drawDeckCards
			CardGame.instance.oDrawDeckCards = tDeck;
			
			for (int k=0; k<CardGame.instance.oDrawDeckCards.cards.Count; k++) {
				tCards.Add (CardGame.instance.oDrawDeckCards.cards [k]);
			}
			//
			cardCount = tCards.Count;
			CardGame.instance.oDrawDeckCards.cards.Clear ();
			for (int i=0; i<cardCount; i++) {
				CardGame.instance.dragDropScriptAll [tCards [i].gameobjectNumber].currentCard.Deck = CardGame.instance.oDrawDeckCards;
				CardGame.instance.dragDropScriptAll [tCards [i].gameobjectNumber].currentCard.bUsed = tCards [i].bUsed;
				CardGame.instance.dragDropScriptAll [tCards [i].gameobjectNumber].currentCard.enabled = tCards [i].enabled;
				
			}
			//
			tCards.Clear ();
		}
		CardGame.instance.ChangeOrientation (false, false);
	}

	//Undo Variables Class
	[System.Serializable]
	public class UndoVariables
	{
		private CardGame.Deck sourceDeck;
		public CardGame.Deck SourceDeck {
			get {
				return sourceDeck;
			}
			set {
				sourceDeck = value;
			}
		}
		private CardGame.Deck destinationDeck;
		public CardGame.Deck DestinationDeck {
			get {
				return destinationDeck;
			}
			set {
				destinationDeck = value;
			}
		}
		private float scoreChange;
		public float ScoreChange {
			get {
				return scoreChange;
			}
			set {
				scoreChange = value;
			}
		}
		private bool[] enableArray;
		public bool[] EnableArray {
			get {
				return enableArray;
			}
			set {
				enableArray = value;
			}
		}
		private bool[] bUsedArray;
		public bool[] BUsedArray {
			get {
				return bUsedArray;
			}
			set {
				bUsedArray = value;
			}
		}
//		private List<CardGame.Card> cardList = new List<CardGame.Card>();
//		public List<CardGame.Card> CardList
//		{
//			get
//			{
//				return cardList;
//			}
//			set
//			{
//				cardList = value;
//			}
//			
//		}
//		private CardGame.Card previousCard;
//		public CardGame.Card PreviousCard{
//			get{
//				return previousCard;
//			}
//			set
//			{	
//				previousCard = value;
//			}
//		}
		public UndoVariables (CardGame.Deck oSourceDeck, CardGame.Deck oDestinationDeck, float oScoreChange, bool[] tEnabled, bool[] tUsed)//,List<CardGame.Card> oCardList,CardGame.Card oPreviousCard,float oScoreChange)
		{
			SourceDeck = oSourceDeck;
			DestinationDeck = oDestinationDeck;
			ScoreChange = oScoreChange;
			bUsedArray = new bool[tUsed.Length];
			bUsedArray = tUsed;
			enableArray = new bool[tEnabled.Length];
			enableArray = tEnabled;
//				CardList = oCardList;
		}
	}
}
