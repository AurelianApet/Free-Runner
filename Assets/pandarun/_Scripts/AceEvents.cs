using System.Collections;
using System;

 
public class AceEvents
{
	//for game
	public static EventHandler OnGameStart;
	public static EventHandler OnGameEnd;
	public static EventHandler OnGamePause;
	public static EventHandler OnGameResume;
	public static EventHandler OnGameExit;
	public static EventHandler AceActionCall;
	public static EventHandler AceTweenCall;


	//for player
	public static EventHandler OnPlayerRespawn;
	public static EventHandler OnPlayerDead;
	public static EventHandler OnPlayerHealthPickup;
	public static EventHandler OnPlayerCoinPickup;
	public static EventHandler OnPlayerShieldPickup;
	public static EventHandler OnPlayerMagnetPickup;
	public static EventHandler OnPlayerTimerPickup;
	public static EventHandler OnPlayerMultiplerPickup;

	//for inputs
	public static EventHandler OnSwipeUp;
	public static EventHandler OnSwipeDown;
	public static EventHandler OnSwipeRight;
	public static EventHandler OnSwipeLeft;

	//for Ui

	public static EventHandler AddScore;
	public static EventHandler AddCoins;
	public static EventHandler AddDistance;
	public static EventHandler AddMutiplier;
	public static EventHandler DecreaseHealth;


	//for sound

	public static EventHandler playSound;
	public static EventHandler MuteSound;
	public static EventHandler playSingleshotsounds;
	public static EventHandler playloopsounds;
	public static EventHandler stoploopsounds;
	//for playerRespawn


	//for cameraShake
	public static EventHandler ShakeCameraSmall;
	public static EventHandler ShakeCameraBig;


	 
	 

	//External wp8 calls
	public static EventHandler OpenReview;
	public static EventHandler OpenMoreGames;


	//ads
	public static EventHandler	StartADs;
	public static EventHandler showAdd;
	public static EventHandler showVideo;
	public static EventHandler CheckIfVideoAvailable;


}