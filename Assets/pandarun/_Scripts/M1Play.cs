using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class M1Play : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onExitGame() {
		// Application.Quit();
		System.Diagnostics.Process.GetCurrentProcess().Kill();
	}

	public void openPlayStoreUrl(string game) {
		Application.OpenURL("https://play.google.com/store/apps/details?id=" + game );
	}

}
