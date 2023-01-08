using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpotController : MonoBehaviour
{   
    private SeedScriptableObject currentSeed;
    private float timer = 0f;
    private const float completionTime = 5f;
    public bool ready;
    public bool CanInteract;
    private GameObject objSpawned;

    void Start()
    {
        ResetPlant();
    }

    private void ResetPlant(){
        objSpawned = new GameObject();
        currentSeed = null;
        timer = 0;
        ready = false;
        CanInteract = true;
    }

    public void PlantSeed(SeedScriptableObject seed){
        if(currentSeed == null) currentSeed = seed;
        CanInteract = false;
    }

    public void DestroyPlant(){
        ResetPlant();
    }

    public void HarvestPlant(){
        if(ready){
            Destroy(objSpawned);
            GameObject obj = Instantiate(currentSeed.Prefab,transform.position,Quaternion.identity);
            objSpawned = obj;
            CanInteract = false;
            if(currentSeed.itemID == 1){
                TurretManager.manager.AddTurret(obj);
            }
        }
    }

    void Update()
    {   
        if(objSpawned == null){
            ResetPlant();
        }
        if(currentSeed!=null && ready == false){
            timer+= Time.deltaTime;
        }

        if(ready == false && timer >= completionTime){
            ready = true;
            CanInteract = true;
        }
    }
}
