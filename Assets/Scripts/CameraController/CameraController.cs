using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform moveTo;

    private void LateUpdate()
    {
        transform.position = new Vector3(moveTo.position.x,transform.position.y,transform.position.z);
    }

}
