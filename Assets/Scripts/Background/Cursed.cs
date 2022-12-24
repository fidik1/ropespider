using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursed : MonoBehaviour
{
    [SerializeField] LoseGame loseGame;

    [SerializeField] float speed;
    [SerializeField] float speedUp;

    void Start()
    {
        StartCoroutine(SpeedUp());
        MapGenerator.IsZeroing += Zeroing;
        MapGenerator.IsReverseZeroing += ReverseZeroing;
    }

    void Zeroing()
    {
        transform.position -= new Vector3(0, 0, 600);
    }

    void ReverseZeroing()
    {
        transform.position += new Vector3(0, 0, 600);
    }
    
    void FixedUpdate()
    {
        if (PlayerController.isPlaying && !MenuButton.isPaused)
            transform.position += new Vector3(0, 0, speed);
    }

    IEnumerator SpeedUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            if (PlayerController.isPlaying)
                speed += speedUp;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            loseGame.Lose();
        }
    }

    void OnDestroy()
    {
        MapGenerator.IsZeroing -= Zeroing;
        MapGenerator.IsReverseZeroing -= ReverseZeroing;
    }
}
