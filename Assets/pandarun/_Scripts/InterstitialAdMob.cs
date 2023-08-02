using System;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class InterstitialAdMob : MonoBehaviour {

	private InterstitialAd interstitial;
	private float deltaTime = 0.0f;

	// Use this for initialization
	void Start () {
		RequestInterstitial ();
	}

	// Update is called once per frame
	void Update () {
		// Calculate simple moving average for time to render screen. 0.1 factor used as smoothing
		// value.
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
	}

	void OnDestroy() {    
		ShowInterstitial();
	}

	private void RequestInterstitial() {
		#if UNITY_ANDROID
			string adUnitId = "ca-app-pub-2618768483997347/3652606114";
		#elif UNITY_IPHONE
			string adUnitId = "ca-app-pub-2618768483997347/5051044111";
		#else
			string adUnitId = "ca-app-pub-2618768483997347/3652606114";
		#endif

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();

		// Create an interstitial.
		interstitial = new InterstitialAd(adUnitId);
		// Register for ad events.
		interstitial.OnAdLoaded += HandleInterstitialLoaded;
		interstitial.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
		interstitial.OnAdOpening += HandleInterstitialOpened;
		interstitial.OnAdClosed += HandleInterstitialClosed;
		interstitial.OnAdLeavingApplication += HandleInterstitialLeftApplication;
		// Load an interstitial ad.
		interstitial.LoadAd(request);
	}


	private void ShowInterstitial() {
		if (interstitial.IsLoaded()) {
			interstitial.Show();
		} else {
			print("Interstitial is not ready yet.");
		}
	}

	public void HandleInterstitialLoaded(object sender, EventArgs args) {
		print("HandleInterstitialLoaded event received.");
	}

	public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args) {
		print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
	}

	public void HandleInterstitialOpened(object sender, EventArgs args) {
		print("HandleInterstitialOpened event received");
	}

	void HandleInterstitialClosing(object sender, EventArgs args) {
		print("HandleInterstitialClosing event received");
	}

	public void HandleInterstitialClosed(object sender, EventArgs args) {
		print("HandleInterstitialClosed event received");
	}

	public void HandleInterstitialLeftApplication(object sender, EventArgs args) {
		print("HandleInterstitialLeftApplication event received");
	}

}
