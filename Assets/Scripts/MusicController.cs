using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    void Awake()
    {
        QualitySettings.vSyncCount = 1;
        
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        if (!audioSource.isPlaying)
            audioSource.Play();
    }
}
