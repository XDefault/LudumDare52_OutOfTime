using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionAnimationExitScript : StateMachineBehaviour
{
    private void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        CharacterMove.cm.ToggleMovement();
    }
}
