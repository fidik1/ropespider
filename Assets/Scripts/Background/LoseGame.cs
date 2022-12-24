using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseGame : MonoBehaviour
{
    [SerializeField] GameObject panelLose;
    [SerializeField] Animator animator;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            Lose();
    }

    public void Lose()
    {
        if (PlayerController.isPlaying)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + ScoreInGame.coin);
            PlayerPrefs.SetInt("LastScore", (int)(ScoreInGame.score));
            if (PlayerPrefs.GetInt("HighScore", 0) < PlayerPrefs.GetInt("LastScore", 0))
                PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("LastScore"));
            PlayerController.isPlaying = false;
            Invoke("Restart", 0.9f);
            animator.SetBool("isPlaying", false);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}