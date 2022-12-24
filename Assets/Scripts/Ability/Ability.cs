using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Vector3 force;

    public bool onCooldown;
    public float timeCooldown;
    public float timePassed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && PlayerController.isPlaying)
            Jump();
    }

    public void Jump()
    {
        if (!onCooldown)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(force);
            onCooldown = true;
            StartCoroutine(Cooldown());
            timePassed = 0;
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(timeCooldown);
        onCooldown = false;
    }
}
