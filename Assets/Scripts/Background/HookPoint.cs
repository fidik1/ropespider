using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookPoint : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y+0.01f, transform.position.z);
        Destroy(gameObject, 1f);
    }

    void OnTriggerStay(Collider col)
    {
        print(col.gameObject.tag);
    }

    public Vector3 Position
    {
        get { return transform.position; }
    }
}
