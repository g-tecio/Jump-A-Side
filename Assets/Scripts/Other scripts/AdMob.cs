using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMob : MonoBehaviour
{

    public static BannerView bannerView;
    // Start is called before the first frame update
    void Start()
    {
        //string appId = "ca-app-pub-5267056163100832~7826014748"; //iOS
        string appId = "ca-app-pub-5267056163100832~6327679363"; //Android
        MobileAds.Initialize(appId);
        RequestBanner();
    }

    public static void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-5267056163100832/1015642937";
#elif UNITY_IPHONE
      string adUnitId = "ca-app-pub-5267056163100832/8372809658";
#else
      string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder()
        //.AddTestDevice("E3A02A722AB404CB395263041F75D461")
        .Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    void Update()
    {

    }
}
