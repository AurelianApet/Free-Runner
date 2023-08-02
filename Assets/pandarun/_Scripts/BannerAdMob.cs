using System;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class BannerAdMob : MonoBehaviour {

	private BannerView bannerView;

	// Use this for initialization
	void Start () {
		RequestBanner ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void RequestBanner() {
		#if UNITY_ANDROID
			string adUnitId = "ca-app-pub-2618768483997347/9699139716";
		#elif UNITY_IPHONE
			string adUnitId = "ca-app-pub-2618768483997347/9760445314";
		#else
			string adUnitId = "ca-app-pub-2618768483997347/9699139716";
		#endif

		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		bannerView.LoadAd(request);
	}

	#region Banner callback handlers
	public void HandleAdLoaded(object sender, EventArgs args) {
	print("HandleAdLoaded event received.");
	}

	public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args) {
	print("HandleFailedToReceiveAd event received with message: " + args.Message);
	}

	public void HandleAdOpened(object sender, EventArgs args) {
	print("HandleAdOpened event received");
	}

	void HandleAdClosing(object sender, EventArgs args) {
	print("HandleAdClosing event received");
	}

	public void HandleAdClosed(object sender, EventArgs args) {
	print("HandleAdClosed event received");
	}

	public void HandleAdLeftApplication(object sender, EventArgs args) {
	print("HandleAdLeftApplication event received");
	}
	#endregion

}
