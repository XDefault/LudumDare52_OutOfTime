using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{   
    public static CharacterMove cm;
    private CharacterController controller;
    private AnimationControllerScript animator;
    private Vector3 playerVelocity;
    private const float playerSpeed = 20f;
    private Vector3 movement;
    [SerializeField]
    private Transform model;
    [SerializeField]
    private float rotSpeed;
    private bool canMove;

    void Awake()
    {
        cm = gameObject.GetComponent<CharacterMove>();
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<AnimationControllerScript>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {   
        movement = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));
        if(!canMove){
            movement = Vector3.zero;
        }
        
        if(movement != Vector3.zero){
            Quaternion toRot = Quaternion.LookRotation(movement,Vector3.up);
            model.rotation = Quaternion.RotateTowards(model.rotation, toRot, rotSpeed * Time.deltaTime);
            animator.SetAnimatorParam("Running",true);
        }else{
            animator.SetAnimatorParam("Running",false);
        }
        controller.Move(movement * Time.deltaTime * playerSpeed);
    }

    public void ToggleMovement(){
        canMove = !canMove;
    }
    public void SetCanMovement(bool state){
        canMove = state;
    }
}
