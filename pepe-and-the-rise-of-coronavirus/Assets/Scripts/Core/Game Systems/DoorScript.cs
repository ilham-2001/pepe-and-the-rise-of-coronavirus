using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private Transform prevoiusRoom;
    [SerializeField] private Transform nextRoom;

    [SerializeField] private CameraController cam;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (col.transform.position.x < transform.position.x)
            {
                cam.MoveToNewRoom(nextRoom);
            }

            else
            {
                cam.MoveToNewRoom(prevoiusRoom);
            }
        }
    }
}
