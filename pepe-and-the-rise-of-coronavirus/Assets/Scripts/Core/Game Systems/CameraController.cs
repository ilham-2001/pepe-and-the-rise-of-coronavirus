using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Room Camera
    [Header("Camera Parameter")]
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    // Follow Player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    private float lookAhead;

    void Update()
    {
        // Room Camera
        // transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);

        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), (Time.deltaTime * speed));
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
