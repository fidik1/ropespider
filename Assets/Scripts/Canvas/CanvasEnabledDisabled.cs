    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEnabledDisabled : MonoBehaviour
{
    [SerializeField] GameObject[] canvas;
    [SerializeField] GameObject text;

    void Start()
    {
        canvas[0].SetActive(true);
        canvas[1].SetActive(false);

        PlayerController.GameStarted += Play;
    }

    void Play()
    {
        StartCoroutine(HideCanvas());
        text.GetComponent<Animator>().SetBool("isPlaying", true);
        canvas[1].SetActive(true);
    }

    IEnumerator HideCanvas()
    {
        yield return new WaitForSeconds(1);
        canvas[0].SetActive(false);
    }

    void OnDestroy()
    {
        PlayerController.GameStarted -= Play;
    }
}
