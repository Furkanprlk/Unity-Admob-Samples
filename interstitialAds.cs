using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class interstitialAds : MonoBehaviour
{
    public string interstitialID;
    private string testID= "ca-app-pub-3940256099942544/4411468910";
    private InterstitialAd interstitial;
    public bool testMode;
    AdRequest request;
    // Start is called before the first frame update
    void Start()
    {
        RequestInterstitial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RequestInterstitial()
    {
        if (interstitial != null)
        {
            interstitial.Destroy();
        }
        if (!testMode)
        {
            interstitial = new InterstitialAd(interstitialID);
        }
        else
        {
            interstitial = new InterstitialAd(testID);
        }
        
        interstitial.OnAdClosed += HandleOnAdClosed;
        request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);
    }

    public bool showInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            Debug.Log("Interstitial show is now");
            interstitial.Show();
            return true;
        }
        else {
            Debug.Log("Interstitial is not loaded");
            if (interstitial == null)
            {
                RequestInterstitial();
            }
            
            return false; 
        }
        
    }
    public void forceShowInterstitial()
    {
        interstitial.Show();
    }
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        RequestInterstitial();
    }


}
