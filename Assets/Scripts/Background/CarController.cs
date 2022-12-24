using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool isRight;

    Vector3 startPos;

    [SerializeField] GameObject player;

    void Start()
    {
        if (isRight)
            startPos = new Vector3(transform.position.x, transform.position.y, -30);
        else
            startPos = new Vector3(transform.position.x, transform.position.y, 670);
        MapGenerator.IsZeroing += Zeroing;
        MapGenerator.IsReverseZeroing += ReverseZeroing;
    }

    void Zeroing()
    {
        if (transform.position.z > 570)
            transform.position -= new Vector3(0, 0, 600);
        else
            transform.position += new Vector3(0, 0, 300);
    }
    
    void ReverseZeroing()
    {
        transform.position += new Vector3(0, 0, 600);
    }

    void FixedUpdate()
    {
        if (!MenuButton.isPaused)
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Wall")
        {
            transform.position = startPos;
        }
    }

    void OnDestroy()
    {
        MapGenerator.IsZeroing -= Zeroing;
        MapGenerator.IsReverseZeroing -= ReverseZeroing;
    }
}
