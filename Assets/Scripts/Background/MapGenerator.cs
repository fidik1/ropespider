using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerController;

    public delegate void DelegateZeroing();
    public static DelegateZeroing IsZeroing;
    public static DelegateZeroing IsReverseZeroing;

    float cityJump = 600;
    int countZeroing;

    void Update()
    {
        PlayerZeroing();
        PlayerReverse();
    }

    void PlayerZeroing()
    {
        if (player.transform.position.z >= cityJump)
        {
            IsZeroing?.Invoke();
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);

            if (player.GetComponent<SpringJoint>())
            {
                playerController.StopHooking();
                playerController.StartHooking();
            }
            countZeroing++;
        }
    }

    void PlayerReverse()
    {
        if (player.transform.position.z <= -1 && countZeroing > 0)
        {
            IsReverseZeroing?.Invoke();
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 599);

            if (player.GetComponent<SpringJoint>())
            {
                playerController.StopHooking();
                playerController.StartHooking();
            }
        }
    }
}
