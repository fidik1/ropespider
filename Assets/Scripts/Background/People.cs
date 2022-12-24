using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    bool isMirrored = false;
    
    void Start()
    {
        MapGenerator.IsZeroing += Zeroing;
    }

    void Update()
    {   
        if (!isMirrored && !MenuButton.isPaused)
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.02f);
        else if (isMirrored && !MenuButton.isPaused)
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.02f);
    }

    void Zeroing()
    {
        if (transform.position.z > 600)
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 600);
        else
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 300);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Wall")
        {
            transform.Rotate(0, 180, 0);
            isMirrored = !isMirrored;
        }
    }

    void OnDestroy()
    {
        MapGenerator.IsZeroing -= Zeroing;
    }
}
