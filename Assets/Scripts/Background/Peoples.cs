using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peoples : MonoBehaviour
{
    [SerializeField] Animation anim;   

    // [SerializeField] GameObject player;
    // [SerializeField] private float speed;
    // private bool isRunning = false;
    // private float curSpeed;
    // private HookPoint hookPoint;
    // private bool run = false;
    // private Vector3 startPos;
    // private Quaternion startRot;
    // public bool isRight;

    void Start()
    {
        //anim.Play("Happy_Idle");
        //curSpeed = 0;
        //startPos = transform.position;
        //MapGenerator.IsZeroing += Zeroing;
    }

    //void Zeroing()
    //{
        //transform.position = startPos;
        //isRunning = false;
        //anim.Play("Happy_Idle");
    //}

    /*
    void Update()
    {
        try 
        {
            if (GameObject.Find("Hook(Clone)"))
                hookPoint = GameObject.Find("Hook(Clone)").GetComponent<HookPoint>();
                if (hookPoint.Position.z + 1 > transform.position.z && hookPoint.Position.z - 1 < transform.position.z)
                {
                    isRunning = true;
                }
        }
        catch {}
        if (isRunning)
        {
            isRunning = false;
            curSpeed = 0;
            anim.CrossFade("Slow_Run");
            StartCoroutine(Run());
            StartCoroutine(Speed());
        }
    }

    IEnumerator Run()
    {
        while (player.transform.position.z < transform.position.z + 75)
        {
            if (!run)
                run = true;
            yield return new WaitForSeconds(0.01f);
        }
        run = false;
        Zeroing();
    }

    void FixedUpdate()
    {
        if (run)
        {
            if (isRight)
            {
                transform.position = new Vector3(transform.position.x + curSpeed, transform.position.y, transform.position.z);
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - curSpeed, transform.position.y, transform.position.z);
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }
    }

    IEnumerator Speed()
    {
        while (curSpeed <= speed)
        {
            curSpeed += 0.01f;
            yield return new WaitForSeconds(0.05f);
        }
    }
    */
}
