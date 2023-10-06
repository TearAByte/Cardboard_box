using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdrenalineItem : MonoBehaviour, InteractableInterface{
    private GameObject Player;
    private PlayerMovement PlayerMove;
    private MeshRenderer AdrenMat;
    private CapsuleCollider AdrenColl;
    
    [SerializeField]
    private float speedBuff = 2f, duration = 10f;
    private bool used = false;
    // Start is called before the first frame update
    void Start(){
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerMove = Player.GetComponent<PlayerMovement>();
        AdrenMat = GetComponent<MeshRenderer>();
        AdrenColl = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update(){
        if (!used) return;
        if(duration <= 0){
            PlayerMove.speed -= speedBuff;
            Destroy(gameObject);
        }
        duration -= Time.deltaTime;
    }

    public void Interact(){
        if (used) return;
        PlayerMove.speed += speedBuff;
        used = true;
        AdrenColl.enabled = false;
        AdrenMat.enabled = false;
    }
}
