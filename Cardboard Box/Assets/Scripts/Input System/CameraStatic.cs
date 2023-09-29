using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStatic : MonoBehaviour{
    [SerializeField]
    private GameObject camPosition, halfwayPoint;
    [SerializeField]
    private List<Collider> currTransparent;
    private Collider[] wallHits;

    [SerializeField]
    private float alphaValue = 0.5f;
    private int wallNum = 0;

    private void Start(){
        currTransparent = new List<Collider>();
    }

    // Update is called once per frame
    private void Update(){
        wallHits = Physics.OverlapBox(halfwayPoint.transform.position, new Vector3(1, 4, 3));

        foreach(var wall in wallHits){
            if(wall.gameObject.tag == "Wall"){
                if (!currTransparent.Contains(wall)){
                    Debug.Log("wall hit");
                    SemiTransparent(wall.gameObject.GetComponent<Renderer>().material);
                    currTransparent.Add(wall);
                }
                
                wallNum++;
            }
        }
        
        if (wallNum == 0 && currTransparent.Count > 0){
            Debug.Log("Capacity " + currTransparent.Count);
            foreach(var wall in currTransparent){
                Debug.Log("wall reverted");
                Opaque(wall.gameObject.GetComponent<Renderer>().material);
            }
            currTransparent.Clear();
        }

        wallNum = 0;
    }
    void LateUpdate(){
        transform.position = camPosition.transform.position;
    }

    void OnDrawGizmosSelected(){
        // Draw a semitransparent red cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(halfwayPoint.transform.position, new Vector3(1, 8, 6));
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
