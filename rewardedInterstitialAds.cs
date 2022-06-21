using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class rewardedInterstitialAds : MonoBehaviour
{
    public string rewardedInsterstitialID;
    private string testID= "ca-app-pub-3940256099942544/5354046379";
    private RewardedInterstitialAd rewardedInterstitialAd;
    AdRequest request;
    public bool testMode;
    // Start is called before the first frame update
    void Start()
    {
        RequestInterstitial();

    }
    public void RequestInterstitial()
    {
        request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        if (!testMode)
        {
            RewardedInterstitialAd.LoadAd(rewardedInsterstitialID, request, adLoadCallback);
        }
        else
        {
            RewardedInterstitialAd.LoadAd(testID, request, adLoadCallback);
        }
        
    }

    private void adLoadCallback(RewardedInterstitialAd ad, AdFailedToLoadEventArgs error)
    {
        if (error == null)
        {
            rewardedInterstitialAd = ad;
            rewardedInterstitialAd.OnAdFailedToPresentFullScreenContent += HandleAdFailedToPresent;
            rewardedInterstitialAd.OnAdDidPresentFullScreenContent += HandleAdDidPresent;
            rewardedInterstitialAd.OnAdDidDismissFullScreenContent += HandleAdDidDismiss;
            rewardedInterstitialAd.OnPaidEvent += HandlePaidEvent;
        }
    }

    public void ShowRewardedInterstitialAd()
    {
        if (rewardedInterstitialAd != null)
        {
            rewardedInterstitialAd.Show(userEarnedRewardCallback);
            Debug.LogWarning("REKLAM GOSTERILIYOR");
        }
    }

    private void userEarnedRewardCallback(Reward reward)
    {
        Debug.LogWarning("ODUL VERILDI");
        // TODO: Reward the user.
    }

    private void HandleAdFailedToPresent(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print("Rewarded interstitial ad has failed to present.");
        Debug.LogWarning("ODULLU GECIS REKLAMI GOSTERILMEDI");
    }

    private void HandleAdDidPresent(object sender, EventArgs args)
    {
        MonoBehaviour.print("Rewarded interstitial ad has presented.");
        Debug.LogWarning("ODULLU GECIS REKLAMI SUNULDU");
    }

    private void HandleAdDidDismiss(object sender, EventArgs args)
    {
        MonoBehaviour.print("Rewarded interstitial ad has dismissed presentation.");
        Debug.LogWarning("ODULLU GECIS REKLAMI REDDEDILDI");
    }

    private void HandlePaidEvent(object sender, AdValueEventArgs args)
    {
        MonoBehaviour.print("Rewarded interstitial ad has received a paid event.");
        Debug.LogWarning("ODULLU GECIS REKLAMI ODUL KAZANILDI");
        RequestInterstitial();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
