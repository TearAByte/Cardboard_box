using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStatic : MonoBehaviour{
    [SerializeField]
    private GameObject camPosition, halfwayPoint;

    // Update is called once per frame
    private void Update(){
        Physics.OverlapBox(halfwayPoint.transform.position, new Vector3(1, 8, 6));
    }
    void LateUpdate(){
        transform.position = camPosition.transform.position;
    }

    void OnDrawGizmosSelected(){
        // Draw a semitransparent red cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(halfwayPoint.transform.position, new Vector3(1, 8, 6));
    }
}
