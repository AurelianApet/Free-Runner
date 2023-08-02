using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public enum ButtonType
{

	EventGenerator,
	TargetActiveDeactiveParent,
	TargetActiveOnly,
	ScriptActive,
	ScriptDisable,
	SetPlayerPrefence,
	SetPlayerPrefenceInt,
	OpenUrl,
	ApplicationQuit,
	LoadNextLevel,
	LoadLevel,
	LoadedLevel,
	GamePaused,
	Gameresumed,
	FbLike,
	StopMusic,
	StartMusic,
	PramoteGame,
	OpenReview,
	AceActionScriptCall,
	AceTweenScriptCall}
;

[Serializable]


public class AceButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, ISubmitHandler
{
	public ButtonType SelectedButtonType;
	public GameObject ObjectToActivate, ObjectToDeActivate;
	public MonoBehaviour behaviour;
	public string stringValue = "PlayerIndex";
	public string levelToLoad;
	public string aceActionScriptIDName;
	public static EventHandler buttonDown, buttonUp;

	public bool canPlayClickSound = true;
	public float delay;

	public enum ActionAt
	{
		OnUp,
		OnDown

	}

	public ActionAt selectedAction;

	void OnEnable ()
	{
        
		buttonDown += onButtonDown;
		buttonUp += onButtonUp;

	 

	}

	void OnDisable ()
	{

		buttonDown -= onButtonDown;
		buttonUp -= onButtonUp;


	}

     
	public void OnSubmit (BaseEventData eventData)
	{

		Debug.Log (eventData.selectedObject.name);
		onButtonDown (eventData.selectedObject.name, null);

	}


	void Start ()
	{
 

		validateData ();
	}


	void onButtonDown (System.Object obj, EventArgs args)
	{

		if (!gameObject.activeSelf)
			return;
		if (!obj.ToString ().Contains (gameObject.name))
			return;

		if (selectedAction != ActionAt.OnDown)
			return;
		

		if (Time.timeScale == 0) {
			ExecuteButtonAction ();
		} else {

			Invoke ("ExecuteButtonAction", delay);
		}
	}

	void onButtonUp (System.Object obj, EventArgs args)
	{
		if (!gameObject.activeSelf)
			return;
		if (!obj.ToString ().Contains (gameObject.name))
			return;

		if (selectedAction != ActionAt.OnUp)
			return;
		
		if (Time.timeScale == 0) {
			ExecuteButtonAction ();
		} else {

			Invoke ("ExecuteButtonAction", delay);
		}

	}


	void ExecuteButtonAction ()
	{
		if (AceEvents.playSingleshotsounds != null && canPlayClickSound) {
			AceEvents.playSingleshotsounds ("Click", null);
		}


		switch (SelectedButtonType) {
		case ButtonType.EventGenerator:

			break;

		case ButtonType.TargetActiveDeactiveParent:
			ObjectToActivate.SetActive (true);
			ObjectToDeActivate.SetActive (false);
			break;


		case ButtonType.TargetActiveOnly:
			ObjectToActivate.SetActive (true);
			break;

		case ButtonType.ScriptActive:
			behaviour.enabled = true;
			break;

		case ButtonType.ScriptDisable:
			behaviour.enabled = false;
			break;


		case ButtonType.SetPlayerPrefence:
			PlayerPrefs.SetString (stringValue, levelToLoad);
			print ("AB:PlayerPrefs" + PlayerPrefs.GetString (stringValue, levelToLoad));
			break;
		case ButtonType.SetPlayerPrefenceInt:
			PlayerPrefs.SetInt (stringValue, int.Parse (levelToLoad));
			print ("AB:PlayerPrefs set value" + stringValue);
			break;


		case ButtonType.OpenUrl:
			OpenUrl ();
			break;

		case ButtonType.FbLike:
			FbLike ();
			break;
		case ButtonType.PramoteGame:
			GameLink ();
			break;



		case ButtonType.ApplicationQuit:
			Application.Quit ();
			Debug.Log ("Exit");
			break;

		case ButtonType.LoadNextLevel:

			SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().buildIndex + 1);
			break;

		case ButtonType.LoadLevel:

			SceneManager.LoadSceneAsync (levelToLoad);

			break;
		case ButtonType.LoadedLevel:

			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			break;
		case ButtonType.GamePaused:
			AceEvents.MuteSound (null, null);
			Time.timeScale = 0;
			break;
		case ButtonType.Gameresumed:
			AceEvents.playSound (null, null);
			Time.timeScale = 1;
			break;
		case ButtonType.StartMusic:
			if (AceEvents.playSound != null)
				AceEvents.playSound (null, null);
			break;
		case ButtonType.StopMusic:
			if (AceEvents.MuteSound != null)
				AceEvents.MuteSound (null, null);
			break;
		case ButtonType.OpenReview:

			#if UNITY_ANDROID
			Application.OpenURL ("https://play.google.com/store/apps/details?id=" + Application.bundleIdentifier);
			#endif
			#if UNITY_IOS
			Application.OpenURL (" " );//urlf or appstore
			#endif
			#if UNITY_WP81
			Application.OpenURL (" " );//urlf or appstore
			#endif
			break;


		case ButtonType.AceActionScriptCall:

			if (AceEvents.AceActionCall != null) {
				AceEvents.AceActionCall (aceActionScriptIDName, null);
			}
			break;
		case ButtonType.AceTweenScriptCall:

			if (AceEvents.AceTweenCall != null) {
				AceEvents.AceTweenCall (aceActionScriptIDName, null);
			}
			break;
		}
	}

	#region ButtonUP


	#endregion


	void OpenUrl ()
	{
     
		#if UNITY_IPHONE
		//Application.OpenURL("https://itunes.apple.com/us/developer/kiran-kumar/id674476457");
		# elif UNITY_ANDROID
		Application.OpenURL ("https://play.google.com/store/apps/developer?id=M1Play.com");
		#elif UNITY_WP8
		 
		#endif
		if (AceEvents.OpenMoreGames != null) {
			AceEvents.OpenMoreGames (null, null);
		}

	}

	void FbLike ()
	{
		Application.OpenURL ("https://www.facebook.com/");

	
	}

	void GameLink ()
	{
		//Application.OpenURL ("market://details?id=com.Acegames.Tunnel");


	}

	//handling clickEvents
	public void OnPointerDown (PointerEventData data)
	{
      
		if (buttonDown != null)
			buttonDown (gameObject.name, null);
		
	}

	public void OnPointerUp (PointerEventData data)
	{
		
		if (buttonUp != null)
			buttonUp (gameObject.name, null);
	}

	

	void validateData ()
	{
		switch (SelectedButtonType) {
		case ButtonType.EventGenerator:
			break;
			
		case ButtonType.TargetActiveOnly:
		case ButtonType.TargetActiveDeactiveParent:

			if (ObjectToActivate == null)
				Debug.LogError (gameObject.name + " plz give reference to ObjectToActivate variable");
		
			break;
	 
			
		case ButtonType.ScriptActive:
		 
		case ButtonType.ScriptDisable:
			if (behaviour == null)
				Debug.LogError (gameObject.name + " plz give reference to behaviour variable");
			break;
			
		case ButtonType.SetPlayerPrefence:
			
			break;
			
		case ButtonType.OpenUrl:
			
			break;
			
		case ButtonType.ApplicationQuit:
			
			break;
			
		case ButtonType.LoadNextLevel:
			
			break;
			
		case ButtonType.LoadLevel:
			
			break;
		case ButtonType.LoadedLevel:
			
			break;
		case ButtonType.GamePaused:
			
			break;
		case ButtonType.Gameresumed:
			
			break;
		}
	}
}
