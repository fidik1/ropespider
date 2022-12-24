using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdmobRewarded : MonoBehaviour
{
    string rewardedUnitId = "ca-app-pub-9372494740416320/1579356464";
    RewardedAd rewardedAd;

    [SerializeField]
    private GameObject[] canvases;

    void OnEnable()
    {
        rewardedAd = new RewardedAd(rewardedUnitId);
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        AdRequest ad = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(ad);
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
    }

    void HandleUserEarnedReward(object sender, Reward e)
    {
        PlayerPrefs.SetInt("Money", Money.balance + 100);
        //PlayerPrefs.SetInt("LookedAds" + PlayerPrefs.GetInt("LastNum"), PlayerPrefs.GetInt("LookedAds"+PlayerPrefs.GetInt("LastNum"))+1);
    }

    public void ShowAd()
    {
        if (rewardedAd.IsLoaded())
        {
            canvases[0].SetActive(false);
            canvases[1].SetActive(false);
            rewardedAd.Show();
        }
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        canvases[0].SetActive(false);
        canvases[1].SetActive(true);
    }
}
