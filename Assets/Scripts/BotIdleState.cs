using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotIdleState : AIState
{

    public override AIState SetCurrentState()
    {
        if (stateManager.run)
        {

            return stateManager.botRunState;

        }
        else if (stateManager.isReacting)
        {
            return stateManager.botReactionState;
        }
        else
        {
            
            agent.SetDestination(transform.position);

            anim.SetBool("IsRunning", false);
            anim.SetBool("IsJumping", false);
            //anim.SetBool("IsGrounded", true);
            //anim.SetBool("Reaction", false);
           
            return this;
        }
    }
}
