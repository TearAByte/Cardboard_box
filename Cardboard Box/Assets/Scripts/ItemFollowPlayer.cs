using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFollowPlayer : MonoBehaviour, InteractableInterface{
    private GameObject Player;
    private bool follow = false;
    private float origY;

    [SerializeField]
    private float followSpeed = 5.0f, followRotSpeed = 5.0f;
    [SerializeField]
    private Vector3 followOffset;
    void Start(){
        Player = GameObject.FindGameObjectWithTag("Player");
        origY = Player.transform.position.y;
    }

    // Update is called once per frame
    void Update(){
        if (follow && Player != null){
            var followRot = Quaternion.LookRotation(Player.transform.position - transform.position, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, followRot, followRotSpeed * Time.deltaTime);
            transform.position = Player.transform.position + Player.transform.TransformDirection(followOffset);

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0f, transform.eulerAngles.z);
            transform.position = new Vector3(transform.position.x, origY, transform.position.z);
        }
    }

    public void Interact(){
        if (follow) follow = false;
        else follow = true;
    }
}
