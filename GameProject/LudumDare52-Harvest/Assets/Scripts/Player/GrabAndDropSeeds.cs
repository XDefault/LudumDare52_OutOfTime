using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndDropSeeds : MonoBehaviour
{
    private SeedScriptableObject currentSeed;
    private AnimationControllerScript animator;
    [SerializeField]private AudioClip soundItem;
    [SerializeField]private AudioClip soundSeed;
    void Start()
    {
        animator = gameObject.GetComponent<AnimationControllerScript>();
    }

    private void OnTriggerEnter(Collider other) {
       
       /* if(other.tag == "Seed"){
            currentSeed = other.GetComponent<Seed>().seed;
            Debug.Log(other.tag + ":" + other.GetComponent<Seed>().seed.itemID);
        }*/

        switch(other.tag){
            case "Seed":
                currentSeed = other.GetComponent<Seed>().seed;
                AudioManager.manager.Play(soundSeed);
            break;

            case "Ammo":
                TurretManager.manager.ReloadAmmo();
                Destroy(other.gameObject);
                AudioManager.manager.Play(soundItem);
            break;

            case "Pills":
                Sanity.manager.Restore();
                Destroy(other.gameObject);
                AudioManager.manager.Play(soundItem);
            break;
        }

        
    }

    public SeedScriptableObject GetSeed(){
        return currentSeed;
    }
    
}
