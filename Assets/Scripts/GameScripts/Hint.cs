using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Hint : MonoBehaviour
{
	public CardGame game;
	private int hintCount;
	private int currentHintNumber;
	public float OffsetY;
	private Vector3 initialPos;
	private Vector3 finalPos;
	private bool hintReactivate = true;
	List<HintCardHolder> hintNumber = new List<HintCardHolder> ();
	// Use this for initialization
	public int GetHintCount {
		get {
			return hintCount;
		}
	}
	void OnStart ()
	{
		OffsetY = LayoutClass.instance.spacerInPlayDeck; 
	}




	public void CheckMoves ()
	{
		Debug.Log ("CheckMoves --- hintReactivate : " + hintReactivate);

		if (hintReactivate) {
			hintReactivate = false;

			hintCount = 0;
			for (int i=0; i<hintNumber.Count; i++) {
				hintNumber [i].ResetList ();
			}
			hintNumber.Clear ();
			finalPos = Vector3.zero;
			initialPos = Vector3.zero;
			int[] cardCount = new int[7];
			for (int i=0; i<7; i++) {
				cardCount [i] = game.oGameDecks [i].cards.Count;
			}
			for (int j=0; j<7; j++) {
				for (int k=0; k<cardCount[j]; k++) {
					if (game.oGameDecks [j].cards [k].bUsed) {
						if (k != cardCount [j] - 1) {
							SingleCardCheck (game.oGameDecks [j].cards [k], j, k, false);
//							print ("Card Send For Comparing" + game.oGameDecks[j].cards[k].Number);
//							print ("Card Count" +k);
							break;

						}
					}
				}
				if (cardCount [j] != 0) {
					SingleCardCheck (game.oGameDecks [j].cards [cardCount [j] - 1], j, 0, true);
				}
			}

			DrawCardCheck ();

			Debug.Log ("list count of holder" + hintNumber.Count);
			if (hintNumber.Count == 0) {
				Debug.Log ("hint destination card empty");
				hintReactivate = true;

			}
			//Show Hint
			if (hintNumber.Count != 0) {

				if (hintNumber.Count == 1)
					currentHintNumber = 0;

				if (currentHintNumber == hintNumber.Count - 1)
					currentHintNumber = 0;

				ShowHint (currentHintNumber);

				if (currentHintNumber == hintNumber.Count - 1)
					currentHintNumber = 0;
				else
					currentHintNumber++;

			}
		}
	}

	void SingleCardCheck (CardGame.Card card, int deckNumber, int cardNumber, bool isTopCard)
	{
		for (int i=0; i<7; i++) {
			if (game.oGameDecks [i].cards.Count != 0 && i != deckNumber) {
//				Debug.Log ("entered one");
				if (game.oGameDecks [i].TopCard.Number == card.Number + 1 && game.oGameDecks [i].TopCard.Color != card.Color) {
					hintCount++;
//						hintNumber[hintCount] = new HintCardHolder(
					if (isTopCard) {
						CardGame.Card[] tempArray = {card};
						hintNumber.Add (new HintCardHolder (tempArray, game.oGameDecks [i].TopCard));
					} else {
						CardGame.Card[] tempArray2 = new CardGame.Card[game.oGameDecks [deckNumber].cards.Count - cardNumber];
						int index = 0;
						for (int j=cardNumber; j<game.oGameDecks[deckNumber].cards.Count; j++) {
							tempArray2 [index] = game.oGameDecks [deckNumber].cards [j];
							index++;
						}
						hintNumber.Add (new HintCardHolder (tempArray2, game.oGameDecks [i].TopCard));
					}
//						print ("Matching top Card" + game.oGameDecks[i].TopCard.Suit + "Matching Card two" + card.Suit);
//						print("Mtching Card one" + game.oGameDecks[i].TopCard.Number + "Matching card two" + card.Number);
				}
			}
			
		}
	}

	void DrawCardCheck ()
	{
		for (int k =0; k<7; k++) {
			if (game.oGameDecks [k].TopCard != null && game.oDrawDeckCards.TopCard != null) {
				if (game.oGameDecks [k].TopCard.Number == game.oDrawDeckCards.TopCard.Number + 1 && game.oGameDecks [k].TopCard.Color != game.oDrawDeckCards.TopCard.Color) {
					hintCount++;
					CardGame.Card[] tempArray = {game.oDrawDeckCards.TopCard};
					hintNumber.Add (new HintCardHolder (tempArray, game.oGameDecks [k].TopCard));
//					print("Mtching Card one" + game.oGameDecks[k].TopCard.Number + "Matching card two" + game.oDrawDeckCards.TopCard.Number);
					
				}
			}
		}
	}

	/// <summary>
	/// Shows the hint.
	/// </summary>
	/// <param name="number">Number.</param>
	public void ShowHint (int number)
	{
		Debug.Log ("Show Hint");
		finalPos = CardGame.instance.cardGameObject [hintNumber [number].HintDestinationCard [0].gameobjectNumber].transform.position;
		finalPos.z = 0;
		finalPos.y -= LayoutClass.instance.spacerInPlayDeck;
		initialPos = CardGame.instance.cardGameObject [hintNumber [number].CardHolder [0].gameobjectNumber].transform.position;
		foreach (CardGame.Card card in hintNumber[number].CardHolder) {
			CardGame.instance.cardGameObject [card.gameobjectNumber].GetComponent<CardDragDrop> ().underHint = true;
			iTween.MoveTo (CardGame.instance.cardGameObject [card.gameobjectNumber], iTween.Hash ("position", finalPos, "time", 0.7f, "oncomplete", "GetBackFromFinalPos", "oncompletetarget", gameObject, "oncompleteparams", card));
			finalPos.y -= LayoutClass.instance.spacerInPlayDeck;
			finalPos.z -= 0.5f;
		}
	}

	public void GetBackFromFinalPos (CardGame.Card card)
	{
		iTween.MoveTo (CardGame.instance.cardGameObject [card.gameobjectNumber], iTween.Hash ("position", initialPos, "time", 0.2f, "oncomplete", "HintReactivate", "oncompletetarget", gameObject, "oncompleteparams", card));
		Debug.Log ("Hint Complete");
		initialPos.z -= 0.5f;
		initialPos.y -= LayoutClass.instance.spacerInPlayDeck;
	}

	public void HintReactivate (CardGame.Card card)
	{
		CardGame.instance.cardGameObject [card.gameobjectNumber].GetComponent<CardDragDrop> ().underHint = false;
		Debug.Log ("reactivating hint : true");
		hintReactivate = true;

	}
	public class HintCardHolder
	{
		List<CardGame.Card> cardHolder = new List<CardGame.Card> ();
		List<CardGame.Card> hintdestinationCard = new List<CardGame.Card> ();
		public List<CardGame.Card> HintDestinationCard {
			get {
				return hintdestinationCard;
			}
		}
		public List<CardGame.Card> CardHolder {
			get {
				return cardHolder;
			}
		}
		public HintCardHolder (CardGame.Card[] cards, CardGame.Card destinationCard)
		{
//			CardHolder.Add(cards);
			cardHolder = new List<CardGame.Card> (cards);
			HintDestinationCard.Add (destinationCard);
		}
		public void ResetList ()
		{
			cardHolder.Clear ();
			hintdestinationCard.Clear ();
		}
	}
}
