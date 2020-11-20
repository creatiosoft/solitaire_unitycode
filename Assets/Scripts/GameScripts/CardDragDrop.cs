using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
[System.Serializable]
public class CardDragDrop : MonoBehaviour
{	
	private Vector3 screenPoint;
	private Ray vRay;
	private bool bShowRay = false;
	public CardGame.Card currentCard = null;
	public ArrayList CardDragList;
	public CardGame.DeckType currentDeck;
	bool bDrawDeckProc = false;
	//Hint
	public bool underHint = false;
	//Automatic Card Placer Variables
	private float placerTime = 0.2f;
	private float placerTimer;
	public bool automaticPlace;
	private bool initializeTimer = true;
	private bool dragged = false;
	private bool isTouchActive = false;
	//End
	void Start ()
	{
		// Initializing All Cards list
		CardDragList = new ArrayList ();
	}
		
	void Update ()
	{
		currentDeck = currentCard.Deck.oDeckType;
		if (placerTimer > 0) {
			automaticPlace = true;
			placerTimer -= Time.deltaTime;
		} else {	
			automaticPlace = false;

		}
		//Touch Code
//				if (Application.platform != RuntimePlatform.WindowsEditor) {
//						if (Input.touchCount != 0) {
//								if (Input.GetTouch (0).phase == TouchPhase.Moved)
//										dragged = true;
//								if (Input.GetTouch (0).phase == TouchPhase.Ended || Input.GetTouch (0).phase == TouchPhase.Canceled) {
//										dragged = false;
//								}
//						}
//				} else
//						dragged = true;


	}

	bool AutoPlaceCard ()
	{

		if (!automaticPlace)
			return false;
		if (CardDragList.Count > 1 || CardDragList.Count == 0)
			return false;
		if (currentCard.Deck.oDeckType == CardGame.DeckType.Type_DeckClub || 
			currentCard.Deck.oDeckType == CardGame.DeckType.Type_DeckDiamond || 
			currentCard.Deck.oDeckType == CardGame.DeckType.Type_DeckHeart || 
			currentCard.Deck.oDeckType == CardGame.DeckType.Type_DeckSpad)
			return false;

		//Discard Deck Check
		int checknumber = 0;
		for (int i=7; i<11; i++) {
			checknumber = i;
//			Debug.Log ("Cheek numbeer" + checknumber);
			if (CardGame.instance.oGameDecks [i].cards.Count == 0) {
				//Discard Deck check 
				//Check for Ace
				if (((CardGame.Card)(CardDragList [0])).rank != CardGame.CardRank.a) {
					//					return false;
					continue;
				} else {
					NGUIDebug.Log ("AUTOMOVE " + i);
					//Move Card
					if (CardGame.instance.oGameDecks [i].oDeckType == CardGame.DeckType.Type_DeckSpad) {
						if (((CardGame.Card)(CardDragList [0])).Suit == CardGame.CardSuit.s) {
							AutoMove (CardGame.instance.oGameDecks [i]);														
							break;
						} else
							continue;
					} else if (CardGame.instance.oGameDecks [i].oDeckType == CardGame.DeckType.Type_DeckClub) {
						if (((CardGame.Card)(CardDragList [0])).Suit == CardGame.CardSuit.c) {
							AutoMove (CardGame.instance.oGameDecks [i]);
							break;
						} else
							continue;
					} else if (CardGame.instance.oGameDecks [i].oDeckType == CardGame.DeckType.Type_DeckDiamond) {
						if (((CardGame.Card)(CardDragList [0])).Suit == CardGame.CardSuit.d) {
							AutoMove (CardGame.instance.oGameDecks [i]);
							break;
						} else
							continue;
					} else if (CardGame.instance.oGameDecks [i].oDeckType == CardGame.DeckType.Type_DeckHeart) {
						if (((CardGame.Card)(CardDragList [0])).Suit == CardGame.CardSuit.h) {
							AutoMove (CardGame.instance.oGameDecks [i]);
							break;
						} else
							continue;
					}

				}
			}
			//Check for Top Card for each Deck
			bool isMovable = IsCardValidAuto (((CardGame.Card)(CardDragList [0])), CardGame.instance.oGameDecks [i].TopCard);
			if (isMovable) {
				//Move Card
				NGUIDebug.Log ("ISMOVABLE " + isMovable);
				AutoMove (CardGame.instance.oGameDecks [i]);
				break;
			} else
				continue;


		}
		if (checknumber == 10)
			return false;
		return true;
	}

	bool IsCardValidAuto (CardGame.Card oSrcCard, CardGame.Card oCheckCard)
	{
		//Suit Check
		if (oSrcCard.Suit != oCheckCard.Suit) {
			return false;
		}
		//Rank Check

		int nVal = ((int)oCheckCard.rank - (int)oSrcCard.rank);		
		if (nVal == -1) {
			return true;
		}
		return false;
	}

	void AutoMove (CardGame.Deck oDeck)
	{
		CardGame.Card oLastCard = (CardGame.Card)CardDragList [CardDragList.Count - 1];
		//oDeck to
		//oLastCardDeck from
		vDoScore (oLastCard.Deck, oDeck);
		NGUIDebug.Log ("CARD MOVED ==>   " + oLastCard.ToString ());
		int nCnt = 0;
		List<CardGame.Card> tempList = new List<CardGame.Card> ();
		//Copy List
		List<CardGame.Card> tSourceCards = new List<CardGame.Card> ();
		bool[] tUsed = new bool[((CardGame.Card)CardDragList [0]).Deck.Cards.Count];
		bool[] tEnabled = new bool[((CardGame.Card)CardDragList [0]).Deck.Cards.Count];
		int index1 = 0;
		foreach (CardGame.Card c in ((CardGame.Card)CardDragList[0]).Deck.Cards) {
			NGUIDebug.Log ("Movable Card C ==>   " + c.ToString ());
			tSourceCards.Add (c);
			tUsed [index1] = c.bUsed;
			tEnabled [index1] = c.enabled;
//			Debug.Log ("((CardGame.Card)CardDragList[0]).Deck" + c.Deck.oDeckType);
//			Debug.Log ("((CardGame.Card)CardDragList[0]).Deck" + c.Number);
//			Debug.Log ("((CardGame.Card)CardDragList[0]).Deck" + c.bUsed + c.enabled);
			index1++;
			
		}
		List<CardGame.Card> tDestinationCards = new List<CardGame.Card> ();
		foreach (CardGame.Card c in oDeck.Cards) {
			tDestinationCards.Add (c);
			NGUIDebug.Log ("Destination Card  C ==>   " + c.ToString ());
//			Debug.Log ("(oDeck.Cards" + c.Deck.oDeckType);
//			Debug.Log ("oDeck.Cards" + c.Number);
//			Debug.Log ("oDeck.Cards" + c.bUsed + c.enabled);
		}

		CardGame.Deck sourceDeck = new CardGame.Deck (((CardGame.Card)CardDragList [0]).Deck, tSourceCards);
		CardGame.Deck destinationDeck = new CardGame.Deck (oDeck, tDestinationCards);
		UndoClass.instance.AddMove (sourceDeck, destinationDeck, tempList, oLastCard.Deck.TopCard, 0, tEnabled, tUsed);
		foreach (CardGame.Card otCard in CardDragList) {
			NGUIDebug.Log ("Movable Card otCard ==>   " + otCard.ToString ());
			otCard.bUsed = true;
			CardGame.instance.cardGameObject [otCard.gameobjectNumber].transform.parent = null;
			oLastCard.Deck.Draw (oDeck, otCard);
			nCnt++;
		}
		CardDragList.Clear ();
		oDeck.vDrawDeck (true, true);
		oLastCard.Deck.vDrawDeck (true, true);
		CardGame.instance.moves += 1;
	}

	void OnMouseUp ()
	{		
				
		if (VariablePasser.Instance.underTween || CardDragList.Count == 0) {
			return;
		}
				
		CardGame.instance.vPlayClick ();
		initializeTimer = true;

		if (bDrawDeckProc == true) {
			bDrawDeckProc = false;
			return;
		}
		if (CardGame.CardSelected != null && CardGame.CardSelected.GetHashCode () == transform.GetHashCode ()) {
			if (AutoPlaceCard ()) {
				return;
			}
		} else {
			return;
		}
		if (currentDeck != CardGame.DeckType.Type_DrawDeck) {
			if (CardGame.CardSelected != null && CardGame.CardSelected.GetHashCode () == transform.GetHashCode ())
				CardGame.CardSelected = null;
			else {
				
				CardGame.CardSelected = null;
				return;
			}
		} else
			CardGame.CardSelected = null;
		if (isTouchActive) {

			foreach (CardGame.Card otCard in CardDragList) {
				CardGame.instance.cardGameObject [otCard.gameobjectNumber].transform.position = new Vector3 (otCard.oOrigPosit [0], otCard.oOrigPosit [1], otCard.oOrigPosit [2]);

			}

			currentCard.Deck.vDrawDeck (false, true);
			bShowRay = false;
		
			RaycastHit vHit = new RaycastHit ();

			if (Physics.Raycast (vRay, out vHit, 100)) {

				CardGame.Deck oDeck = null;
				CardGame.Card oDestCard = null;

				CardGame.instance.vProcDrop (vHit.collider.gameObject.name, vHit.collider.gameObject, currentCard, out oDeck, out oDestCard);
			
				if (oDestCard != null) {
					oDeck = oDestCard.Deck;

				}

				if (oDeck.oDeckType == CardGame.DeckType.Type_DeckClub || 
					oDeck.oDeckType == CardGame.DeckType.Type_DeckDiamond || 
					oDeck.oDeckType == CardGame.DeckType.Type_DeckHeart || 
					oDeck.oDeckType == CardGame.DeckType.Type_DeckSpad) {
					if (currentCard.Deck.oDeckType == CardGame.DeckType.Type_DeckClub || 
						currentCard.Deck.oDeckType == CardGame.DeckType.Type_DeckDiamond || 
						currentCard.Deck.oDeckType == CardGame.DeckType.Type_DeckHeart || 
						currentCard.Deck.oDeckType == CardGame.DeckType.Type_DeckSpad)
						return;
				}

			
				if (oDeck.oDeckType == CardGame.DeckType.Type_DrawDeck || 
					oDeck.oDeckType == CardGame.DeckType.Type_DrawDeck1 || 
					oDeck.oDeckType == CardGame.DeckType.Type_DrawDeckCards) {
					CardDragList.Clear ();
					return;
				}

				if (CardDragList.Count == 0) {
					Debug.Log ("CardDragList Count 'ZERO' (inside): " + CardDragList.Count);
					return;
				}
			
				//Go thru Cards and drop
				if (oDeck.oDeckType == CardGame.DeckType.Type_DrawDeckCards ||
					oDeck.oDeckType == CardGame.DeckType.Type_Deck1 || 
					oDeck.oDeckType == CardGame.DeckType.Type_Deck2 || 
					oDeck.oDeckType == CardGame.DeckType.Type_Deck3 || 
					oDeck.oDeckType == CardGame.DeckType.Type_Deck4 || 
					oDeck.oDeckType == CardGame.DeckType.Type_Deck5 || 
					oDeck.oDeckType == CardGame.DeckType.Type_Deck6 || 
					oDeck.oDeckType == CardGame.DeckType.Type_Deck7) {

					CardGame.Card oTempCard = (CardGame.Card)CardDragList [0];

					//Check for King into empty deck
					if (oDeck.cards.Count == 0) {
						if (oTempCard.Rank != CardGame.CardRank.k) {
//												print ("curent card is not king");
							foreach (CardGame.Card otCard in CardDragList) {
								CardGame.instance.cardGameObject [otCard.gameobjectNumber].transform.position = new Vector3 (otCard.oOrigPosit [0], otCard.oOrigPosit [1], otCard.oOrigPosit [2]);	
								NGUIDebug.Log ("SETTING OTCARD POSITION  =>  " + otCard.ToString ());
							}	
					
							oTempCard.Deck.vDrawDeck (false, true);
							CardDragList.Clear ();	
							return;
						}
					}

					//								print ("found Current card to be king");
					//BUGGY LINE CONDITION HERE FROM PREVIOUS DEVELOPER 
					if (oDeck.cards.Count > 0) {
						bool bVal = false;
						bVal = bISCardValidSuite (oTempCard, oDeck.TopCard);
						if (bVal == false) {
							foreach (CardGame.Card otCard in CardDragList) {
								if (oTempCard.Suit != otCard.Suit) {
//																		Debug.Log ("runned");
//																		CardGame.instance.cardGameObject [otCard.gameobjectNumber].transform.position = new Vector3 (otCard.oOrigPosit [0], otCard.oOrigPosit [1], otCard.oOrigPosit [2]);							
//																		NGUIDebug.Log ("SETTING SUIT OTCARD POSITION => " + otCard.ToString ());
								}
							}	
						
							oTempCard.Deck.vDrawDeck (false, true);
							CardDragList.Clear ();
							return;
						}				
					}								
				}
			
				//Check drop onto Suit Card Decks
				if (oDeck.oDeckType == CardGame.DeckType.Type_DeckClub || 
					oDeck.oDeckType == CardGame.DeckType.Type_DeckDiamond || 
					oDeck.oDeckType == CardGame.DeckType.Type_DeckHeart || 
					oDeck.oDeckType == CardGame.DeckType.Type_DeckSpad) {

					CardGame.Card oTempCard = (CardGame.Card)CardDragList [0];

					if (CardDragList.Count != 1) {
						foreach (CardGame.Card otCard in CardDragList) {
							if (oTempCard.Suit != otCard.Suit) {
								CardGame.instance.cardGameObject [otCard.gameobjectNumber].transform.position = new Vector3 (otCard.oOrigPosit [0], otCard.oOrigPosit [1], otCard.oOrigPosit [2]);							
								NGUIDebug.Log ("SETTING DECK , HEART OTCARD POSITION  => " + otCard.ToString ());
							}
						}	
						oTempCard.Deck.vDrawDeck (false, true);
						CardDragList.Clear ();
						return;
					}
//										print("^^^^^Suit1 = " + oTempCard.Suit.ToString() + "Suit2 = " + currentCard.Suit.ToString());
					if (oTempCard.Suit != oDeck.DeckSuit) {
						CardGame.instance.cardGameObject [oTempCard.gameobjectNumber].transform.position = new Vector3 (oTempCard.oOrigPosit [0], oTempCard.oOrigPosit [1], oTempCard.oOrigPosit [2]);	
						oTempCard.Deck.vDrawDeck (false, true);
						NGUIDebug.Log ("SETTING oTempCard , HEART OTCARD POSITION  =>  " + oTempCard.ToString ());
						CardDragList.Clear ();	
						return;
					}			
				
					//Check for Ace Only
					if (CardDragList.Count == 1) {
//										print ("**** cardrank = " + oTempCard.rank.ToString() + " Count = " + oDeck.cards.Count.ToString());
					
						//Need to check for next card in list		
						bool bVal = false;
						//Not Ace and Not Zero cards
						if (oTempCard.Rank == CardGame.CardRank.a && oDeck.cards.Count == 0) {
							bVal = true;
						} else {
							bVal = bISCardValid (oTempCard, oDeck.TopCard);
						}
					
						if (bVal == false) {
							foreach (CardGame.Card otCard in CardDragList) {
								if (oTempCard.Suit != otCard.Suit) {
									CardGame.instance.cardGameObject [otCard.gameobjectNumber].transform.position = new Vector3 (otCard.oOrigPosit [0], otCard.oOrigPosit [1], otCard.oOrigPosit [2]);							
									NGUIDebug.Log ("SETTING ACE  OTCARD POSITION  => " + oTempCard.ToString ());
								}
							}	
					
							oTempCard.Deck.vDrawDeck (false, true);
							CardDragList.Clear ();
							return;
						}
					}
				}

				CardGame.Card oLastCard = (CardGame.Card)CardDragList [CardDragList.Count - 1];
			
				vDoScore (oLastCard.Deck, oDeck);
		
				int nCnt = 0;
				List<CardGame.Card> tempList = new List<CardGame.Card> ();
				//Copy List
				List<CardGame.Card> tSourceCards = new List<CardGame.Card> ();
				bool[] tUsed = new bool[((CardGame.Card)CardDragList [0]).Deck.Cards.Count];
				bool[] tEnabled = new bool[((CardGame.Card)CardDragList [0]).Deck.Cards.Count];
				int index1 = 0;
				foreach (CardGame.Card c in ((CardGame.Card)CardDragList[0]).Deck.Cards) {
					tSourceCards.Add (c);
					tUsed [index1] = c.bUsed;
					tEnabled [index1] = c.enabled;
					index1++;

				}
				List<CardGame.Card> tDestinationCards = new List<CardGame.Card> ();
				foreach (CardGame.Card c in oDeck.Cards) {
					tDestinationCards.Add (c);
				}

				CardGame.Deck sourceDeck = new CardGame.Deck (((CardGame.Card)CardDragList [0]).Deck, tSourceCards);
				CardGame.Deck destinationDeck = new CardGame.Deck (oDeck, tDestinationCards);
				UndoClass.instance.AddMove (sourceDeck, destinationDeck, tempList, oLastCard.Deck.TopCard, 0, tEnabled, tUsed);
				foreach (CardGame.Card otCard in CardDragList) {
					otCard.bUsed = true;
					CardGame.instance.cardGameObject [otCard.gameobjectNumber].transform.parent = null;
					oLastCard.Deck.Draw (oDeck, otCard);
					nCnt++;
				}
				CardDragList.Clear ();
				oDeck.vDrawDeck (false, true);
				oLastCard.Deck.vDrawDeck (false, true);
				CardGame.instance.moves += 1;

			}	
			Debug.Log ("Press UP");
			isTouchActive = false;
		}
	}
		
	/// <summary>
	/// Raises the mouse down event.
	/// </summary>
	void OnMouseDown ()
	{
		if (!CardGame.isPressable)
			return;
		if (VariablePasser.Instance.underTween) {
			return;
		}
		if (currentDeck != CardGame.DeckType.Type_DrawDeck) {
			if (CardGame.CardSelected == null)
				CardGame.CardSelected = transform;
			else {
						
				CardGame.CardSelected = null;						
				return;
						
			}
		} else
			CardGame.CardSelected = null;

		//print ("Mouse Down");
		//Click on draw deck
		CardDragList.Clear ();
		if (underHint) {
			bDrawDeckProc = true;
			return;
		}
		if (initializeTimer) {
			initializeTimer = false;
			placerTimer = placerTime;
		}
	
//				Debug.Log ("current card uSed" + currentCard.bUsed);
//				Debug.Log ("MOuse Down current card NUmber" + currentCard.Number);
//				Debug.Log ("Mouse Down current Card enabled = " + currentCard.Enabled);

		if (currentCard.Deck.oDeckType == CardGame.DeckType.Type_DrawDeck) {
			bDrawDeckProc = true;
			CardGame.instance.moves += 1;
			CardGame.instance.vProcCard (true, currentCard);
			return;
		}
		
		if (currentCard.Deck.oDeckType == CardGame.DeckType.Type_DrawDeck || 
			currentCard.Deck.oDeckType == CardGame.DeckType.Type_DrawDeck1) {
			bDrawDeckProc = true;
			return;
		}
		if (currentCard.Deck.oDeckType == CardGame.DeckType.Type_DeckClub || 
			currentCard.Deck.oDeckType == CardGame.DeckType.Type_DeckDiamond || 
			currentCard.Deck.oDeckType == CardGame.DeckType.Type_DeckHeart || 
			currentCard.Deck.oDeckType == CardGame.DeckType.Type_DeckSpad) {
			if (currentCard.Deck.Cards.Count != 0) {
				CardDragList.Add (currentCard.Deck.TopCard);
			}
		}
		//For 3 Card Check
		if (currentCard.Deck.oDeckType == CardGame.DeckType.Type_DrawDeckCards) {
//						Debug.Log ("**** In Draw Deck Current Card = " + currentCard.ToString () + "Card Count = " + currentCard.Deck.cards.Count + "TopCard = " + currentCard.Deck.TopCard.ToString ());
			if (currentCard.Deck.cards.Count == 2 && currentCard == currentCard.Deck.TopCard) {
				currentCard.bUsed = true;
			} else if (currentCard.Deck.cards.Count == 1 && currentCard == currentCard.Deck.TopCard) {
				currentCard.bUsed = true;
			}
		}
		
		if (currentCard.bUsed == false) {
			bDrawDeckProc = true;
			return;
		}
		
		if (currentCard.Deck.oDeckType == CardGame.DeckType.Type_DrawDeckCards) {			
			//Only get the cards under selection
			if (currentCard.bUsed == true) {
				NGUIDebug.Log ("MouseDown Check card drag number  =>  " + CardGame.instance.cardGameObject [currentCard.gameobjectNumber].ToString ());
				currentCard.oOrigPosit [0] = CardGame.instance.cardGameObject [currentCard.gameobjectNumber].transform.position.x;
				currentCard.oOrigPosit [1] = CardGame.instance.cardGameObject [currentCard.gameobjectNumber].transform.position.y;
				currentCard.oOrigPosit [2] = CardGame.instance.cardGameObject [currentCard.gameobjectNumber].transform.position.z;

//								Debug.Log ("1) (Showing only USERD CARDS) currentCard.oOrigPosit[1]" + 
//										CardGame.instance.cardGameObject [currentCard.gameobjectNumber].transform.position);
//								Debug.Log ("2) currentCard.gameobjectNumber :: " + currentCard.gameobjectNumber);


				CardDragList.Add (currentCard);
			}
		} else {
			bool bFound = false;
			foreach (CardGame.Card otCard in currentCard.Deck.cards) {
//				print ("##Deep##Card = " + otCard.ToString() + "-" + otCard.bUsed.ToString());
//				print ("bFound"+bFound);
				if (bFound == false) {
					if (otCard == currentCard) {
						bFound = true;
					} else {
						continue;
					}
				}
				//Only get the cards under selection
				if (otCard.bUsed == true) {
					NGUIDebug.Log ("MouseDown Check OTCARD drag number  => " + otCard.ToString ());
					otCard.oOrigPosit [0] = CardGame.instance.cardGameObject [otCard.gameobjectNumber].transform.position.x;
					otCard.oOrigPosit [1] = CardGame.instance.cardGameObject [otCard.gameobjectNumber].transform.position.y;
					otCard.oOrigPosit [2] = CardGame.instance.cardGameObject [otCard.gameobjectNumber].transform.position.z;
					CardDragList.Add (otCard);

//										Debug.Log ("2) otCard.oOrigPosit [1]" + otCard.oOrigPosit [1]);
				}	
			}		
		}
		if (!isTouchActive) {
			isTouchActive = true;
			Debug.Log ("Pressed DOWN");
			Vector3 oTempPosit = gameObject.transform.position;
			oTempPosit.z = 0f;
//						oTempPosit.y = gameObject.collider.bounds.size.y*3/4;
			gameObject.transform.position = oTempPosit;
			screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
//						Debug.Log ("ScreenPoint = " + screenPoint);
			bShowRay = true;
		}
	}

	/// <summary>
	/// Resets the rotation.
	/// </summary>
	void ResetRotation ()
	{
		VariablePasser.Instance.underTween = false;
		CardGame.instance.cardGameObject [currentCard.gameobjectNumber].transform.rotation = Quaternion.identity;
	}
	void ResetPosition ()
	{
		VariablePasser.Instance.underTween = false;
	}
	/// <summary>
	/// Raises the mouse drag event.
	/// </summary>
	void OnMouseDrag ()
	{
				
		if (VariablePasser.Instance.underTween || CardDragList.Count == 0) {
			return;
		}
		if (underHint) {
			foreach (CardGame.Card otCard in CardDragList) {
				CardGame.instance.cardGameObject [otCard.gameobjectNumber].transform.position = new Vector3 (otCard.oOrigPosit [0], otCard.oOrigPosit [1], otCard.oOrigPosit [2]);
			}
		}
		if (bDrawDeckProc == true) {
			return;
		}
		if (CardGame.CardSelected == null)
			return;
		if (CardGame.CardSelected.GetHashCode () != transform.GetHashCode ())
			return;
		if (isTouchActive) {

//						Debug.Log ("Pressing.....");

			Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint);

			//Reposit for Move
			int nCnt = 0;
			Vector3 oTempPosit1 = curPosition;
			if (CardDragList.Count == 0) 
				return;

			oTempPosit1.y += CardGame.instance.cardGameObject [((CardGame.Card)CardDragList [0]).gameobjectNumber].collider.bounds.size.y * 1 / 2;
			oTempPosit1.z = 0;
				

			//Bug
//						if (dragged) {
			foreach (CardGame.Card otCard in CardDragList) {
//								Debug.Log ("Current Card :: " + otCard.Suit.ToString () + otCard.rank.ToString ());
				CardGame.instance.cardGameObject [otCard.gameobjectNumber].transform.position = oTempPosit1;
				nCnt++;
				oTempPosit1.y -= (LayoutClass.instance.spacerInPlayDeck);
				oTempPosit1.z -= (0.5f);
			}
//						}	
						
			vRay = Camera.main.ScreenPointToRay (Input.mousePosition);
						
			Vector3 oTemp = vRay.origin;
			oTemp.y += CardGame.instance.cardGameObject [((CardGame.Card)CardDragList [0]).gameobjectNumber].collider.bounds.size.y * 1 / 2;
			vRay.origin = oTemp;
						
		}
				
	}

		

	/// <summary>
	/// Bs the IS card valid.
	/// </summary>
	/// <returns><c>true</c>, if IS card valid was bed, <c>false</c> otherwise.</returns>
	/// <param name="oSrcCard">O source card.</param>
	/// <param name="oCheckCard">O check card.</param>
	bool bISCardValid (CardGame.Card oSrcCard, CardGame.Card oCheckCard)
	{
		//Ace Check
		if (oCheckCard.rank == CardGame.CardRank.a && (oSrcCard.rank == CardGame.CardRank.Deuce || oSrcCard.rank == CardGame.CardRank.k)) {
			return true;
		}
		if (oSrcCard.rank == CardGame.CardRank.a && (oCheckCard.rank == CardGame.CardRank.Deuce || oCheckCard.rank == CardGame.CardRank.k)) {
			return true;
		}	
	
		int nVal = ((int)oCheckCard.rank - (int)oSrcCard.rank);
		nVal = Math.Abs (nVal);
	
		if (nVal != 1) {
			return false;
		}
		
		return true;
	}
	/// <summary>
	/// Bs the IS card valid suite.
	/// </summary>
	/// <returns><c>true</c>, if IS card valid suite was bed, <c>false</c> otherwise.</returns>
	/// <param name="oSrcCard">O source card.</param>
	/// <param name="oCheckCard">O check card.</param>

	bool bISCardValidSuite (CardGame.Card oSrcCard, CardGame.Card oCheckCard)
	{
		

		if (oSrcCard.Suit == CardGame.CardSuit.c || oSrcCard.Suit == CardGame.CardSuit.s) {
			if (oCheckCard.Suit == CardGame.CardSuit.c || oCheckCard.Suit == CardGame.CardSuit.s) {
				return false;
			}
		}

		if (oSrcCard.Suit == CardGame.CardSuit.d || oSrcCard.Suit == CardGame.CardSuit.h) {
			if (oCheckCard.Suit == CardGame.CardSuit.d || oCheckCard.Suit == CardGame.CardSuit.h) {
				return false;
			}
		}
		
		//Ace Check
		if (oCheckCard.rank == CardGame.CardRank.a && (oSrcCard.rank == CardGame.CardRank.Deuce || oSrcCard.rank == CardGame.CardRank.k)) {
			return true;
		}
		if (oSrcCard.rank == CardGame.CardRank.a && (oCheckCard.rank == CardGame.CardRank.Deuce || oCheckCard.rank == CardGame.CardRank.k)) {
			return true;
		}	
		
		int nRank1 = (int)oCheckCard.rank;
		int nRank2 = (int)oSrcCard.rank;
			
//		print ("*** Rank1 = " + nRank1.ToString() + "Rank2 = " + nRank2.ToString());
		if (nRank2 > nRank1) {
			return false;
		}
			
		int nVal = ((int)oCheckCard.rank - (int)oSrcCard.rank);
		nVal = Math.Abs (nVal);
	
		if (nVal != 1) {
			return false;
		}		
		
		return true;
	}
/// <summary>
/// Vs the do score.
/// </summary>
/// <param name="oFromDeck">O from deck.</param>
/// <param name="oToDeck">O to deck.</param>
	void vDoScore (CardGame.Deck oFromDeck, CardGame.Deck oToDeck)
	{
		
//		if(oFromDeck.nDeckScoreLevel == CardGame.DeckScoreLevel.Score_Waste && oToDeck.nDeckScoreLevel == CardGame.DeckScoreLevel.Score_Tableau)
//		{
//			CardGame.nScore += 5;
//		}	
//
//		if(oFromDeck.nDeckScoreLevel == CardGame.DeckScoreLevel.Score_Waste && oToDeck.nDeckScoreLevel == CardGame.DeckScoreLevel.Score_Foundation)
//		{
//			CardGame.nScore += 10;
//		}
//		
//		if(oFromDeck.nDeckScoreLevel == CardGame.DeckScoreLevel.Score_Tableau && oToDeck.nDeckScoreLevel == CardGame.DeckScoreLevel.Score_Foundation)
//		{
//			CardGame.nScore += 10;
//		}
//
//		if(oFromDeck.nDeckScoreLevel == CardGame.DeckScoreLevel.Score_Foundation && oToDeck.nDeckScoreLevel == CardGame.DeckScoreLevel.Score_Tableau)
//		{
//			CardGame.nScore += 10;
//		}
		if (oToDeck.oDeckType == CardGame.DeckType.Type_DeckClub ||
			oToDeck.oDeckType == CardGame.DeckType.Type_DeckHeart ||
			oToDeck.oDeckType == CardGame.DeckType.Type_DeckDiamond ||
			oToDeck.oDeckType == CardGame.DeckType.Type_DeckSpad) {
			CardGame.instance.nScore += CardGame.instance.scoreMultiplier * 5;
		}
		
//		print("******* Score = " + CardGame.nScore);
	}

}
