using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPosScript : MonoBehaviour
{
    public Transform cameraPosition;
    void Update()
    {
        transform.position = cameraPosition.position;
        transform.rotation = cameraPosition.rotation;
    }
}
