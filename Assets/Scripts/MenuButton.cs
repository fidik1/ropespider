using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] GameObject[] panel;
    [SerializeField] Text[] texts;
    [SerializeField] int[] price;
    int lastColor;
    int lastHavedColor;
    [SerializeField] Animations player;
    [SerializeField] Transform playerTransform;
    [SerializeField] GameObject[] cameras;
    public static bool isPaused;

    private void Start()
    {
        lastHavedColor = PlayerPrefs.GetInt("ChoosedColor");
        PlayerPrefs.SetInt("Skin0", 1);
    }

    public void Shop(int num)
    {
        if (panel[num].activeInHierarchy)
        {
            panel[num].SetActive(false);
            StopCoroutine(TextCoroutine());
        }
        else
        {
            panel[num].SetActive(true);
            Text();
            StartCoroutine(TextCoroutine());
        }
    }

    public void SwitchCamera()
    {
        if (!cameras[1].activeInHierarchy)
        {
            cameras[1].SetActive(true);
            cameras[2].SetActive(true);
            cameras[3].SetActive(false);
            RenderSettings.fog = false;
            player.GetComponent<Rigidbody>().isKinematic = true;
            player.transform.position = new Vector3(540, 998, 95);
            player.transform.rotation = Quaternion.Euler(0, 180, 0);
            player.transform.localScale = new Vector3(1200, 1200, 1200);
        }
        else
        {
            cameras[1].SetActive(false);
            cameras[2].SetActive(false);
            cameras[3].SetActive(true);
            RenderSettings.fog = true;
            player.GetComponent<Rigidbody>().isKinematic = false;
            player.transform.position = new Vector3(-0.094f, 48.8f, -35.89f);
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
            player.transform.localScale = new Vector3(150, 150, 150);
            
            if (PlayerPrefs.GetInt("Color" + lastColor) == 0)
            {
                PlayerPrefs.SetInt("ChoosedColor", lastHavedColor);
                player.Color();
            }
        }
    }

    void Text()
    {
        texts[0].text = PlayerPrefs.GetInt("LookedAds"+1) + "/5 ADS";
    }

    public void BuyColor(int num)
    {
        if (PlayerPrefs.GetInt("Color" + num, 0) == 1)
        {
            PlayerPrefs.SetInt("ChoosedColor", num);
            panel[3].GetComponentInChildren<Text>().text = "ACTIVE";
            player.Color();
            lastHavedColor = num;
        }
        else
        {
            lastColor = num;
            PlayerPrefs.SetInt("ChoosedColor", lastColor);
            player.Color();
            panel[3].GetComponentInChildren<Text>().text = "BUY FOR " + price[num] + " COINS";
        }
    }

    public void Buy()
    {
        if (Money.balance >= price[lastColor] && PlayerPrefs.GetInt("Color" + lastColor, 0) == 0)
        {
            PlayerPrefs.SetInt("Money", Money.balance - price[lastColor]);
            PlayerPrefs.SetInt("Color" + lastColor, 1);
            PlayerPrefs.SetInt("ChoosedColor", lastColor);
            panel[3].GetComponentInChildren<Text>().text = "ACTIVE";
            player.Color();
            lastHavedColor = lastColor;
        }
    }

    public void BuySkinDonate(int num)
    {
        if (PlayerPrefs.GetInt("LookedAds" + num, 0) >= 5)
        {
            if (PlayerPrefs.GetInt("Skin" + num, 0) == 0)
            {
                PlayerPrefs.SetInt("Skin" + num, 1);
                PlayerPrefs.SetInt("ChoosedSkin", num);
            }
            if (PlayerPrefs.GetInt("Skin" + num, 0) == 1)
                PlayerPrefs.SetInt("ChoosedSkin", num);
            player.Skin();
        }
        else
        {
            PlayerPrefs.SetInt("LastNum", num);
            Camera.main.GetComponent<AdmobRewarded>().ShowAd();
        }
    }

    public void SelectSkin(int num)
    {
        print(PlayerPrefs.GetInt("Skin" + num));
        if (PlayerPrefs.GetInt("Skin" + num) == 1)
            PlayerPrefs.SetInt("ChoosedSkin", num);
        player.Skin();
    }

    IEnumerator TextCoroutine()
    {
        while (texts[0].gameObject.activeInHierarchy)
        {
            Text();
            yield return new WaitForSeconds(0.3f);
        }
    }

    public void Pause()
    {
        if (panel[2].activeInHierarchy)
        {
            panel[2].SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
        else if (!panel[2].activeInHierarchy && PlayerController.isPlaying)
        {
            panel[2].SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
    }
}
