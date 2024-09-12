using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotRunState : AIState
{

    public BotMovement botMovement;   
    private float originalAngularSpeed;
    private float originalAcceleration;

    private void Start()
    {
        originalAngularSpeed = agent.angularSpeed;
        originalAcceleration = agent.acceleration;
    }
    public override AIState SetCurrentState()
    {
        
        if (stateManager.stop)
        {
            
            return stateManager.botIdleState;

        }
        else if(stateManager.jump)
        {
            
            return stateManager.botJumpState;

        }
        else if (stateManager.isReacting)
        {
            return stateManager.botReactionState;
        }
        else
        {
            
            agent.destination = botMovement.wayPointList[botMovement.nextWayPointIndex].position;

            //anim.SetBool("IsJumping", false);
            //anim.SetBool("Reaction", false);
            //anim.SetBool("reactionDelay", false);
            //anim.SetBool("IsRunning", agent.velocity.magnitude > 0.01f);
            //anim.SetBool("IsGrounded", true);

            return this;

        }
    }
}
