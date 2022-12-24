using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public static int balance;

    private void Update()
    {
        balance = PlayerPrefs.GetInt("Money", 0);
    }

    private void OnApplicationQuit()
    {
        //PlayerPrefs.SetInt("Money", balance);
    }

    private void OnApplicationPause()
    {
       //PlayerPrefs.SetInt("Money", balance);
    }
}
