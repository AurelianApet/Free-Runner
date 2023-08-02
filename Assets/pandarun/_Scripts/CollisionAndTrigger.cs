using UnityEngine;
using System.Collections;
using System;

public class CollisionAndTrigger : MonoBehaviour
{

	// Use this for initialization
	public GameObject ScorePrefab;

	public static EventHandler displayAd;
	public PlayerController playerControllerChild;
	public INGameUI InGameUiScript;
	public string GetNextLevel;

	public int HDC_APPLE 	= 60;
	public int HDC_SANDWICH = 60;
	public int HDC_ICECREAM = 90;

	public int GLUCOSA_WASTE = 2; 

	void OnEnable ()
	{
		InGameUiScript = FindObjectOfType<INGameUI> ();
	
	}

	void OnTriggerEnter (Collider incoming)
	{

		//Debug.Log ("*** incoming.tag:" + incoming.tag);

		if (incoming.tag == "coin") {

			incoming.gameObject.SetActive (false);
			InGameUiScript.numberofCoins++;
			//INGameUI.scoreCount = INGameUI.scoreCount + 100;
			GameObject ScoreIndicator = Instantiate (ScorePrefab, incoming.transform.position, Quaternion.identity)as GameObject;
			AceEvents.playSingleshotsounds ("CoinHit", null);

			INGameUI.glucosa = INGameUI.glucosa - GLUCOSA_WASTE;
			//Debug.Log ("*** INGameUI.glucosa:" + INGameUI.glucosa );

		
		} else if (incoming.tag == "apple") {

			//Debug.Log ("+++++ APPLE ++++");

			incoming.gameObject.SetActive (false);
			//InGameUiScript.numberofCoins++;
			//INGameUI.scoreCount = INGameUI.scoreCount + 100;
			GameObject ScoreIndicator = Instantiate (ScorePrefab, incoming.transform.position, Quaternion.identity)as GameObject;
			AceEvents.playSingleshotsounds ("CoinHit", null);

			INGameUI.glucosa = INGameUI.glucosa + HDC_APPLE;


		} else if (incoming.tag == "sandwich") {

			//Debug.Log ("+++++ SANDWICH ++++");

			incoming.gameObject.SetActive (false);
			//InGameUiScript.numberofCoins++;
			//INGameUI.scoreCount = INGameUI.scoreCount + 100;
			GameObject ScoreIndicator = Instantiate (ScorePrefab, incoming.transform.position, Quaternion.identity)as GameObject;
			AceEvents.playSingleshotsounds ("CoinHit", null);

			INGameUI.glucosa = INGameUI.glucosa + HDC_SANDWICH;
		

		} else if (incoming.tag == "icecream") {

			//Debug.Log ("+++++ ICECREAM ++++");

			incoming.gameObject.SetActive (false);
			//InGameUiScript.numberofCoins++;
			//INGameUI.scoreCount = INGameUI.scoreCount + 100;
			GameObject ScoreIndicator = Instantiate (ScorePrefab, incoming.transform.position, Quaternion.identity)as GameObject;
			AceEvents.playSingleshotsounds ("CoinHit", null);

			INGameUI.glucosa = INGameUI.glucosa + HDC_ICECREAM;
		
		}

		if (incoming.tag == "LevelName") {
			GetNextLevel = incoming.gameObject.name;
			//Debug.Log (GetNextLevel);
		}

	}

	void OnControllerColliderHit (ControllerColliderHit hit)
	{
		if (hit.collider.tag == "coin") {
			hit.gameObject.SetActive (false);
			GameObject ScoreIndicator = Instantiate (ScorePrefab, hit.collider.transform.position, Quaternion.identity)as GameObject;
		}

		if (hit.collider.name.Contains ("respawn")) {
			InGameUiScript.life--;
			if (InGameUiScript.life < 0) {
				InGameUiScript.life = 0;
				InGameUiScript.OnGameOver ();	
			} else {
				transform.position = hit.collider.transform.GetChild (0).transform.position;
				////Debug.Log ("transform.position:" + transform.position);
				InGameUiScript.ShowTip();
			}

		}
	
		InGameUiScript.LifeText.text = InGameUiScript.life.ToString ();

		if (hit.collider.name.Contains ("final")) {			 
			hit.collider.name = "END";
			gameObject.SendMessage ("StopPlayerAnimation", SendMessageOptions.DontRequireReceiver);
			InGameUiScript.OnLevelEnd ();
			if (displayAd != null)
				displayAd (null, null);
		}

	}
}
