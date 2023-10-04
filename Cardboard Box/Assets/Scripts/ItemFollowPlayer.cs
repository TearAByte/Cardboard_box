using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFollowPlayer : MonoBehaviour{
    // Start is called before the first frame update
    private bool follow = false;
    private GameObject Player;
    private CapsuleCollider playerBounds;

    [SerializeField]
    private float followSpeed = 5.0f, followRotSpeed = 5.0f;
    void Start(){
        playerBounds = Player.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update(){
        if (follow && Player != null){
            Vector3 followPos = new Vector3(Player.transform.position.x, transform.position.y, playerBounds.bounds.min.z);
            var followRot = Quaternion.LookRotation(Player.transform.position - transform.position, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, followRot, followRotSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, followPos, followSpeed * Time.deltaTime);
        }
    }

    void FollowPlayer(GameObject player){
        follow = true;
        Player = player;
    }
}
