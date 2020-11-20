using UnityEngine;
using System.Collections;

public class TurnDeck : MonoBehaviour
{
		void OnMouseDown ()
		{	
				if (CardGame.instance.oDrawDeck.cards.Count == 0) {			
						CardGame.instance.vTurnDeckClick (false);
				}
		}
}
