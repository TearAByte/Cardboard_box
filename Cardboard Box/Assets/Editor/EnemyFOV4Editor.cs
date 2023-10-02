using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (EnemyFOV))]
public class EnemyFOV4Editor : Editor
{
    private void OnSceneGUI()
    {
        EnemyFOV fov = (EnemyFOV)target;
        //draws view radius for editor
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius);

        //draws view angle for editor (pac-man mouth)
        Handles.color = Color.yellow;
        Vector3 viewAngleA = fov.DirFromAngle(-fov.viewAngle / 2,false);
        Vector3 viewAngleB = fov.DirFromAngle(fov.viewAngle / 2,false);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.viewRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.viewRadius);
        Handles.color = Color.red;
        Vector3 viewCenterAngleA = fov.DirFromAngle(-fov.viewCenterAngle / 2, false);
        Vector3 viewCenterAngleB = fov.DirFromAngle(fov.viewCenterAngle / 2, false);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewCenterAngleA * fov.viewRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewCenterAngleB * fov.viewRadius);
    }
}
