using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdmobInterstitial : MonoBehaviour
{
    InterstitialAd interstitialAd;
    private string interstitialUnitId = "ca-app-pub-9372494740416320/9604088664";
    [SerializeField]
    private GameObject[] canvases;

    void OnEnable()
    {
        interstitialAd = new InterstitialAd(interstitialUnitId);
        interstitialAd.OnAdOpening += HandleOnAdOpened;
        interstitialAd.OnAdClosed += HandleOnAdClosed;
        AdRequest ad = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(ad);

        if (PlayerPrefs.GetInt("CountGame") <= 5)
            PlayerPrefs.SetInt("CountGame", PlayerPrefs.GetInt("CountGame") + 1);
        else if (!PlayerController.isPlaying)
        {
            ShowAd();
        }
    }

    void ShowAd()
    {
        if (interstitialAd.IsLoaded())
        {
            canvases[0].SetActive(false);
            canvases[1].SetActive(false);
            interstitialAd.Show();
        }
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        canvases[0].SetActive(false);
        canvases[1].SetActive(false);
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        canvases[0].SetActive(false);
        canvases[1].SetActive(true);
        PlayerPrefs.SetInt("CountGame", 0);
    }
}
