using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bgPlay : MonoBehaviour
{

	public Sprite play_en;
	public Sprite more_en;
	public Sprite review_en;
	public Sprite instructions_en;
	public Sprite exit_en;
	public Sprite level_en;
	public Sprite instructions_bg_en;
	public Sprite play_it;
	public Sprite more_it;
	public Sprite review_it;
	public Sprite instructions_it;
	public Sprite exit_it;
	public Sprite level_it;
	public Sprite instructions_bg_it;

	// Use this for initialization
	void Start ()
	{
		AceEvents.playloopsounds ("bgMusic", null);

		if (Application.systemLanguage != SystemLanguage.Spanish) {
			GameObject canvas_ = GameObject.Find("MainMenu");

			GameObject play_ = canvas_.transform.Find( "Menu/Play").gameObject;
			GameObject more_ = canvas_.transform.Find( "Menu/More").gameObject;
			GameObject review_ = canvas_.transform.Find( "Menu/Review").gameObject;
			GameObject instructions_ = canvas_.transform.Find( "Menu/Credit").gameObject;
			GameObject exit_ = canvas_.transform.Find( "Menu/Exit").gameObject;
			GameObject level_ = canvas_.transform.Find( "LevelSelection/BG").gameObject;
			GameObject instructions_bg_ = canvas_.transform.Find( "Credit/CreditName").gameObject;
			GameObject exit_text_ = canvas_.transform.Find( "Exit/Bg/TextHelp").gameObject;
			GameObject exit_q_text_ = canvas_.transform.Find( "Exit/Bg/TextExit").gameObject;
			GameObject exit_yes_text_ = canvas_.transform.Find( "Exit/Bg/Yes/Text").gameObject;
			GameObject game3_text_ = canvas_.transform.Find( "Exit/Bg/game3/game3text").gameObject;
			GameObject game1_text_ = canvas_.transform.Find( "Exit/Bg/game1/game1text").gameObject;




			if (Application.systemLanguage == SystemLanguage.Italian) {
				play_.GetComponent<Image> ().sprite = play_it;
				more_.GetComponent<Image> ().sprite = more_it;
				review_.GetComponent<Image> ().sprite = review_it;
				instructions_.GetComponent<Image> ().sprite = instructions_it;
				exit_.GetComponent<Image> ().sprite = exit_it;
				level_.GetComponent<Image> ().sprite = level_it;
				instructions_bg_.GetComponent<Image> ().sprite = instructions_bg_it;
				exit_text_.GetComponentsInChildren<Text> () [0].text = "Aiutaci nello sviluppo di nuove app... Scarica, gioca e vota i nostri giochi!";
				exit_q_text_.GetComponentsInChildren<Text> () [0].text = "Sei sicuro di voler uscire?";
				exit_yes_text_.GetComponentsInChildren<Text> () [0].text = "Sì";
				game3_text_.GetComponentsInChildren<Text> () [0].text = "Numbers";
				game1_text_.GetComponentsInChildren<Text> () [0].text = "Maths Game";

			} else {
				play_.GetComponent<Image> ().sprite = play_en;
				more_.GetComponent<Image> ().sprite = more_en;
				review_.GetComponent<Image> ().sprite = review_en;
				instructions_.GetComponent<Image> ().sprite = instructions_en;
				exit_.GetComponent<Image> ().sprite = exit_en;
				level_.GetComponent<Image> ().sprite = level_en;
				instructions_bg_.GetComponent<Image> ().sprite = instructions_bg_en;
				exit_text_.GetComponentsInChildren<Text>()[0].text = "Help us to keep working... download, play and rate our games!";
				exit_q_text_.GetComponentsInChildren<Text>()[0].text = "Are you sure you want exit?";
				exit_yes_text_.GetComponentsInChildren<Text>()[0].text = "Yes";
				game3_text_.GetComponentsInChildren<Text>()[0].text = "Numbers";
				game1_text_.GetComponentsInChildren<Text>()[0].text = "Maths Game";
			
			}
		}
	}
	
	 
}
