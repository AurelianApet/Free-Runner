using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class INGameUI : MonoBehaviour
{
	public int numberofCoins, life = 3, CoinsToDisplay, scoreToDisplay;
	public static int scoreCount, glucosa, glucosa_old;
	public Text CoinText, LevelText, ScoreText, LifeText;
	public GameObject HUD, Pause, LevelComplete, GameOver, Tip;
	public bool isGameEnded = false;
	public bool isLevelEnd = false;
	PlayerController PlayerScript;
	CollisionAndTrigger CollisionAndTriggerScript;
	SoundController soundcontrollerScript;

	public Sprite glucosa1;
	public Sprite glucosa2;
	public Sprite glucosa3;
	public Sprite glucosa4;
	public Sprite glucosa5;

	public Sprite glucosa1Check;
	public Sprite glucosa2Check;
	public Sprite glucosa3Check;
	public Sprite glucosa4Check;
	public Sprite glucosa5Check;

	public Sprite glucosa1Check_en;
	public Sprite glucosa2Check_en;
	public Sprite glucosa3Check_en;
	public Sprite glucosa4Check_en;
	public Sprite glucosa5Check_en;

	public Sprite glucosa1Check_it;
	public Sprite glucosa2Check_it;
	public Sprite glucosa3Check_it;
	public Sprite glucosa4Check_it;
	public Sprite glucosa5Check_it;

	public static int INSULINA_CORRECCION = 50; 
	public static int GLUCOSA_INICIAL = 130; 

	public AudioClip gluHigh;
	public AudioClip gluDown;

	public AudioClip uinsulin;

	public Sprite consejo1;
	public Sprite consejo2;
	public Sprite consejo3;

	public Sprite consejo1_en;
	public Sprite consejo2_en;
	public Sprite consejo3_en;

	public Sprite consejo1_it;
	public Sprite consejo2_it;
	public Sprite consejo3_it;

	public Sprite consejos_en;
	public Sprite consejos_it;

	public Sprite chequeo_en;
	public Sprite level_cleared_en;

	public Sprite chequeo_it;
	public Sprite level_cleared_it;

	// VERY LOW 1, LOW 2, NORMAL 3, HIGH 4, VERY HIGH 5 
	public int CURRENT_INSULINA_LEVEL = 3;

	void OnEnable ()
	{
		soundcontrollerScript = FindObjectOfType<SoundController> ();
		CollisionAndTrigger.displayAd += displayerAD;
		CollisionAndTriggerScript = FindObjectOfType<CollisionAndTrigger> ();
		PlayerScript = FindObjectOfType<PlayerController> ();
		HUD.SetActive (true);
		Pause.SetActive (false);
		Tip.SetActive (false);
		LevelComplete.SetActive (false);
		GameOver.SetActive (false);
	}

	void displayerAD (System.Object obj, EventArgs args)
	{
		//Debug.Log ("Ad called");
	}

	// Use this for initialization
	void Start ()
	{
		scoreCount = 0;
		glucosa = GLUCOSA_INICIAL;
		LifeText.text = life.ToString ();
		isGameEnded = false;
		LevelText.text = SceneManager.GetActiveScene ().name.ToString ();

		GameObject canvas_ = GameObject.Find ("InGameUi");
		GameObject coin_ = canvas_.transform.Find( "HUD/Coin").gameObject;
		GameObject coin2_ = canvas_.transform.Find( "LevelComplete/Bg/Coins").gameObject;
		GameObject life_ = canvas_.transform.Find( "HUD/Life").gameObject;
		GameObject score_ = canvas_.transform.Find( "HUD/Score").gameObject;
		GameObject score2_ = canvas_.transform.Find( "LevelComplete/Bg/Score").gameObject;

		if (Application.systemLanguage != SystemLanguage.Spanish) {
			
			GameObject chequeo_ = canvas_.transform.Find ("Pause/Button").gameObject;
			GameObject level_cleared_ = canvas_.transform.Find ("LevelComplete/Bg").gameObject;
			GameObject tip_ = canvas_.transform.Find ("Tip/Button").gameObject;

			if (Application.systemLanguage == SystemLanguage.Italian) {
				chequeo_.GetComponent<Image> ().sprite = chequeo_it;
				level_cleared_.GetComponent<Image> ().sprite = level_cleared_it;
				tip_.GetComponent<Image> ().sprite = consejos_it;

				//coin_.GetComponentsInChildren<Text> () [0].text = "Monete:";
				//coin2_.GetComponentsInChildren<Text> () [0].text = "Monete:";
				life_.GetComponentsInChildren<Text> () [0].text = "Vite <color=#ff9999>x </color>";
				score_.GetComponentsInChildren<Text> () [0].text = "Punti:";
				score2_.GetComponentsInChildren<Text> () [0].text = "Punti:";

			} else {
				chequeo_.GetComponent<Image> ().sprite = chequeo_en;
				level_cleared_.GetComponent<Image> ().sprite = level_cleared_en;
				tip_.GetComponent<Image> ().sprite = consejos_en;

				//coin_.GetComponentsInChildren<Text> () [0].text = "Coins :";
				//coin2_.GetComponentsInChildren<Text> () [0].text = "Coins :";
				life_.GetComponentsInChildren<Text> () [0].text = "Life <color=#ff9999>x </color>";
				score_.GetComponentsInChildren<Text> () [0].text = "Score :";
				score2_.GetComponentsInChildren<Text> () [0].text = "Score :";
			}
		} else {
			//coin_.GetComponentsInChildren<Text> () [0].text = "Monedas:";
			//coin2_.GetComponentsInChildren<Text> () [0].text = "Monedas:";
			life_.GetComponentsInChildren<Text> () [0].text = "Vida <color=#ff9999>x </color>";
			score_.GetComponentsInChildren<Text> () [0].text = "Puntos:";
			score2_.GetComponentsInChildren<Text> () [0].text = "Puntos:";
		}

	}

	void Update ()
	{
		CoinText.text = numberofCoins.ToString ();
		ScoreText.text = scoreCount.ToString ();
		scoreToDisplay = scoreCount;

		//Debug.Log ("********************** GLUCOSA:" + glucosa.ToString() );


		try {

			GameObject inGameUi_ = GameObject.Find("InGameUi");
			GameObject glucoseCheck_ = inGameUi_.transform.Find( "Pause/Button/GlucoseCheck" ).gameObject;

			if (glucosa > 300) {
				//Debug.Log ("RED IMAGE");
				//Debug.Log ("***** GAME OVER *******");

				GameObject.Find ("Glucose").GetComponent<Image> ().sprite = glucosa5;
				if ( Application.systemLanguage != SystemLanguage.Spanish ) {
					if (Application.systemLanguage == SystemLanguage.Italian) {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa5Check_it;
					} else {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa5Check_en;
					}
				} else {
					glucoseCheck_.GetComponent<Image> ().sprite = glucosa5Check;
				}

				life--;
				transform.position = new Vector3 (-7.1f, 0.2f, 0.0f);
				LifeText.text = life.ToString ();
				ShowTip();

			} else if (glucosa <= 299 && glucosa > 250) {
				//Debug.Log ("RED IMAGE");

				GameObject.Find ("Glucose").GetComponent<Image> ().sprite = glucosa5;
				if ( Application.systemLanguage != SystemLanguage.Spanish ) {
					if (Application.systemLanguage == SystemLanguage.Italian) {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa5Check_it;
					} else {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa5Check_en;
					}
				} else {
					glucoseCheck_.GetComponent<Image> ().sprite = glucosa5Check;
				}

				if ( CURRENT_INSULINA_LEVEL != 5 ) {
					AudioSource audioPlayer = gameObject.AddComponent<AudioSource> ();
					audioPlayer.clip = gluHigh;
					audioPlayer.Play ();
				}
				CURRENT_INSULINA_LEVEL = 5;

			} else if (glucosa <= 249 && glucosa > 180) {
				//Debug.Log ("ORANGE IMAGE...");

				GameObject.Find ("Glucose").GetComponent<Image> ().sprite = glucosa4;
				if ( Application.systemLanguage != SystemLanguage.Spanish ) {
					if (Application.systemLanguage == SystemLanguage.Italian) {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa4Check_it;
					} else {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa4Check_en;
					}
				} else {
					glucoseCheck_.GetComponent<Image> ().sprite = glucosa4Check;
				}

				if ( CURRENT_INSULINA_LEVEL != 4 ) {
					AudioSource audioPlayer = gameObject.AddComponent<AudioSource> ();
					audioPlayer.clip = gluHigh;
					audioPlayer.Play ();
				}
				CURRENT_INSULINA_LEVEL = 4;

			} else if (glucosa <= 179 && glucosa > 100) {
				//Debug.Log ("GREEN IMAGE");

				GameObject.Find ("Glucose").GetComponent<Image> ().sprite = glucosa3;
				if ( Application.systemLanguage != SystemLanguage.Spanish ) {
					if (Application.systemLanguage == SystemLanguage.Italian) {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa3Check_it;
					} else {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa3Check_en;
					}
				} else {
					glucoseCheck_.GetComponent<Image> ().sprite = glucosa3Check;
				}

				CURRENT_INSULINA_LEVEL = 3;

			} else if (glucosa <= 99 && glucosa > 70) {
				//Debug.Log ("BLUE IMAGE");

				GameObject.Find ("Glucose").GetComponent<Image> ().sprite = glucosa2;
				if ( Application.systemLanguage != SystemLanguage.Spanish ) {
					if (Application.systemLanguage == SystemLanguage.Italian) {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa2Check_it;
					} else {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa2Check_en;
					}
				} else {
					glucoseCheck_.GetComponent<Image> ().sprite = glucosa2Check;
				}

				if ( CURRENT_INSULINA_LEVEL != 2 ) {
					AudioSource audioPlayer = gameObject.AddComponent<AudioSource> ();
					audioPlayer.clip = gluDown;
					audioPlayer.Play ();
				}
				CURRENT_INSULINA_LEVEL = 2;

			} else if (glucosa <= 69 && glucosa > 20) {
				//Debug.Log ("SKYBLUE IMAGE");

				GameObject.Find ("Glucose").GetComponent<Image> ().sprite = glucosa1;
				if ( Application.systemLanguage != SystemLanguage.Spanish ) {
					if (Application.systemLanguage == SystemLanguage.Italian) {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa1Check_it;
					} else {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa1Check_en;
					}
				} else {
					glucoseCheck_.GetComponent<Image> ().sprite = glucosa1Check;
				}

				if ( CURRENT_INSULINA_LEVEL != 1 ) {
					AudioSource audioPlayer = gameObject.AddComponent<AudioSource> ();
					audioPlayer.clip = gluDown;
					audioPlayer.Play ();
				}
				CURRENT_INSULINA_LEVEL = 1;

			} else if (glucosa <= 19 ) {
				//Debug.Log ("SKYBLUE IMAGE");
				//Debug.Log ("***** GAME OVER *******");
				GameObject.Find ("Glucose").GetComponent<Image> ().sprite = glucosa1;
				if ( Application.systemLanguage != SystemLanguage.Spanish ) {
					if (Application.systemLanguage == SystemLanguage.Italian) {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa1Check_it;
					} else {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa1Check_en;
					}
				} else {
					glucoseCheck_.GetComponent<Image> ().sprite = glucosa1Check;
				}

				life--;
				transform.position = new Vector3 (-7.1f, 0.2f, 0.0f);
				LifeText.text = life.ToString ();
				ShowTip();

			}

		} catch (Exception) {
			//Debug.Log ("Error on Update INGameUI ");
		}

	}

	public void aplicarInsulina(int insulina) {
		//Debug.Log ( "aplicarInsulina: " + insulina );
		//Debug.Log ( "Glucosa Inicial: " + glucosa );
		//Debug.Log ( "Factor de correccion: " + INSULINA_CORRECCION );
		try {

			GameObject inGameUi_ = GameObject.Find("InGameUi");
			GameObject insulin_ = inGameUi_.transform.Find( "Pause/Button/Insulin" + insulina ).gameObject;
			GameObject insulinoff_ = inGameUi_.transform.Find( "Pause/Button/Insulin" + insulina + "off" ).gameObject;
			GameObject glucoseCheck_ = inGameUi_.transform.Find( "Pause/Button/GlucoseCheck" ).gameObject;

			//insulin_.GetComponent<Image> ().sprite = insulina_off;
			insulin_.SetActive(false);
			insulinoff_.SetActive(true);

			glucosa = glucosa - INSULINA_CORRECCION;

			AudioSource audioPlayer = gameObject.AddComponent<AudioSource> ();
			audioPlayer.clip = uinsulin;
			audioPlayer.Play ();

			//Debug.Log ( "Glucosa Nueva: " + glucosa );


			if (glucosa > 250) {
				//Debug.Log ("----------- RED IMAGE ------------");
				if ( Application.systemLanguage != SystemLanguage.Spanish ) {
					if (Application.systemLanguage == SystemLanguage.Italian) {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa5Check_it;
					} else {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa5Check_en;
					}
				} else {
					glucoseCheck_.GetComponent<Image> ().sprite = glucosa5Check;
				}
			} else if (glucosa <= 249 && glucosa > 180) {
				//Debug.Log ("---------- ORANGE IMAGE ----------");
				if ( Application.systemLanguage != SystemLanguage.Spanish ) {
					if (Application.systemLanguage == SystemLanguage.Italian) {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa4Check_it;
					} else {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa4Check_en;
					}
				} else {
					glucoseCheck_.GetComponent<Image> ().sprite = glucosa4Check;
				}
			} else if (glucosa <= 179 && glucosa > 100) {
				//Debug.Log ("---------- GREEN IMAGE ----------");
				if ( Application.systemLanguage != SystemLanguage.Spanish ) {
					if (Application.systemLanguage == SystemLanguage.Italian) {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa3Check_it;
					} else {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa3Check_en;
					}
				} else {
					glucoseCheck_.GetComponent<Image> ().sprite = glucosa3Check;
				}
			} else if (glucosa <= 99 && glucosa > 70) {
				//Debug.Log ("---------- BLUE IMAGE ----------");
				if ( Application.systemLanguage != SystemLanguage.Spanish ) {
					if (Application.systemLanguage == SystemLanguage.Italian) {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa2Check_it;
					} else {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa2Check_en;
					}
				} else {
					glucoseCheck_.GetComponent<Image> ().sprite = glucosa2Check;
				}
			} else if (glucosa <= 69) {
				//Debug.Log ("---------- SKYBLUE IMAGE ----------");
				if ( Application.systemLanguage != SystemLanguage.Spanish ) {
					if (Application.systemLanguage == SystemLanguage.Italian) {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa1Check_it;
					} else {
						glucoseCheck_.GetComponent<Image> ().sprite = glucosa1Check_en;
					}
				} else {
					glucoseCheck_.GetComponent<Image> ().sprite = glucosa1Check;
				}
			}

		} catch (Exception) {
			//Debug.Log ("Error on aplicarInsulina INGameUI ");
		}
	}

	public void StarDisplay ()
	{
		//Debug.Log ("--------------->> StarDisplay <<-----------------");
		//Debug.Log ("COINS: " + numberofCoins);
		if (numberofCoins < 15) {
			PlayerPrefs.SetInt (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name.ToLower (), 0);
			//Debug.Log ("--------------->> SET 0 stars for user");

		} else if (numberofCoins >= 15 && numberofCoins < 25) {
			PlayerPrefs.SetInt (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name.ToLower (), 1);
			////Debug.Log (PlayerPrefs.GetInt (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name, 0));
			//Debug.Log ("--------------->> SET 1 stars for user");
		
		} else if (numberofCoins < 37 && numberofCoins >= 25) {
			PlayerPrefs.SetInt (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name.ToLower (), 2);
			//Debug.Log ("--------------->> SET 2 stars for user");
		
		} else if (numberofCoins >= 37) {
			PlayerPrefs.SetInt (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name.ToLower (), 3);
			//Debug.Log ("--------------->> SET 3 stars for user");
		
		}

		int display = PlayerPrefs.GetInt (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name.ToLower (), 0);
		////Debug.Log (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name.ToLower () + "_assinged player pref value " + display);
		//Debug.Log ("=========>> Display:" + display);
	
		GameObject inGameUi_ = GameObject.Find("InGameUi");

		if ( display >= 1 ) {
			GameObject filledStar1 = inGameUi_.transform.Find( "LevelComplete/Bg/Start/FilledStar1").gameObject;
			filledStar1.SetActive (true);
			//Debug.Log ("STAR 1 ACTIVE!");
		}
		if ( display >= 2 ) {
			GameObject filledStar2 = inGameUi_.transform.Find( "LevelComplete/Bg/Start/FilledStar2").gameObject;
			filledStar2.SetActive (true);
			//Debug.Log ("STAR 2 ACTIVE!");
		}
		if ( display >= 3 ) {
			GameObject filledStar3 = inGameUi_.transform.Find( "LevelComplete/Bg/Start/FilledStar3").gameObject;
			filledStar3.SetActive (true);
			//Debug.Log ("STAR 3 ACTIVE!");
		}
	}

	public void OnLevelEnd ()
	{

		isGameEnded = true;
		AceEvents.stoploopsounds ("bgMusic", null);
		HUD.SetActive (false);
		LevelComplete.SetActive (true);
		StarDisplay ();
		//		GameObject.FindGameObjectWithTag ("ADS").SendMessage ("showFullAD", SendMessageOptions.DontRequireReceiver);
	}

	public void OnGameOver ()
	{		
		HUD.SetActive (false);
		Time.timeScale = 0;
		GameOver.SetActive (true);
		AceEvents.stoploopsounds ("bgMusic", null);
	}

	public void PauseGame ()
	{

		if (Time.timeScale == 1) {
			Time.timeScale = 0;
			Pause.SetActive (true);
			HUD.SetActive (false);
			AceEvents.stoploopsounds ("bgMusic", null);

		} else {
			Time.timeScale = 1;
			AceEvents.playloopsounds ("bgMusic", null);
		}

	}

	public void ShowTip ()
	{
		GameObject inGameUi_ = GameObject.Find("InGameUi");
		GameObject tips_ = inGameUi_.transform.Find( "Tip/Button/Consejos" ).gameObject;

		if (glucosa > 300) {
			if ( Application.systemLanguage != SystemLanguage.Spanish ) {
				if (Application.systemLanguage == SystemLanguage.Italian) {
					tips_.GetComponent<Image> ().sprite = consejo3_it;
				} else {
					tips_.GetComponent<Image> ().sprite = consejo3_en;
				}
			} else {
				tips_.GetComponent<Image> ().sprite = consejo3;
			}

		} else if (glucosa < 20) {
			if ( Application.systemLanguage != SystemLanguage.Spanish ) {
				if (Application.systemLanguage == SystemLanguage.Italian) {
					tips_.GetComponent<Image> ().sprite = consejo2_it;
				} else {
					tips_.GetComponent<Image> ().sprite = consejo2_en;
				}
			} else {
				tips_.GetComponent<Image> ().sprite = consejo2;
			}
		} else {
			if ( Application.systemLanguage != SystemLanguage.Spanish ) {
				if (Application.systemLanguage == SystemLanguage.Italian) {
					tips_.GetComponent<Image> ().sprite = consejo1_it;
				} else {
					tips_.GetComponent<Image> ().sprite = consejo1_en;
				}
			} else {
				tips_.GetComponent<Image> ().sprite = consejo1;
			}
		}

		if (Time.timeScale == 1) {
			Time.timeScale = 0;
			Tip.SetActive (true);
			HUD.SetActive (false);
			AceEvents.stoploopsounds ("bgMusic", null);

		} else {
			Time.timeScale = 1;
			AceEvents.playloopsounds ("bgMusic", null);
		}

	}

	public void HideTip () {
		glucosa = 140;
		Time.timeScale = 1;
		Tip.SetActive (false);
		HUD.SetActive (true);
		AceEvents.playloopsounds ("bgMusic", null);
		CollisionAndTriggerScript.transform.position = new Vector3 (-7.1f, 0.2f, 0.0f);
		//Debug.Log ("transform.position->" + transform.position);
	}

	public void ResumeGame ()
	{
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
			Pause.SetActive (false);
			HUD.SetActive (true);
			AceEvents.playloopsounds ("bgMusic", null);
		} else {
			Time.timeScale = 0;
			AceEvents.stoploopsounds ("bgMusic", null);
		}
	}

	public void JumpButton ()
	{
		PlayerScript.setJumpBool ();
	}

	public void LoadNextLevel ()
	{
		SceneManager.LoadScene (CollisionAndTriggerScript.GetNextLevel);
	}

	public void RestartLevel ()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
	public void loadHomeLevel( )
	{
		SceneManager.LoadScene ("Home");
	}


}
