using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0.5f, 0, 0);
    }
}
