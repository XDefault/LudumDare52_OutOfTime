using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionAnimationEnterScript : StateMachineBehaviour
{
    private void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        CharacterMove.cm.ToggleMovement();
    }
}
