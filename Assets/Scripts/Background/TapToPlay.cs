using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToPlay : MonoBehaviour
{
    public static Animator anim;
    
    void OnEnable()
    {
        anim = GetComponent<Animator>();
        anim.Play("TapToPlay");
    }
}