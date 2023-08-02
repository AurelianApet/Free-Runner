using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelComplete : MonoBehaviour {

	public Text CollectedCoin;
	public Text Score;
	public INGameUI ingameUiScrip;
	public GameObject[] Star;
	string levelName;
	// Use this for initialization
	void Start () {
		
		CollectedCoin.text = ingameUiScrip.numberofCoins.ToString();
		Score.text = INGameUI.scoreCount.ToString ();
		 levelName = UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name;
		int count = PlayerPrefs.GetInt (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name,0);
		for(int i = 0; i< count ;i++){
			Star [i].SetActive (true);
		}
	}
	public void RestartLevel()
	{
		SceneManager.LoadScene (levelName);
		//SceneManager.sceneLoaded 
	}
	public void NextLevel()
	{		
		
	}

}
