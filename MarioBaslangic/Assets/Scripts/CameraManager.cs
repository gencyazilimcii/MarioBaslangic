using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float moveSpeed;

    public Vector3 offset;

    public Transform player;

    private void Update()
    {
          transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, moveSpeed*Time.deltaTime);

        // transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, moveSpeed*Time.deltaTime);

       
    }
}
