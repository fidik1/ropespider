using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private new AudioSource audio;

    [SerializeField] GameObject particle;

    private void Start()
    {
        MapGenerator.IsZeroing += Zeroing;
        MapGenerator.IsReverseZeroing += ReverseZeroing;
    }

    void Zeroing()
    {
        transform.position = new Vector3(0, transform.position.y, transform.position.z - 600);
    }

    void ReverseZeroing()
    {
        transform.position = new Vector3(0, transform.position.y, transform.position.z + 600);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audio.Play();
            ScoreInGame.coin += 1;
            Instantiate(particle, transform.position, Quaternion.identity);
            transform.position = new Vector3(0, 0, -110);
        }
    }

    void OnDestroy()
    {
        MapGenerator.IsZeroing -= Zeroing;
        MapGenerator.IsReverseZeroing -= ReverseZeroing;
    }
}
