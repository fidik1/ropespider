using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Start()
    {
        PlayerController.GameStarted += Play;
    }

    void Play()
    {
        animator.SetBool("isPlaying", true);
    }

    void OnDestroy()
    {
        PlayerController.GameStarted -= Play;
    }
}
