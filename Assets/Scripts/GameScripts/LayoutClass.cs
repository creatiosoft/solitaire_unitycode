using UnityEngine;
using System.Collections;
using System.Xml;
public class LayoutClass : MonoBehaviour
{
		public TextAsset portraitXML;
		public TextAsset landscapeXML;
		public TextAsset landscapeXML_IPhone5S;
		public TextAsset portrait_iPhone5s;
		public static LayoutClass instance = null;
		public bool initialize = false;
		private bool changeOrientation = true;
		public bool freezeRotation = false;
		//Variables
		[HideInInspector]
		public Vector2
				backgroundScaleRatio = Vector2.zero;
//	[HideInInspector]
		public Vector2 cardSlotScaleRatio = Vector2.zero;
		[HideInInspector]
		public Vector2
				cardScaleRatio = Vector2.zero;
		[HideInInspector]
		public Vector2
				drawDeckCardsStartPosRatio = Vector2.zero;
		[HideInInspector]
		public Vector2
				drawDeckStartPosRatio = Vector2.zero;
		[HideInInspector]
		public Vector2
				drawDeckHiddenStartPosRatio = Vector2.zero;
		[HideInInspector]
		public Vector2
				discardDeckStartPosRatio = Vector2.zero;
		[HideInInspector]
		public Vector2
				playDeckStartPos = Vector2.zero;
		[HideInInspector]
		public Vector2
				spacerDrawDeckCards = Vector2.zero;
		[HideInInspector]
		public Vector2
				spacerInDiscardDeck = Vector2.zero;
		[HideInInspector]
		public Vector2
				spacerPlayDeck = Vector2.zero;
		[HideInInspector]
		public float
				spacerInPlayDeck = 0;
		//GUI
		public GameObject landscapeHUD;
		public GameObject portraitHUD;
		//End
		//Portrait Variables
		Vector2 backgroundScaleRatioP = Vector2.zero;
		Vector2 cardSlotScaleRatioP = Vector2.zero;
		Vector2 cardScaleRatioP = Vector2.zero;
		Vector2 drawDeckCardsStartPosRatioP = Vector2.zero;
		Vector2 drawDeckStartPosRatioP = Vector2.zero;
		Vector2 drawDeckHiddenStartPosRatioP = Vector2.zero;
		Vector2 discardDeckStartPosRatioP = Vector2.zero;
		Vector2 playDeckStartPosP = Vector2.zero;
		Vector2 spacerDrawDeckCardsP = Vector2.zero;
		Vector2 spacerInDiscardDeckP = Vector2.zero;
		Vector2 spacerPlayDeckP = Vector2.zero;
		float spacerInPlayDeckP = 0;
		//End

		//LandscapeVariables
		Vector2 backgroundScaleRatioL = Vector2.zero;
		Vector2 cardSlotScaleRatioL = Vector2.zero;
		Vector2 cardScaleRatioL = Vector2.zero;
		Vector2 drawDeckCardsStartPosRatioL = Vector2.zero;
		Vector2 drawDeckStartPosRatioL = Vector2.zero;
		Vector2 drawDeckHiddenStartPosRatioL = Vector2.zero;
		Vector2 discardDeckStartPosRatioL = Vector2.zero;
		Vector2 playDeckStartPosL = Vector2.zero;
		Vector2 spacerDrawDeckCardsL = Vector2.zero;
		Vector2 spacerInDiscardDeckL = Vector2.zero;
		Vector2 spacerPlayDeckL = Vector2.zero;
		float spacerInPlayDeckL = 0;
		//End

		float screenAspectRatio = 0;
		float screenAspectRatioL = 0;

		public enum PreviousRotation
		{
				Landscape =0,
				Portrait
	}
		;

		public PreviousRotation previousRotation;
		//End

		void Awake ()
		{
				NGUIDebug.Log (SystemInfo.deviceModel);
				previousRotation = (PreviousRotation)VariablePasser.Instance.previousRotation;

				if (VariablePasser.Instance.previousRotation == VariablePasser.PreviousRotation.Landscape) {
						screenAspectRatio = (float)((float)Screen.height / (float)Screen.width);
						screenAspectRatioL = (float)((float)Screen.width / (float)Screen.height);
				} else {
						screenAspectRatio = (float)((float)Screen.width / (float)Screen.height);
						screenAspectRatioL = (float)((float)Screen.height / (float)Screen.width);
				}
//		previousRotation = PreviousRotation.Portrait;
				
				ReadXMLLandscape ();
				ReadXMLPortrait ();

		}

		void Start ()
		{
				instance = this;
		}
		float myDrawDeckOffsetX = 0;
		float myDrawDeckOffsetY = .4f;
		// Update is called once per frame
		void Update ()
		{
				//Enable Rotation
//		if(CardGame.instance.bSetupDone)
//		{
//			Screen.autorotateToLandscapeLeft = true;
//			Screen.autorotateToPortrait = true;
//		}
//		if(!freezeRotation)
//		{
//		if(Input.deviceOrientation == DeviceOrientation.LandscapeLeft && previousRotation == PreviousRotation.Portrait )
//		{
//			previousRotation = PreviousRotation.Landscape;
//			changeOrientation = true;
//		}

//		if(Input.deviceOrientation == DeviceOrientation.Portrait && previousRotation == PreviousRotation.Landscape)
//		{
//			previousRotation = PreviousRotation.Portrait;
//			changeOrientation = true;
//		}
//		}

				if (previousRotation == PreviousRotation.Landscape && changeOrientation) {

						NGUIDebug.Log ("PreviousRotation.Landscape");
						backgroundScaleRatio = backgroundScaleRatioL;
						cardSlotScaleRatio = cardSlotScaleRatioL;
						cardScaleRatio = cardScaleRatioL;
						drawDeckCardsStartPosRatio = drawDeckCardsStartPosRatioL + new Vector2 (myDrawDeckOffsetX, myDrawDeckOffsetY);
						drawDeckStartPosRatio = drawDeckStartPosRatioL + new Vector2 (myDrawDeckOffsetX, myDrawDeckOffsetY);
						drawDeckHiddenStartPosRatio = drawDeckHiddenStartPosRatioL + new Vector2 (myDrawDeckOffsetX, myDrawDeckOffsetY);
						discardDeckStartPosRatio = discardDeckStartPosRatioL + new Vector2 (myDrawDeckOffsetX, myDrawDeckOffsetY);
						playDeckStartPos = playDeckStartPosL;
						spacerDrawDeckCards = spacerDrawDeckCardsL;
						spacerInDiscardDeck = spacerInDiscardDeckL;
						spacerPlayDeck = spacerPlayDeckL;
						spacerInPlayDeck = spacerInPlayDeckL;

						if (CardGame.instance.bSetupDone) 
								CardGame.instance.ChangeOrientation (false, true);
						else if (initialize)
								CardGame.instance.Initializer ();
						changeOrientation = false;
						landscapeHUD.SetActive (true);
						portraitHUD.SetActive (false);
						SetupBackGroundElements ();
				}

//		if(previousRotation == PreviousRotation.Portrait && changeOrientation)
//		{
//			NGUIDebug.Log("PreviousRotation.Portrait");
//			backgroundScaleRatio = backgroundScaleRatioP;
//			cardSlotScaleRatio= cardSlotScaleRatioP;
//			cardScaleRatio= cardScaleRatioP;
//			drawDeckCardsStartPosRatio= drawDeckCardsStartPosRatioP;
//			drawDeckStartPosRatio= drawDeckStartPosRatioP;
//			drawDeckHiddenStartPosRatio= drawDeckHiddenStartPosRatioP;
//			discardDeckStartPosRatio= discardDeckStartPosRatioP;
//			playDeckStartPos= playDeckStartPosP;
//			spacerDrawDeckCards= spacerDrawDeckCardsP;
//			spacerInDiscardDeck= spacerInDiscardDeckP;
//			spacerPlayDeck= spacerPlayDeckP;
//			spacerInPlayDeck = spacerInPlayDeckP;
//			if(CardGame.instance.bSetupDone)
//				CardGame.instance.ChangeOrientation(false,true);
//			else if(initialize)
//				CardGame.instance.Initializer();
//
//			SetupBackGroundElements();
//			landscapeHUD.SetActive(false);
//			portraitHUD.SetActive(true);
//			changeOrientation = false;
//
//		}

		}

		void ReadXMLPortrait ()
		{

				XmlDocument portXML = new XmlDocument ();
				string deviceModel = SystemInfo.deviceModel;
				if (deviceModel.Substring (0, 6) == "iPhone") {
						int temp = int.Parse (deviceModel.Substring (6, 1));
						if (temp > 4) {
								portXML.LoadXml (portrait_iPhone5s.text);
						} else {
								portXML.LoadXml (portraitXML.text);

						}

				} else {
						portXML.LoadXml (portraitXML.text);
				}
		
		
				XmlNode node3 = portXML.SelectSingleNode ("Portrait");
				XmlNodeList nodeList = node3.ChildNodes;
				if (nodeList.Count != 0) {
						backgroundScaleRatioP = new Vector2 (float.Parse (nodeList [0].Attributes [0].Value),
			                                    float.Parse (nodeList [0].Attributes [1].Value)
						) * screenAspectRatio;

						cardSlotScaleRatioP = new Vector2 (float.Parse (nodeList [1].Attributes [0].Value),
			                                 float.Parse (nodeList [1].Attributes [1].Value)
						) * screenAspectRatio;
						cardScaleRatioP = new Vector2 (float.Parse (nodeList [2].Attributes [0].Value),
			                             float.Parse (nodeList [2].Attributes [1].Value)
						) * screenAspectRatio;
						drawDeckCardsStartPosRatioP = new Vector2 (float.Parse (nodeList [3].Attributes [0].Value),
			                                         float.Parse (nodeList [3].Attributes [1].Value)
						) * screenAspectRatio;
						drawDeckStartPosRatioP = new Vector2 (float.Parse (nodeList [4].Attributes [0].Value),
			                                    float.Parse (nodeList [4].Attributes [1].Value)
						) * screenAspectRatio;
						drawDeckHiddenStartPosRatioP = new Vector2 (float.Parse (nodeList [5].Attributes [0].Value),
			                                          float.Parse (nodeList [5].Attributes [1].Value)
						) * screenAspectRatio;
						discardDeckStartPosRatioP = new Vector2 (float.Parse (nodeList [6].Attributes [0].Value),
			                                       float.Parse (nodeList [6].Attributes [1].Value)
						) * screenAspectRatio;
						playDeckStartPosP = new Vector2 (float.Parse (nodeList [7].Attributes [0].Value),
			                               float.Parse (nodeList [7].Attributes [1].Value)
						) * screenAspectRatio;
						spacerDrawDeckCardsP = new Vector2 (float.Parse (nodeList [8].Attributes [0].Value),
			                                 float.Parse (nodeList [8].Attributes [1].Value)
						) * screenAspectRatio;
						spacerInDiscardDeckP = new Vector2 (float.Parse (nodeList [9].Attributes [0].Value),
			                                 float.Parse (nodeList [9].Attributes [1].Value)
						) * screenAspectRatio;
						spacerPlayDeckP = new Vector2 (float.Parse (nodeList [10].Attributes [0].Value),
			                             float.Parse (nodeList [10].Attributes [1].Value)
						) * screenAspectRatio;
						spacerInPlayDeckP = float.Parse (nodeList [11].Attributes [0].Value) * screenAspectRatio;
			                             
				}

				initialize = true;
		}

		void ReadXMLLandscape ()
		{
				XmlDocument landXML = new XmlDocument ();

//		string test = SystemInfo.deviceModel;
				string deviceModel = SystemInfo.deviceModel;
				if (deviceModel.Substring (0, 6) == "iPhone") {
						int temp = int.Parse (deviceModel.Substring (6, 1));
						if (temp > 4) {
								landXML.LoadXml (landscapeXML_IPhone5S.text);
						} else {
								landXML.LoadXml (landscapeXML.text);
						}

				} else {
						landXML.LoadXml (landscapeXML.text);
				}
		
		
				XmlNode node3 = landXML.SelectSingleNode ("Landscape");
				XmlNodeList nodeList = node3.ChildNodes;
				if (nodeList.Count != 0) {
						backgroundScaleRatioL = new Vector2 (float.Parse (nodeList [0].Attributes [0].Value),
			                                    float.Parse (nodeList [0].Attributes [1].Value)
						) * screenAspectRatioL;
			
						cardSlotScaleRatioL = new Vector2 (float.Parse (nodeList [1].Attributes [0].Value),
			                                 float.Parse (nodeList [1].Attributes [1].Value)
						) * screenAspectRatioL;
						cardScaleRatioL = new Vector2 (float.Parse (nodeList [2].Attributes [0].Value),
			                             float.Parse (nodeList [2].Attributes [1].Value)
						) * screenAspectRatioL;
						drawDeckCardsStartPosRatioL = new Vector2 (float.Parse (nodeList [3].Attributes [0].Value),
			                                         float.Parse (nodeList [3].Attributes [1].Value)
						) * screenAspectRatioL;
						drawDeckStartPosRatioL = new Vector2 (float.Parse (nodeList [4].Attributes [0].Value),
			                                    float.Parse (nodeList [4].Attributes [1].Value)
						) * screenAspectRatioL;
						drawDeckHiddenStartPosRatioL = new Vector2 (float.Parse (nodeList [5].Attributes [0].Value),
			                                          float.Parse (nodeList [5].Attributes [1].Value)
						) * screenAspectRatioL;
						discardDeckStartPosRatioL = new Vector2 (float.Parse (nodeList [6].Attributes [0].Value),
			                                       float.Parse (nodeList [6].Attributes [1].Value)
						) * screenAspectRatioL;
						playDeckStartPosL = new Vector2 (float.Parse (nodeList [7].Attributes [0].Value),
			                               float.Parse (nodeList [7].Attributes [1].Value)
						) * screenAspectRatioL;
						spacerDrawDeckCardsL = new Vector2 (float.Parse (nodeList [8].Attributes [0].Value),
			                                 float.Parse (nodeList [8].Attributes [1].Value)
						) * screenAspectRatioL;
						spacerInDiscardDeckL = new Vector2 (float.Parse (nodeList [9].Attributes [0].Value),
			                                 float.Parse (nodeList [9].Attributes [1].Value)
						) * screenAspectRatioL;
						spacerPlayDeckL = new Vector2 (float.Parse (nodeList [10].Attributes [0].Value),
			                             float.Parse (nodeList [10].Attributes [1].Value)
						) * screenAspectRatioL;
						spacerInPlayDeckL = float.Parse (nodeList [11].Attributes [0].Value) * screenAspectRatioL;
			
				}
		}
		public Transform[] DeckDiscard;
		public Transform NextCard;
		public Transform[] PlayDeck;
		public float scaleMultiplier;
		void SetupBackGroundElements ()
		{
				float offsetX = 0;
				float offsetY = 0;
				foreach (Transform t in DeckDiscard) {
						t.position = new Vector3 (discardDeckStartPosRatio.x - offsetX, discardDeckStartPosRatio.y + offsetY, 19.0f);
						if (previousRotation == PreviousRotation.Portrait)
								offsetX += spacerInDiscardDeck.x;
						else
								offsetY += spacerInDiscardDeck.y;
						t.localScale = new Vector3 (cardSlotScaleRatio.x, cardSlotScaleRatio.y, 1.0f);// * scaleMultiplier;
				}
				NextCard.position = new Vector3 (drawDeckStartPosRatio.x, drawDeckStartPosRatio.y, 19.0f);
				NextCard.localScale = new Vector3 (cardSlotScaleRatio.x, cardSlotScaleRatio.y, 1.0f);// * scaleMultiplier;
//		BackGround.localScale = new Vector3(backgroundScaleRatio.x,backgroundScaleRatio.y,1);
				offsetX = 0;
				foreach (Transform t in PlayDeck) {
						t.position = new Vector3 (playDeckStartPos.x - offsetX, playDeckStartPos.y, 19.0f);
						offsetX += spacerPlayDeck.x;
						t.localScale = new Vector3 (cardSlotScaleRatio.x, cardSlotScaleRatio.y, 1.0f); //* scaleMultiplier;
				}
		}
}
