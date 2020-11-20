using UnityEngine;
using System.Collections;

public class StatsGUI : MonoBehaviour
{
		//Total
		public UILabel totalBestScore;
		public UILabel totalGamesPlayed;
		public UILabel totalGamesWon;
		public UILabel totalPlayTime;
		//Easy Mode
		//Draw One
		public UILabel ESDOBestScore;
		public UILabel ESDOGamesPlayed;
		public UILabel ESDOGamesWon;
		public UILabel ESDOPlayTime;
		public UILabel ESDOMoves;
		//Draw Three
		public UILabel ESDTBestScore;
		public UILabel ESDTGamesPlayed;
		public UILabel ESDTGamesWon;
		public UILabel ESDTPlayTime;
		public UILabel ESDTMoves;
		//Medium Mode
		//Draw One
		public UILabel MSDOBestScore;
		public UILabel MSDOGamesPlayed;
		public UILabel MSDOGamesWon;
		public UILabel MSDOPlayTime;
		public UILabel MSDOMoves;
		//Draw Three
		public UILabel MSDTBestScore;
		public UILabel MSDTGamesPlayed;
		public UILabel MSDTGamesWon;
		public UILabel MSDTPlayTime;
		public UILabel MSDTMoves;
		//Hard Mode
		//Draw One
		public UILabel HSDOBestScore;
		public UILabel HSDOGamesPlayed;
		public UILabel HSDOGamesWon;
		public UILabel HSDOPlayTime;
		public UILabel HSDOMoves;
		//Draw Three
		public UILabel HSDTBestScore;
		public UILabel HSDTGamesPlayed;
		public UILabel HSDTGamesWon;
		public UILabel HSDTPlayTime;
		public UILabel HSDTMoves;
		// Use this for initialization

	
		// Update is called once per frame
		void Update ()
		{
				totalBestScore.text = Stats.instance.totalBestScore.ToString ();
				totalGamesPlayed.text = Stats.instance.totalGamesPlayed.ToString ();
				totalGamesWon.text = Stats.instance.totalGamesWon.ToString ();
//				totalPlayTime.text = string.Format("{0}:{1}", Stats.instance.totalPlayTimeMinutes.ToString(),Stats.instance.totalPlayTimeSeconds.ToString());
				//Easy Mode
				//Draw One
				ESDOBestScore.text = Stats.instance.ESDOBestScore.ToString ();
				ESDOGamesPlayed.text = Stats.instance.ESDOGamesPlayed.ToString ();
				ESDOGamesWon.text = Stats.instance.ESDOGamesWon.ToString ();
//		ESDOPlayTime.text = string.Format("{0}:{1}", Stats.instance.ESDOPlayTimeMinutes.ToString(),Stats.instance.ESDOPlayTimeSeconds.ToString());
				ESDOMoves.text = Stats.instance.ESDOMoves.ToString ();
				//Draw Three
				ESDTBestScore.text = Stats.instance.ESDTBestScore.ToString ();
				ESDTGamesPlayed.text = Stats.instance.ESDTGamesPlayed.ToString ();
				ESDTGamesWon.text = Stats.instance.ESDTGamesWon.ToString ();
//		ESDTPlayTime.text = string.Format("{0}:{1}", Stats.instance.ESDTPlayTimeMinutes.ToString(),Stats.instance.ESDTPlayTimeSeconds.ToString());
				ESDTMoves.text = Stats.instance.ESDTMoves.ToString ();
				//Medium Mode
				//Draw One
				MSDOBestScore.text = Stats.instance.MSDOBestScore.ToString ();
				MSDOGamesPlayed.text = Stats.instance.MSDOGamesPlayed.ToString ();
				MSDOGamesWon.text = Stats.instance.MSDOGamesWon.ToString ();
//		MSDOPlayTime.text = string.Format("{0}:{1}", Stats.instance.MSDOPlayTimeMinutes.ToString(),Stats.instance.MSDOPlayTimeSeconds.ToString());
				MSDOMoves.text = Stats.instance.MSDOMoves.ToString ();
				//Draw Three
				MSDTBestScore.text = Stats.instance.MSDTBestScore.ToString ();
				MSDTGamesPlayed.text = Stats.instance.MSDTGamesPlayed.ToString ();
				MSDTGamesWon.text = Stats.instance.MSDTGamesWon.ToString ();
//		MSDTPlayTime.text = string.Format("{0}:{1}", Stats.instance.MSDTPlayTimeMinutes.ToString(),Stats.instance.MSDTPlayTimeSeconds.ToString());
				MSDTMoves.text = Stats.instance.MSDTMoves.ToString ();
				//Hard Mode
				//Draw One
				HSDOBestScore.text = Stats.instance.HSDOBestScore.ToString ();
				HSDOGamesPlayed.text = Stats.instance.HSDOGamesPlayed.ToString ();
				HSDOGamesWon.text = Stats.instance.HSDOGamesWon.ToString ();
//		HSDOPlayTime.text = string.Format("{0}:{1}", Stats.instance.HSDOPlayTimeMinutes.ToString(),Stats.instance.HSDOPlayTimeSeconds.ToString());
				HSDOMoves.text = Stats.instance.HSDOMoves.ToString ();
				//Draw Three
				HSDTBestScore.text = Stats.instance.HSDTBestScore.ToString ();
				HSDTGamesPlayed.text = Stats.instance.HSDTGamesPlayed.ToString ();
				HSDTGamesWon.text = Stats.instance.HSDTGamesWon.ToString ();
//		HSDTPlayTime.text = string.Format("{0}:{1}", Stats.instance.HSDTPlayTimeMinutes.ToString(),Stats.instance.HSDTPlayTimeSeconds.ToString());
				HSDTMoves.text = Stats.instance.HSDTMoves.ToString ();
		}
}
