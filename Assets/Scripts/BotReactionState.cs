using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotReactionState : AIState
{
    //public AnimationClip[] animationClips;
    //private AnimatorOverrideController animatorOverrideController;
    //public int randomIndex;
    ////public int clipIndex = 0;
    //public AnimationClip selectedClip;

    void Start()
    {
       
        //animatorOverrideController = new AnimatorOverrideController(anim.runtimeAnimatorController);
        //anim.runtimeAnimatorController = animatorOverrideController;

        //randomIndex = Random.Range(0, animationClips.Length);
        //selectedClip = animationClips[randomIndex];



    }

    public override AIState SetCurrentState()
    {
        if (stateManager.isReacting == false)
        {
            return stateManager.botIdleState;
        }
        else
        {
            agent.SetDestination(transform.position);

            
            //anim.SetBool("IsRunning", false);
            //anim.SetBool("IsJumping", false);
            
            
            //anim.SetBool("Reaction", true);
            //anim.SetBool("reactionDelay", true);

           
            //animatorOverrideController["R_050_euforia_saltando_loco"] = selectedClip;
           
            //selectedClip = animationClips[randomIndex];

            return this;

        }

        
    }

    public void GenerateRandomIndex()
    {
        //randomIndex = Random.Range(0, animationClips.Length);
        //selectedClip = animationClips[randomIndex];
    }

    


}
