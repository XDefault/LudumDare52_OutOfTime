using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{   
    public GameObject BulletPrefab;
    public Transform turretHead;
    private Transform target;
    private int turretLife;
    public float range;
    private float cdShot;

    [SerializeField]private AudioClip soundShot;

    void Start()
    {   
        turretLife = 100;
        FindEnemy();
    }


    void Update()
    {   
        if(turretLife <= 0){
            TurretManager.manager.turrets.Remove(gameObject);
            Destroy(gameObject);
        }

        if(target != null){
            Vector3 dir = target.position - transform.position;
            dir.y = 0;
            Quaternion toRot = Quaternion.LookRotation(dir,Vector3.up);
            turretHead.rotation = Quaternion.RotateTowards(turretHead.rotation, toRot, 700 * Time.deltaTime);
        }
        FindEnemy();

        if(target != null){
            float ds = Vector3.Distance(target.position, transform.position);
            if(ds < range && cdShot <= 0 && TurretManager.manager.GetAmmo()>0){
                GameObject obj = Instantiate(BulletPrefab,transform.position,turretHead.rotation);
                obj.GetComponent<BulletScript>().target = target;
                cdShot = 3;
                TurretManager.manager.UseAmmo();
                AudioManager.manager.Play(soundShot);
            }
        }
        cdShot -= Time.deltaTime;
    }


    void FindEnemy(){
        GameObject closest = null;
        float BestDist = 9999999;
        for(int i =0; i < EnemyManager.manager.enemys.Count;i++){
            float dse = Vector3.Distance(transform.position,EnemyManager.manager.enemys[i].transform.position);
            if(dse < BestDist){
                BestDist = dse;
                closest = EnemyManager.manager.enemys[i];
            }
        }

        if(closest!=null) target = closest.transform;
    }

    public void GetHit(int amount){
        turretLife-= amount;
        if(turretLife< 0) turretLife = 0;
    }
}
