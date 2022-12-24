using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreInGame : MonoBehaviour
{
    public static float score;
    public static int coin;
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody rb;

    [SerializeField] Text textScore;
    [SerializeField] Text textCoin;

    void Start()
    {
        score = 0;
        coin = 0;
        StartCoroutine(Score());
    }

    void Update()
    {
        textScore.text = ((int)score).ToString();
        textCoin.text = coin.ToString();
    }

    IEnumerator Score()
    {
        while (true)
        {
            if (rb.velocity.z >= 0)
                score += rb.velocity.magnitude;
            else
                score -= rb.velocity.magnitude;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
