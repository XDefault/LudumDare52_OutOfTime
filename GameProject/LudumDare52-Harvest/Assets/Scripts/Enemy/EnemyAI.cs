using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{   
    int Life;
    UnityEngine.AI.NavMeshAgent agent;
    AnimationControllerScript animator;
    Transform target;

    public int atkAmount = 25;

    void Start()
    {
        Life = 100;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<AnimationControllerScript>();
        target = null;
    }

    void Update()
    {   
        if(Life <=0){
            EnemyManager.manager.RemoveEnemy(gameObject);
            Destroy(gameObject);
        }

        if(target == null){
            FindTarget();
            return;
        }

        if(Vector3.Distance(transform.position,target.position) < 3){
            animator.SetAnimatorParam("Attack",true);
        }else{
            animator.SetAnimatorParam("Attack",false);
        }
        agent.SetDestination(target.position);
    }

    public void SetTarget(Transform newTarget){
        target = newTarget;
    }

    public void Hit(){
        if(Vector3.Distance(target.transform.position,transform.position) > 3){
            return;
        }
        if(target.gameObject.GetComponent<TurretScript>()){
            target.gameObject.GetComponent<TurretScript>().GetHit(atkAmount);
            return;
        }
        target.gameObject.GetComponent<Sanity>().Hit(atkAmount);
    }

    public void FindTarget(){
        GameObject closest = null;
        float BestDist = 9999999;
        for(int i =0; i < TurretManager.manager.turrets.Count;i++){
            float dse = Vector3.Distance(transform.position,TurretManager.manager.turrets[i].transform.position);
            if(dse < BestDist){
                BestDist = dse;
                closest = TurretManager.manager.turrets[i];
            }
        }

        if(closest == null){
            closest = CharacterMove.cm.gameObject;
        }

        SetTarget(closest.transform);
    }

    public void GetHit(int amount){
        Life -= amount;
    }
}
