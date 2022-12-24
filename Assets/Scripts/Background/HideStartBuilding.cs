using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideStartBuilding : MonoBehaviour
{
    void Start()
    {
        MapGenerator.IsZeroing += DestroyGameObject;
    }

    void DestroyGameObject()
    {
        MapGenerator.IsZeroing -= DestroyGameObject;
        Destroy(gameObject);
    }
    
    void OnDestroy()
    {
        MapGenerator.IsZeroing -= DestroyGameObject;
    }
}
