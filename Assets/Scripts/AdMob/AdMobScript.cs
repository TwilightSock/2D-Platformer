using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdMobScript : MonoBehaviour
{
    public InterstitialAd interstitialAd { get; private set; }

    private void Start()
    {
        MobileAds.Initialize(init => { });
        RequestInterstitial();
    }

 
    private void RequestInterstitial()
    {
        #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
        #elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
        #else
        string adUnitId = "unexpected_platform";
        #endif

        
        interstitialAd = new InterstitialAd(adUnitId);
        
        interstitialAd.OnAdLoaded += HandleOnAdLoaded;
        
        interstitialAd.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        
        interstitialAd.OnAdOpening += HandleOnAdOpening;
        
        interstitialAd.OnAdClosed += HandleOnAdClosed;
        
        AdRequest request = new AdRequest.Builder().Build();
        
        interstitialAd.LoadAd(request);
        
    }

    private void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("HandleAdLoaded event received");
    }

    private void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("HandleFailedToReceiveAd event received with message: "
                            + args.LoadAdError.GetMessage());
    }

    private void HandleOnAdOpening(object sender, EventArgs args)
    {
        Debug.Log("HandleAdOpening event received");
    }

    private void HandleOnAdClosed(object sender, EventArgs args)
    {
        Debug.Log("HandleAdClosed event received");
    }
}
