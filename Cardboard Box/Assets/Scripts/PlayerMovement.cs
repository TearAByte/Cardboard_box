using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed, rotationSpeed;
    private PlayerInput playerInput;
    private CharacterController PlayerControl;

    private void OnEnable()
    {
        playerInput.TopDown.Enable();
    }

    private void OnDisable()
    {
        playerInput.TopDown.Disable();
    }
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        PlayerControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update(){
        PlayerMove(playerInput.TopDown.Movement.ReadValue<Vector2>());
    }

    public void PlayerMove (Vector2 keyInput2D){
        Vector3 keyInput3D = new Vector3(keyInput2D.x, 0f, keyInput2D.y);
        PlayerControl.Move(keyInput3D * speed * Time.deltaTime);

        if(keyInput3D != Vector3.zero){
            Quaternion toRotate = Quaternion.LookRotation(keyInput3D, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);
        }
    }
}
