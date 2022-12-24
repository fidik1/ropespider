using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobBanner : MonoBehaviour
{
    string bannerUnitId = "ca-app-pub-9372494740416320/6598080554";
    
    void OnEnable()
    {
        BannerView ad = new BannerView(bannerUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest adRequest = new AdRequest.Builder().Build();
    }
}
