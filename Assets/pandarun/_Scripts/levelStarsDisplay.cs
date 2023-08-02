using UnityEngine;
using System.Collections;

public class levelStarsDisplay : MonoBehaviour
{

	// Use this for initialization
	public GameObject[] Star;
	string levelname;
	public Texture[] starTexs;
	private int startCount;

	void Start ()
	{
		
		levelname = transform.parent.name;
		int count = PlayerPrefs.GetInt (levelname.ToLower (), 0);
		// GetComponent<Renderer>().material.mainTexture= starTexs[count];
		for (int i = 0; i < count; i++) {
			if (Star [i] != null)
				Star [i].gameObject.SetActive (true);
		}	
	}
}
