using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform Camplayer;
    private void Update()
    {
        transform.position = new Vector3(Camplayer.position.x,transform.position.y, transform.position.z);

    }
}
