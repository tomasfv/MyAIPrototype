using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotJumpState : AIState
{
    public BotMovement botMovement;


    public override AIState SetCurrentState()
    {
        if (stateManager.isGrounded)
        {  
            return stateManager.botIdleState;
        }
        else
        {

            //Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward);
            Quaternion targetRotation = Quaternion.LookRotation(botMovement.wayPointList[botMovement.nextWayPointIndex].position);

            agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, targetRotation, 10 * Time.deltaTime);
            
            //anim.SetBool("IsRunning", false);
            //anim.SetBool("Reaction", false);
            //anim.SetBool("reactionDelay", false);
            //anim.SetBool("IsJumping", true);
            //anim.SetBool("IsGrounded", false);
            return this;
        }
    }
}
