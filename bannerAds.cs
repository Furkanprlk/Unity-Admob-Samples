using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class bannerAds : MonoBehaviour
{
    public string bannerID;
    private string testID = "ca-app-pub-3940256099942544/2934735716";
    private BannerView bannerView;
    public bool testMode;
    AdRequest request;
    // Start is called before the first frame update
    void Start()
    {

        //MobileAds.Initialize(initStatus => { });
        // Initialize the Mobile Ads SDK.
        MobileAds.Initialize((initStatus) =>
        {
            Dictionary<string, AdapterStatus> map = initStatus.getAdapterStatusMap();
            foreach (KeyValuePair<string, AdapterStatus> keyValuePair in map)
            {
                string className = keyValuePair.Key;
                AdapterStatus status = keyValuePair.Value;
                switch (status.InitializationState)
                {
                    case AdapterState.NotReady:
                        // The adapter initialization did not complete.
                        MonoBehaviour.print("Adapter: " + className + " not ready.");
                        break;
                    case AdapterState.Ready:
                        // The adapter was successfully initialized.
                        MonoBehaviour.print("Adapter: " + className + " is initialized.");
                        break;
                }
            }
        });

        this.RequestBanner();
    }

    public void RequestBanner()
    {
        Debug.Log("Request Banner");    
        if (this.bannerView != null)
        {
            this.bannerView.Destroy();
        }
        if (!testMode)
        {
            this.bannerView = new BannerView(bannerID, AdSize.SmartBanner, AdPosition.Top);
        }
        else
        {
            this.bannerView = new BannerView(testID, AdSize.SmartBanner, AdPosition.Top);
        }
        
        //AdRequest request = new AdRequest.Builder().Build();
        request = new AdRequest.Builder().Build();
    }

    public void showBanner()
    {
        Debug.Log("Show Banner");
        this.bannerView.LoadAd(request);
    }

    public void destroyBannerAd()
    {
        if (this.bannerView != null)
        {
            this.bannerView.Destroy();
            this.RequestBanner();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
