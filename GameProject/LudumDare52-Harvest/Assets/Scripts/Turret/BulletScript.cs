using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Transform target;
    private int damage = 15;
    [SerializeField]private float speed = 15f;
    // Update is called once per frame
    void Update()
    {
        if(target == null) Destroy(gameObject);

        if(Vector3.Distance(target.position,transform.position) < 0.5f){
            target.GetComponent<EnemyAI>().GetHit(damage);
            Destroy(gameObject);
        }
        
        Vector3 dir = target.position - transform.position;
        dir.y = 0;
        Quaternion toRot = Quaternion.LookRotation(dir,Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRot, 700 * Time.deltaTime);
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
