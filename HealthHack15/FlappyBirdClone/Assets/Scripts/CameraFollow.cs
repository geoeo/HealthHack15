using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;

    void LateUpdate()
    {
        transform.position = new Vector3(Player.position.x + 0.5f, 0, transform.position.z);
    }
}
