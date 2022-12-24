using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] Animator tapToPlay;
    [SerializeField] Material[] mat;
    [SerializeField] GameObject[] skins;
    [SerializeField] AudioClip[] clips;
    
    [SerializeField] AudioSource audioSource;
    [SerializeField] Animator playerAnimator;

    [SerializeField] MeshRenderer mesh;

    void Start()
    {
        playerAnimator.SetInteger("isClicked", 0);
        StartCoroutine(Wait());

        Color();
        Skin();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && PlayerController.isPlaying && !MenuButton.isPaused)
        {
            if (PlayerPrefs.GetInt("ChoosedSkin") == 0)
                playerAnimator.SetInteger("isClicked", 2);
            if (PlayerPrefs.GetInt("ChoosedSkin") == 1)
                playerAnimator.SetInteger("isClicked", 4);
            audioSource.clip = clips[Random.Range(0,5)];
            audioSource.Play();
        }
        if (Input.GetMouseButtonUp(0) && PlayerController.isPlaying && !MenuButton.isPaused)
        {
            if (PlayerPrefs.GetInt("ChoosedSkin") == 0)
                playerAnimator.SetInteger("isClicked", 1);
            if (PlayerPrefs.GetInt("ChoosedSkin") == 1)
                playerAnimator.SetInteger("isClicked", 3);
        }
    }

    public void Skin()
    {
        for (int i = 0; i < skins.Length; i++)
        {
            skins[i].SetActive(false);
        }
        skins[PlayerPrefs.GetInt("ChoosedSkin")].SetActive(true);
    }

    public void Color()
    {
        mesh.material = mat[PlayerPrefs.GetInt("ChoosedColor")];
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        tapToPlay.SetBool("TapToPlayOn", true);
    }
}
