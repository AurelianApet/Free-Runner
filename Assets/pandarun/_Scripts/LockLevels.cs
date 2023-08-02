using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LockLevels : MonoBehaviour
{

	// Use this for initialization
	public string levelName;
	public Button parentImage;

	void OnEnable ()
	{
		parentImage = transform.parent.transform.GetComponent<Button> ();
		parentImage.interactable = false;
		//Debug.Log (levelName + " value is " + PlayerPrefs.GetInt (levelName.ToLower (), 0));
		//Debug.Log ( "parent:" + parentImage );
		if (PlayerPrefs.GetInt (levelName.ToLower (), 0) != 0) {
			parentImage.interactable = true;
			this.gameObject.SetActive (false);	

		} 
	}



}
