using UnityEngine;
using UnityEditor;

public class Ace_GamePlayAndStop : EditorWindow
{


	[MenuItem ("Ace Games/PlayAndStop _F1")]
	static void PlayAndStop ()
	{
		if (EditorApplication.isPlaying == false) {
			EditorApplication.isPlaying = true;
		} else if (EditorApplication.isPlaying == true) {
			EditorApplication.isPlaying = false;
		}
	}

	[MenuItem ("Ace Games/PauseAndresume _F3")]
	static void pauseAndResume ()
	{
		if (EditorApplication.isPaused == false) {
			EditorApplication.isPaused = true;
		} else if (EditorApplication.isPaused == true) {
			EditorApplication.isPaused = false;
		}

	}

	[MenuItem ("Ace Games/DeletePerferences _F7")]
	static void DeletePreference ()
	{
		PlayerPrefs.DeleteAll ();
	}
}
