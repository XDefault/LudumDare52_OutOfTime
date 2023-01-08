using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    private AnimationControllerScript animator;
    private GrabAndDropSeeds gds;

    void Start()
    {
        animator = gameObject.GetComponent<AnimationControllerScript>();
        gds = gameObject.GetComponent<GrabAndDropSeeds>();
    }

    private void OnTriggerStay(Collider other) {
        if(Input.GetButton("Fire1")){
            if(other.tag == "PlantSpot"){
                if(other.GetComponent<PlantSpotController>().CanInteract){
                    animator.SetAnimatorParam("Interacting");
                    if(other.GetComponent<PlantSpotController>().ready){
                        other.GetComponent<PlantSpotController>().HarvestPlant();
                    }else if(gds.GetSeed() != null){
                        other.GetComponent<PlantSpotController>().PlantSeed(gds.GetSeed());
                    }
                    animator.SetAnimatorParam("Interacting");
                    return;
                }
            }
        }
    }
    
}
