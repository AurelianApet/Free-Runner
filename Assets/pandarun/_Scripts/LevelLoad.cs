using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoad : MonoBehaviour
{

	public void Level (string LevelName)
	{
		Time.timeScale = 1;
	 
		SceneManager.LoadScene (LevelName);
		 

	}

	 
}
