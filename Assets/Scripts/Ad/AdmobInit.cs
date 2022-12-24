using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobInit : MonoBehaviour
{
    void Awake()
    {
        MobileAds.Initialize(initStatus => {});
    }
}
