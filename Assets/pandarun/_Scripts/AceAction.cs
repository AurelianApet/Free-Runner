using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

public enum ActionState
{
	
	OnEnable,
	OnDisable,
	OnTriggerEnter,
	OnTriggerExit,
	OnCollisionEnter,
	OnCollisionExit,
	ScriptCall
	
}

public enum ActionType
{
	
	GameEvents,
	UnityEvents
	
}

public enum OtherObject
{
	
	AnyOne,
	SpecifiedName,
	SpecifiedTag
	
}

public enum TargetFindMedhtod
{
	
	byCollision,
	byTriggered,
	byTag,
	byName,

}

public enum TaskType
{
	
	Activate,
	Deactivate,
	SendMessage,
	BroadCastMessage,
	AceActionScriptCall,
	DestroyThisObject,
	DestroyTarget,
	PlaySingleShotSound,
	PlayLoopSound,
	StopLoopSound,
	AddCoins,
	AddScore
	
}

public class AceAction : MonoBehaviour
{
	GameObject Target;
	// Use this for initialization
	public ActionState SelectionState;
	public ActionType SelectionActionType;
	public OtherObject SelectedObject;
	public string ScriptName = "Empty";
	//Ace Events
	public TaskType selectedTask;
	public float DelayInAction = 0;
	 
	public TargetFindMedhtod findMethod;
	public string value;
	public string functionName;
	public string otherObjectName;
	public UnityEvent UnityAction;

	public bool hideDetails;
	public string scriptUseage = "EMPTY_NONE";

	void AceEvent ()
	{
		switch (selectedTask) {
		case TaskType.SendMessage:
			AssaginTarget ();//target object for collision and colliding will be assagin in oncollision and onTrigger Enter and exit
			Target.SendMessage (functionName, SendMessageOptions.DontRequireReceiver);
			break;
		case TaskType.BroadCastMessage:
			AssaginTarget ();//target object for collision and colliding will be assagin in oncollision and onTrigger Enter and exit
			Target.BroadcastMessage (functionName, SendMessageOptions.DontRequireReceiver);
			break;
		case TaskType.Activate:
			AssaginTarget ();//target object for collision and colliding will be assagin in oncollision and onTrigger Enter and exit
			Target.SetActive (true);
			break;
		case TaskType.Deactivate:
			AssaginTarget ();//target object for collision and colliding will be assagin in oncollision and onTrigger Enter and exit
			Target.SetActive (false);
			break;
	 
		case TaskType.AceActionScriptCall:
			if (AceEvents.AceActionCall != null) {

				AceEvents.AceActionCall (ScriptName, null);
			}
			break;
		case TaskType.DestroyThisObject:
			 
			Destroy (gameObject);
			break;
		case TaskType.DestroyTarget:
			AssaginTarget ();
			Destroy (Target);
			break;
		case TaskType.PlaySingleShotSound:
			if (AceEvents.playSingleshotsounds != null)
				AceEvents.playSingleshotsounds (value, null);
			break;
		case TaskType.PlayLoopSound:
			if (AceEvents.playloopsounds != null)
				AceEvents.playloopsounds (value, null);
			break;
		case TaskType.StopLoopSound:
			if (AceEvents.stoploopsounds != null)
				AceEvents.stoploopsounds (value, null);
			break;
		case TaskType.AddCoins:
			AceEvents.AddCoins (value, null);
			break;
		case TaskType.AddScore:
			AceEvents.AddScore (int.Parse (value), null);
			break;
		}
	}

	void AssaginTarget ()
	{
		if (findMethod == TargetFindMedhtod.byTag) {
			 
			Target = GameObject.FindGameObjectWithTag (value);
		} else if (findMethod == TargetFindMedhtod.byName) {
			 
			Target = GameObject.Find (value);
		}

	}

	public	void ProcessAction ()
	{

		if (DelayInAction == 0) {

			if (SelectionActionType == ActionType.UnityEvents) {

				UnityAction.Invoke ();
			} else if (SelectionActionType == ActionType.GameEvents) {
				AceEvent ();
			}

		} else {
			 
			StartCoroutine (AceHelper.waitThenCallback (DelayInAction, () => {
				if (SelectionActionType == ActionType.UnityEvents) {

					UnityAction.Invoke ();
				} else if (SelectionActionType == ActionType.GameEvents) {
					AceEvent ();
				}

			}));
		}



	}

	void OnEnable ()
	{

		AceEvents.AceActionCall += OnAceEvent;

		if (SelectionState == ActionState.OnEnable) {
			ProcessAction ();
		}
	}

	void OnDisable ()
	{
		if (SelectionState == ActionState.OnDisable) {
			ProcessAction ();
		}
		AceEvents.AceActionCall -= OnAceEvent;
		
	}

	void OnAceEvent (System.Object obj, EventArgs args)
	{
		string eventName = obj.ToString ();

		if (this.ScriptName.Contains (eventName) && SelectionState == ActionState.ScriptCall) {
			ProcessAction ();
		}

	}

	void OnTriggerEnter (Collider incoming)
	{
		if (SelectedObject == OtherObject.SpecifiedName && !incoming.name.Contains (otherObjectName))
			return;
		if (SelectedObject == OtherObject.SpecifiedTag && !incoming.tag.Contains (otherObjectName))
			return;
		
		if (findMethod != TargetFindMedhtod.byName || findMethod != TargetFindMedhtod.byTag) { 
			Target = incoming.gameObject;
		}
		if (SelectionState == ActionState.OnTriggerEnter) {
			ProcessAction ();
		}
	}

	void OnTriggerExit (Collider incoming)
	{
		if (SelectedObject == OtherObject.SpecifiedName && !incoming.name.Contains (otherObjectName))
			return;
		if (SelectedObject == OtherObject.SpecifiedTag && !incoming.tag.Contains (otherObjectName))
			return;
		


		if (findMethod != TargetFindMedhtod.byName || findMethod != TargetFindMedhtod.byTag) { 
			Target = incoming.gameObject;
		}
		if (SelectionState == ActionState.OnTriggerExit) {
			ProcessAction ();
		}
	}

	void OnCollisionEnter (Collision incoming)
	{
		if (SelectedObject == OtherObject.SpecifiedName && !incoming.collider.name.Contains (otherObjectName))
			return;
		if (SelectedObject == OtherObject.SpecifiedTag && !incoming.collider.tag.Contains (otherObjectName))
			return;
		
			
		if (findMethod != TargetFindMedhtod.byName || findMethod != TargetFindMedhtod.byTag) { 
			Target = incoming.gameObject;
		}
		if (SelectionState == ActionState.OnCollisionEnter) {
			ProcessAction ();
		}
	}

	void OnCollisionExit (Collision incoming)
	{
		if (SelectedObject == OtherObject.SpecifiedName && !incoming.collider.name.Contains (otherObjectName))
			return;
		if (SelectedObject == OtherObject.SpecifiedTag && !incoming.collider.tag.Contains (otherObjectName))
			return;
		
		if (findMethod != TargetFindMedhtod.byName || findMethod != TargetFindMedhtod.byTag) { 
			Target = incoming.gameObject;
		}
		if (SelectionState == ActionState.OnCollisionExit) {
			ProcessAction ();
		}
	}

	 

	void OnValidate ()
	{
		if (SelectionState == ActionState.ScriptCall && selectedTask == TaskType.AceActionScriptCall) {

			ScriptName = "Dual Script Call Wont Work";
		} 

		 

	}
}
