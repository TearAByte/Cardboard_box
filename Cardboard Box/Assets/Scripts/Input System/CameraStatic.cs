using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraStatic : MonoBehaviour{
    [SerializeField]
    private GameObject camPosition, halfwayPoint;
    private List<Collider> currTransparent;
    private Collider[] wallHits;

    //for camera hitting map boundary
    [SerializeField]
    private MeshCollider mapBounds;
    [SerializeField]
    private Camera mainCam;

    private float xMin, xMax, zMin, zMax, camX, camZ;
    private float camOrthoSize, camRatio;

    [SerializeField]
    private float alphaValue = 0.5f;

    private void Start(){
        currTransparent = new List<Collider>();

        xMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.x;
        zMin = mapBounds.bounds.min.z;
        zMax = mapBounds.bounds.max.z;

        camOrthoSize = mainCam.orthographicSize;
        camRatio = (xMax + camOrthoSize) / 2f;
    }

    // Update is called once per frame
    private void Update(){
        wallHits = Physics.OverlapBox(halfwayPoint.transform.position, new Vector3(0.5f, 4, 3));
        wallHits.ToList<Collider>();

        foreach(var wall in wallHits){
            if(wall.gameObject.tag == "Wall" || wall.gameObject.tag == "Border"){
                if (!currTransparent.Contains(wall)){
                    SemiTransparent(wall.gameObject.GetComponent<Renderer>().material);
                    currTransparent.Add(wall);
                }
            }
        }

        for(int i = 0; i < currTransparent.Count; i++){
            if (!wallHits.Contains(currTransparent[i])){
                Opaque(currTransparent[i].gameObject.GetComponent<Renderer>().material);
                currTransparent.Remove(currTransparent[i]);
            }
        }
    }

    private void LateUpdate()
    {
        camX = Mathf.Clamp(camPosition.transform.position.x, xMin + camOrthoSize, xMax - camOrthoSize);
        camZ = Mathf.Clamp(camPosition.transform.position.z, zMin + camOrthoSize, zMax - camOrthoSize);
        transform.position = new Vector3(camX, camPosition.transform.position.y, camZ);
    }

    void OnDrawGizmosSelected(){
        // Draw a semitransparent red cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(halfwayPoint.transform.position, new Vector3(0.5f, 8, 6));
    }

    void SemiTransparent(Material mat){
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaValue);
        mat.SetColor("_Color", newColor);
    }

    void Opaque(Material mat){
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, 1f);
        mat.SetColor("_Color", newColor);
    }
}
