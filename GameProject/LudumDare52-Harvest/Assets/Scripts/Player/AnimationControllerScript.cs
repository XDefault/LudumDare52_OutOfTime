using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerScript : MonoBehaviour
{   

    private Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponentInChildren<Animator>(false);
    }

    // Update is called once per frame
    public void SetAnimatorParam(string Name, bool state)
    {
       m_Animator.SetBool(Name,state); 
    }

    public void SetAnimatorParam(string Name){
        m_Animator.SetTrigger(Name);
    }
}
