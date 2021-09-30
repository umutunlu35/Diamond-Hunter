using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    Vector3 distance;
    void Start()
    {
        distance = transform.position - Player.transform.position;
    }


    void LateUpdate()
    {
        transform.position = Player.transform.position + distance;
    }
}
