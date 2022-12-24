using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform startPos;
    [SerializeField] float lineDrawSpeed;
    [SerializeField] float maxSpeed = 0f;

    [SerializeField] Rigidbody rb;

    [SerializeField] LineRenderer line;

    public static bool isPlaying = false;
    public static bool isHooking;

    public List<GameObject> Bridges;
    
    Vector3 grapPoint;
    SpringJoint joint;

    public delegate void Playing();
    public static Playing GameStarted;
    
    public void GameStart()
    {
        if (!isPlaying && transform.position.z < 0)
        {
            rb.AddForce(new Vector3(0, 500, 650));
            Rotate();
            isPlaying = true;
            GameStarted?.Invoke();
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
        }
        if (!isPlaying)
            return;
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    public void PointerDown()
    {
        if (isPlaying && !MenuButton.isPaused)
        {
            StartHooking();
        }    
    }

    public void PointerUp()
    {
        if (isPlaying && !MenuButton.isPaused)
        {
            Rotate();
            StopHooking();
        }
    }

    void LateUpdate()
    {
        DrawLine();
    }

    public void StartHooking()
    {
        GameObject nearest = Bridges.OrderBy(z => Vector3.Distance(new Vector3(transform.position.x, transform.position.y, transform.position.z + 10), z.transform.position)).FirstOrDefault();
        grapPoint = nearest.transform.position;

        joint = gameObject.AddComponent<SpringJoint>();
        joint.autoConfigureConnectedAnchor = false;
        if (PlayerPrefs.GetInt("ChoosedSkin") == 1)
            joint.anchor = new Vector3(0, -0.00015f, 0.003f);
        else
            joint.anchor = new Vector3(0, 0, 0);
        joint.connectedAnchor = grapPoint;

        line.positionCount = 2;
    }

    IEnumerator DestroyHook()
    {
        var jointObject = joint;
        yield return new WaitForSeconds(1.2f);
        Destroy(jointObject);
    }

    public void StopHooking()
    {
        line.positionCount = 0;
        Destroy(GetComponent<SpringJoint>());
        Destroy(joint);
    }

    void Rotate()
    {
        if (transform.rotation.x < 0)
            rb.AddTorque(new Vector3(-100, 0, 0));
        else
            rb.AddTorque(new Vector3(100, 0, 0));
    }

    void DrawLine()
    {
        if (!joint) return;
        line.SetPosition(0, startPos.position);
        line.SetPosition(1, grapPoint);
    }
}