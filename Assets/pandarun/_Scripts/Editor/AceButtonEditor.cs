using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(AceButton))]
public class AceButtonEditor : Editor
{
	public override void OnInspectorGUI ()
	{
		AceButton buttonScript = (AceButton)target;
		
		
		EditorGUILayout.LabelField (" FOR UI BUTTON Actions  ");

		buttonScript.selectedAction =	(AceButton.ActionAt)EditorGUILayout.EnumPopup (buttonScript.selectedAction);
		buttonScript.SelectedButtonType =	(ButtonType)EditorGUILayout.EnumPopup (buttonScript.SelectedButtonType);
		switch (buttonScript.SelectedButtonType) {
		case ButtonType.EventGenerator:

			break;

		case ButtonType.TargetActiveDeactiveParent:
			buttonScript.ObjectToActivate = (GameObject)EditorGUILayout.ObjectField ("Target Object", buttonScript.ObjectToActivate, typeof(GameObject), true);
			buttonScript.ObjectToDeActivate = (GameObject)EditorGUILayout.ObjectField ("Deactivated Object", buttonScript.ObjectToDeActivate, typeof(GameObject), true);

			 
			break;


		case ButtonType.TargetActiveOnly:
			buttonScript.ObjectToActivate = (GameObject)EditorGUILayout.ObjectField ("Target Object", buttonScript.ObjectToActivate, typeof(GameObject), true);
 
			break;

		case ButtonType.ScriptActive:
 
			buttonScript.behaviour = (MonoBehaviour)EditorGUILayout.ObjectField ("Script ref to Activate ", buttonScript.behaviour, typeof(MonoBehaviour), true);
			break;

		case ButtonType.ScriptDisable:
			buttonScript.behaviour = (MonoBehaviour)EditorGUILayout.ObjectField ("Script ref to De_Activate ", buttonScript.behaviour, typeof(MonoBehaviour), true);
			break;


		case ButtonType.SetPlayerPrefence:
			//PlayerPrefs.SetString (stringValue, levelToLoad);
			buttonScript.stringValue = EditorGUILayout.TextField ("player prefence id string", buttonScript.stringValue);
			buttonScript.levelToLoad = EditorGUILayout.TextField ("player prefence string Value ", buttonScript.levelToLoad);

			break;
		case ButtonType.SetPlayerPrefenceInt:
			buttonScript.stringValue = EditorGUILayout.TextField ("player prefence id string", buttonScript.stringValue);
			buttonScript.levelToLoad = EditorGUILayout.TextField ("player prefence Integer Value ", buttonScript.levelToLoad);

			break;


		case ButtonType.OpenUrl:
			EditorGUILayout.LabelField (" Opens More Apps links based on platfrom ,write game links inside the script");
			break;

		case ButtonType.FbLike:
			EditorGUILayout.LabelField (" Opens Fb Page Link");
			break;
		case ButtonType.PramoteGame:
			EditorGUILayout.LabelField ("write promotion gameLink in script");
			break;



		case ButtonType.ApplicationQuit:
			EditorGUILayout.LabelField ("Quits app");
			break;

		case ButtonType.LoadNextLevel:
			EditorGUILayout.LabelField (" opens next scene/level");
			break;

		case ButtonType.LoadLevel:
			 
			buttonScript.levelToLoad = EditorGUILayout.TextField ("Scene name", buttonScript.levelToLoad);
			break;
		case ButtonType.LoadedLevel:
			EditorGUILayout.LabelField (" Restarts current Scene");
			break;
		case ButtonType.GamePaused:
			EditorGUILayout.LabelField (" will pause the game");
			break;
		case ButtonType.Gameresumed:
			EditorGUILayout.LabelField (" will Resumes  the game");
			break;
		case ButtonType.StartMusic:
			EditorGUILayout.LabelField (" will starts playing  sounds");
			break;
		case ButtonType.StopMusic:
			EditorGUILayout.LabelField ("stops all sounds");
			break;
		case ButtonType.OpenReview:
			EditorGUILayout.LabelField ("Will automatically opens review link for android ,for ios windows ,plz   write directly inside script");

			break;
		case ButtonType.AceActionScriptCall:
			buttonScript.aceActionScriptIDName = EditorGUILayout.TextField ("AceAction Script Name is ", buttonScript.aceActionScriptIDName);

			break;
		case ButtonType.AceTweenScriptCall:
			buttonScript.aceActionScriptIDName = EditorGUILayout.TextField ("AceTween Script Name is ", buttonScript.aceActionScriptIDName);

			break;
		}

		buttonScript.delay = EditorGUILayout.FloatField ("Delay", buttonScript.delay);
		buttonScript.canPlayClickSound = EditorGUILayout.Toggle ("Can Click Sound When Pressed", buttonScript.canPlayClickSound);
	}
}