using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStatic : MonoBehaviour{
    [SerializeField]
    private GameObject camPosition;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = camPosition.transform.position;
    }
}
