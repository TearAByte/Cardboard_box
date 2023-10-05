using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour{
    // Start is called before the first frame update
    private Collider[] hits;
    private PlayerInput playerInput;

    [SerializeField]
    private float interactRange = 2f;

    private void Awake(){
        playerInput = new PlayerInput();
    }

    private void OnEnable(){
        playerInput.TopDown.Enable();
    }

    private void OnDisable(){
        playerInput.TopDown.Disable();
    }

    // Update is called once per frame
    void Update(){
        hits = Physics.OverlapSphere(transform.position, interactRange);

        foreach(var hit in hits){
            if(hit.gameObject.tag == "Item" && playerInput.TopDown.Interact.WasPerformedThisFrame()){
                if(hit.gameObject.TryGetComponent<InteractableInterface>(out InteractableInterface item)){
                    item.Interact();
                }
            }
        }
    }

    void OnDrawGizmosSelected(){
        // Draw a semitransparent red cube at the transforms position
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, interactRange);
    }
}
