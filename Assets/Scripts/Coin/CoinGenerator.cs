using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject coin;

    Vector3 startPos;
    [SerializeField] List<GameObject> coins = new List<GameObject>();
    int lastCoin = 0;

    delegate void Coin();
    Coin coinDelegate;

    private void Start()
    {
        startPos = player.transform.position;
        //CreateCoins();
        StartCoroutine(GenCoin());
        coinDelegate += UpdateCoinIndex;
        MapGenerator.IsZeroing += Zeroing;
    }

    // void CreateCoins()
    // {
    //     for (int i = 0; i < 72; i++)
    //     {
    //         coins.Add(Instantiate(coin, new Vector3(0, 0, -110), Quaternion.identity));
    //     }
    // }

    void Zeroing()
    {
        startPos = new Vector3(0, 0, 0);
    }

    IEnumerator GenCoin()
    {
        while (true)
        {
            if (player.transform.position.z - startPos.z >= 5*15)
            {
                startPos = player.transform.position;
                for (int i = 1; i <= 6; i++)
                {
                    SpawnCoin(i);
                }
            }
            yield return new WaitForSeconds(.3f);
        }
    }

    void SpawnCoin(int i)
    {
        float y = Random.Range(1f, 70f);
        if (Random.Range(0, 4) != 2)
        {
            for (int j = 1; j <= 6; j++)
            {
                coins[lastCoin].transform.position = new Vector3(0, y, player.transform.position.z + 15f*i+j);
                lastCoin++;
                coinDelegate?.Invoke();
            }
        }
        else
        {
            for (int j = 1; j <= 6; j++)
            {
                coins[lastCoin].transform.position = new Vector3(0, y+j, player.transform.position.z + 15f*i+j);
                lastCoin++;
                coinDelegate?.Invoke();
            }
        }
    }

    void UpdateCoinIndex()
    {
        if (lastCoin >= 72)
        {
            lastCoin = 0;
        }
    }
}