using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using System;
using UnityEngine.Events;
using UnityEngine.UI;

public class rewardsAds : MonoBehaviour
{
    public string rewardsID;
    private string testID= "ca-app-pub-3940256099942544/5224354917";
    private RewardedAd rewardedAd;
    public bool testMode;
    AdRequest request;
    // Start is called before the first frame update
    void Start()
    {
        requestRewardsAds();
    }
    public void requestRewardsAds()
    {
        Debug.LogWarning("Rewards Request Atýldý");
        if (!testMode) { rewardedAd = new RewardedAd(rewardsID);
        }
        else { rewardedAd = new RewardedAd(testID); }
            
        // Called when an ad request has successfully loaded.
        rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);
    }
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        Debug.LogWarning("Rewards Reklamý Hazýr");
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.LogWarning("Rewards istekte problem oldu");
        MonoBehaviour.print("HandleRewardedAdFailedToLoad event received with message: "+ args.LoadAdError);
        //requestRewardsAds();
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        Debug.LogWarning("Rewards Açýldý");
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        Debug.LogWarning("Rewards Gösterirken Hata Oldu");
        MonoBehaviour.print("HandleRewardedAdFailedToShow event received with message: "+ args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {

        Debug.LogWarning("Rewards Kapandý");
        requestRewardsAds();
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        Debug.LogWarning("Rewards Kazandý");
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print("HandleRewardedAdRewarded event received for " + amount.ToString() + " " + type);
    }

    public void showRewardsAds()
    {
        if (rewardedAd.IsLoaded())
        {
            Debug.LogWarning("Rewards OLDU");
            rewardedAd.Show();
        }
        else
        {
            Debug.LogWarning("Rewards OLMADI");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
