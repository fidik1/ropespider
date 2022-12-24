using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    /*
    Vector3 startPos;
    [SerializeField] GameObject grapPoint;

    [SerializeField] GameObject player;
    [SerializeField] Rigidbody rb;
    [SerializeField] PlayerController playerController;

    [SerializeField] Animator animator;

    void Start()
    {
        print(gameObject.name);
        MapGenerator.IsZeroing += Zeroing;
    }

    void Update()
    {
        if (player.transform.position.z - transform.position.z > 120)
        {
            playerController.Bridges.Add(grapPoint);
            Zeroing();
        }
    }

    void Zeroing()
    {
        animator.SetBool("isHooked", false);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            animator.SetBool("isHooked", true);
            if (rb.velocity.magnitude > 0)
                rb.AddTorque(-100,0,0);
            else
                rb.AddTorque(100,0,0);
            rb.velocity = new Vector3(0,0,0);
            GrapPoint();
        }
    }

    void GrapPoint()
    {
        playerController.Bridges.RemoveAt(playerController.Bridges.IndexOf(grapPoint));
    }

    void OnDestroy()
    {
        MapGenerator.IsZeroing -= Zeroing;
    }
    */
}
