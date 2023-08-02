using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpalshScreen : MonoBehaviour {

	// How to make an animation
	//public GameObject logo;

	public Sprite aviso_en;
	public Sprite play_en;
	public Sprite aviso_it;
	public Sprite play_it;

	// Use this for initialization
	void Start () {
		/*
		Invoke("loadMenuLevel",3.0f);
		iTween.FadeTo(logo,1.0f,1.0f);
		iTween.FadeTo(logo,iTween.Hash("alpha",0,"time",1f,"delay",2.0f)); 
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		*/

		if (Application.systemLanguage != SystemLanguage.Spanish) {
			GameObject canvas_ = GameObject.Find("SplashScreenCavas");
			GameObject aviso_ = canvas_.transform.Find( "aviso").gameObject;
			GameObject play_ = canvas_.transform.Find( "play").gameObject;

			if (Application.systemLanguage == SystemLanguage.Italian) {
				aviso_.GetComponent<Image> ().sprite = aviso_it;
				play_.GetComponent<Image> ().sprite = play_it;
			} else {
				aviso_.GetComponent<Image> ().sprite = aviso_en;
				play_.GetComponent<Image> ().sprite = play_en;
			}
		}

	}
	// Update is called once per frame
	public void loadMenuLevel( )
	{
		SceneManager.LoadScene ("Home");
	}
	void Update () 
	{  

	}
}
