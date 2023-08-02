using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.Events;

[CustomEditor (typeof(AceAction))]

public class AceActionsEditor : Editor
{

	// Use this for initialization
	string SoundNames;
	SoundController soundScript;

	 
	public override void OnInspectorGUI ()
	{
		AceAction action = (AceAction)target;
		EditorGUILayout.BeginVertical (EditorStyles.inspectorDefaultMargins);

		EditorGUILayout.Space ();
		  
		 

		if (action.hideDetails) {

			if (GUILayout.Button (":::  " + action.scriptUseage.ToString () + "  :::", EditorStyles.whiteBoldLabel, GUILayout.Width (180))) {
				action.hideDetails = false;
			}
			return;
		}
		if (GUILayout.Button ("Hide", EditorStyles.miniButtonMid, GUILayout.Width (80))) {
			action.hideDetails = true;
		}
		EditorGUILayout.Space ();
		EditorGUILayout.Space ();
		action.SelectionState =	(ActionState)EditorGUILayout.EnumPopup ("Action Occurance At", action.SelectionState);
		action.DelayInAction = EditorGUILayout.FloatField ("Execute Action After", action.DelayInAction);
	
		switch (action.SelectionState) {
		case ActionState.OnCollisionEnter:
		case ActionState.OnCollisionExit:
		case ActionState.OnTriggerEnter:
		case ActionState.OnTriggerExit:
			action.SelectedObject =	(OtherObject)EditorGUILayout.EnumPopup ("Incoming  is ", action.SelectedObject);
			if (action.SelectedObject == OtherObject.SpecifiedName) {

				action.otherObjectName = EditorGUILayout.TextField ("Expected Incoming  Name", action.otherObjectName);
			}

			if (action.SelectedObject == OtherObject.SpecifiedTag) {

				action.otherObjectName = EditorGUILayout.TextField ("Expected Incoming  Tag", action.otherObjectName);
			}

			break;
		}


		action.SelectionActionType =	(ActionType)EditorGUILayout.EnumPopup ("By Action Type", action.SelectionActionType);

		switch (action.SelectionActionType) {

		case ActionType.UnityEvents:

			SerializedProperty sprop = serializedObject.FindProperty ("UnityAction");

			EditorGUILayout.PropertyField (sprop);
			
			serializedObject.ApplyModifiedProperties ();
			break;


		case ActionType.GameEvents:
			//EditorGUILayout.LabelField ("*****************Comming Soon********************");


			action.selectedTask =	(TaskType)EditorGUILayout.EnumPopup ("Action Task", action.selectedTask);
			 
			switch (action.selectedTask) {
			case TaskType.Deactivate:
			case TaskType.Activate:
				action.findMethod =	(TargetFindMedhtod)EditorGUILayout.EnumPopup ("Get ", action.findMethod);
				if (action.findMethod == TargetFindMedhtod.byName) {
					action.value = EditorGUILayout.TextField ("Object Name", action.value);
				}
				if (action.findMethod == TargetFindMedhtod.byTag) {
					action.value = EditorGUILayout.TextField ("Object Tag", action.value);
				}
				break;	
			case TaskType.BroadCastMessage:
			case TaskType.SendMessage:
				action.findMethod =	(TargetFindMedhtod)EditorGUILayout.EnumPopup ("Get ", action.findMethod);
				if (action.findMethod == TargetFindMedhtod.byName) {
					action.value = EditorGUILayout.TextField ("Object Name", action.value);
				}
				if (action.findMethod == TargetFindMedhtod.byTag) {
					action.value = EditorGUILayout.TextField ("Object Tag", action.value);
				}

				action.functionName = EditorGUILayout.TextField ("FunctionName ", action.functionName);
				break;
			case TaskType.AceActionScriptCall:

				action.ScriptName = EditorGUILayout.TextField ("Other Script Name", action.ScriptName);

				break;

			case TaskType.DestroyTarget:
				action.findMethod =	(TargetFindMedhtod)EditorGUILayout.EnumPopup ("Get ", action.findMethod);
				if (action.findMethod == TargetFindMedhtod.byName) {
					action.value = EditorGUILayout.TextField ("Object Name", action.value);
				}
				if (action.findMethod == TargetFindMedhtod.byTag) {
					action.value = EditorGUILayout.TextField ("Object Tag", action.value);
				}


				break;
			case TaskType.DestroyThisObject:
				//

				break;
			case TaskType.PlayLoopSound:

//				action.value = EditorGUILayout.TextField ("LoopClip Name to Start Is ", action.value);
//
//				SoundNames = "";
//				soundScript = FindObjectOfType<SoundController> ();
//
//				foreach (AudioSource source in soundScript.loopSounds) {
//
//					SoundNames += source.name + "\n";
//				}
//
//				 
//				foreach (string s in SoundNames.Split('\n')) {
//					if (s.Length != 0 && !action.value.Contains (s)) {  
//						if (GUILayout.Button (s, GUILayout.Width (120))) {
//							action.value = s;
//						}
//					}
//				}
//				 
				break;
			case TaskType.PlaySingleShotSound:

//				action.value = EditorGUILayout.TextField ("Clip Name to Play Is ", action.value);
//
//
//				SoundNames = "";
//				soundScript = FindObjectOfType<SoundController> ();
//
//				foreach (SoundsAndName source in soundScript.SingleShotSounds) {
//
//					SoundNames += source.name + "\n";
//				}
//
//
//				foreach (string s in SoundNames.Split('\n')) {
//					if (s.Length != 0 && !action.value.Contains (s)) {  
//						if (GUILayout.Button (s, GUILayout.Width (120))) {
//							action.value = s;
//						}
//					}
//				}

				break;
			case TaskType.StopLoopSound:

//				action.value = EditorGUILayout.TextField ("LoopClip Name to Stop Is", action.value);
//
//				SoundNames = "";
//				soundScript = FindObjectOfType<SoundController> ();
//
//				foreach (AudioSource source in soundScript.loopSounds) {
//
//					SoundNames += source.name + "\n";
//				}
//
//
//				foreach (string s in SoundNames.Split('\n')) {
//					if (s.Length != 0 && !action.value.Contains (s)) {  
//						if (GUILayout.Button (s, GUILayout.Width (120))) {
//							action.value = s;
//						}
//					}
//				}

				break;
			case TaskType.AddCoins:

				action.value = EditorGUILayout.TextField ("Coins Increment value", action.value);

				break;
			case TaskType.AddScore:

				action.value = EditorGUILayout.TextField ("Score Increment value", action.value);

				break;
			}

			 


			break;

		}
		EditorGUILayout.Space ();
		if (action.SelectionState == ActionState.ScriptCall) {
			action.ScriptName = EditorGUILayout.TextField ("Script ID Name", action.ScriptName);
			EditorGUILayout.Space ();
			 
			EditorGUILayout.Space ();
			 
			EditorGUILayout.LabelField ("other scripts can Call this scripts  ProcessAction() \n " +
			"function by send message GameObject's Find or FindWithTag", EditorStyles.helpBox);
		 
			 
		}
		EditorGUILayout.Space ();
		EditorGUILayout.Space ();
		action.scriptUseage = EditorGUILayout.TextField ("write script useage info", action.scriptUseage);
	
		EditorGUILayout.EndVertical ();
	}
}
