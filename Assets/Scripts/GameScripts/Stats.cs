using UnityEngine;
using System.Collections;
[System.Serializable]
public class Stats{
	public static Stats instance;
	//Total
	public int totalBestScore;
	public int totalGamesPlayed;
	public int totalGamesWon;
	public int totalPlayTimeMinutes;
	public int totalPlayTimeSeconds;
	//Easy Mode
		//Draw One
	public int ESDOBestScore;
	public int ESDOGamesPlayed;
	public int ESDOGamesWon;
	public int ESDOPlayTimeMinutes;
	public int ESDOPlayTimeSeconds;
	public int ESDOMoves;
		//Draw Three
	public int ESDTBestScore;
	public int ESDTGamesPlayed;
	public int ESDTGamesWon;
	public int ESDTPlayTimeMinutes;
	public int ESDTPlayTimeSeconds;
	public int ESDTMoves;
	//Medium Mode
		//Draw One
	public int MSDOBestScore;
	public int MSDOGamesPlayed;
	public int MSDOGamesWon;
	public int MSDOPlayTimeMinutes;
	public int MSDOPlayTimeSeconds;
	public int MSDOMoves;
		//Draw Three
	public int MSDTBestScore;
	public int MSDTGamesPlayed;
	public int MSDTGamesWon;
	public int MSDTPlayTimeMinutes;
	public int MSDTPlayTimeSeconds;
	public int MSDTMoves;
	//Hard Mode
		//Draw One
	public int HSDOBestScore;
	public int HSDOGamesPlayed;
	public int HSDOGamesWon;
	public int HSDOPlayTimeMinutes;
	public int HSDOPlayTimeSeconds;
	public int HSDOMoves;
		//Draw Three
	public int HSDTBestScore;
	public int HSDTGamesPlayed;
	public int HSDTGamesWon;
	public int HSDTPlayTimeMinutes;
	public int HSDTPlayTimeSeconds;
	public int HSDTMoves;
	//Current Game

	public int currentScore;
	public int currentMoves;
	public int currentTimeMinutes;
	public int currentTimeSeconds;
	public int currentScoreMultiplier;
	// Use this for initialization
	public Stats() {
		instance = this;
	}

}
