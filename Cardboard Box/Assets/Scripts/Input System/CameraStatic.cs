using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraStatic : MonoBehaviour{
    [SerializeField]
    private GameObject camPosition, halfwayPoint;
    [SerializeField]
    private List<Collider> currTransparent;
    private Collider[] wallHits;

    [SerializeField]
    private float alphaValue = 0.5f;

    private void Start(){
        currTransparent = new List<Collider>();
    }

    // Update is called once per frame
    private void Update(){
        wallHits = Physics.OverlapBox(halfwayPoint.transform.position, new Vector3(1, 4, 3));
        wallHits.ToList<Collider>();

        foreach(var wall in wallHits){
            if(wall.gameObject.tag == "Wall"){
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
