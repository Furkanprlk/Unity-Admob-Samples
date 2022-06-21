using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adMobManager : MonoBehaviour
{
    public static adMobManager Instance;
    public void Awake()
    {
        Instance = this;
    }
    void Start()
    {
    }
    void Update()
    {
        
    }
    public void showBanner()
    {
        gameObject.GetComponent<bannerAds>().showBanner();
    }
    public void requestBanner()
    {
        gameObject.GetComponent<bannerAds>().RequestBanner();
    }
    public void requestInterstitial()
    {
        gameObject.GetComponent<interstitialAds>().RequestInterstitial();
    }
    public void showgecis()
    {
        gameObject.GetComponent<interstitialAds>().showInterstitial();
    }
    public void foreceShowGecis()
    {
        gameObject.GetComponent<interstitialAds>().forceShowInterstitial();
    }
    public void requestRewardsAds()
    {
        gameObject.GetComponent<rewardsAds>().requestRewardsAds();
    }
    public void showRewardsAds()
    {
        gameObject.GetComponent<rewardsAds>().showRewardsAds();
    }
    public void earnRewardsAds()
    {

    }
    public void requestRewardsInterstitialAds()
    {
        gameObject.GetComponent<rewardedInterstitialAds>().RequestInterstitial();
    }
    public void showRewardsInterstitialAds()
    {
        gameObject.GetComponent<rewardedInterstitialAds>().ShowRewardedInterstitialAd();
    }
    public void earnRewardsInterstitialAds()
    {

    }
}
