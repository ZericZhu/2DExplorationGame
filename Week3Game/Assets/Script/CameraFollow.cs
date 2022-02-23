using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    public float followspeed;
    public Vector3 offset;
    private void LateUpdate()
    {
        Vector3 desiredPosition = Player.transform.position + offset;
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followspeed*Time.deltaTime);
        transform.position = SmoothedPosition;
    }
}
