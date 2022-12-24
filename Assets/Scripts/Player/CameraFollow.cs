using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject Target;
    [SerializeField] Vector3 offset;
    [SerializeField] Animator animator;

    void Start()
    {
        PlayerController.GameStarted += GameStarted;
    }

    void GameStarted()
    {
        transform.position = new Vector3(12.15f, 50.25f, -40);
        transform.rotation = Quaternion.Euler(13.5f, -119.3f, 0);
        animator.enabled = false;
    }

    void Update()
    {
        if (PlayerController.isPlaying)
        {
            transform.position = Target.transform.position + offset;
        }
    }

    void OnDestroy()
    {
        PlayerController.GameStarted -= GameStarted;
    }
}