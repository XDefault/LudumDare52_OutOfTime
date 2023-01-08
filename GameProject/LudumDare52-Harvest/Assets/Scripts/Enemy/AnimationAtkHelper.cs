using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAtkHelper : MonoBehaviour
{   
    EnemyAI aI;
    // Start is called before the first frame update
    void Start()
    {
        aI = GetComponentInParent<EnemyAI>();
    }

    public void Hit(){
        aI.Hit();
    }
}
