using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public List<GameObject> turrets;
    public static TurretManager manager;

    private int ammo = 100;

    void Start()
    {
        turrets = new List<GameObject>();
        manager = this;
    }

    public void AddTurret(GameObject obj){
        turrets.Add(obj);
    }

    public void UseAmmo(){
        ammo--;
    }
    public void ReloadAmmo(){
        ammo = 100;
    }

    public int GetAmmo(){
        return ammo;
    }
}
