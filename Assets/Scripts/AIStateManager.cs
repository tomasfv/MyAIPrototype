using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateManager : MonoBehaviour
{
    public AIState currentState;
    
    [Header("Bot States")]
    public BotIdleState botIdleState;
    public BotRunState botRunState;
    public BotJumpState botJumpState;
    public BotReactionState botReactionState;
    //TODO: Push State;
    //TODO: Double Jump State;
    //TODO: Troll State;

    [Header("Bot Parameters")]
    public bool run;
    public bool stop;
    public bool jump;
    public bool isGrounded;
    public bool isReacting;


    void Update()
    {
        ActivateStateMachine();
    }

    private void ActivateStateMachine()
    {
        

        AIState nextState = currentState.SetCurrentState();

        if(nextState != null)
        {
            SwitchToNextState(nextState);
        }
    }

    private void SwitchToNextState(AIState nextState)
    {
        currentState = nextState;
    }

    public void SelectState(string state)
    {
        switch (state)
        {
            case "Idle":
                run = false;
                stop = true;
                jump = false;
                isGrounded = true;
                isReacting = false;
                break;
            case "Run":
                run = true;
                stop = false;
                jump = false;
                isGrounded = true;
                isReacting = false;
                break;
            case "Jump":
                run = false;
                stop = false;
                jump = true;
                isGrounded = false;
                isReacting = false;
                break;
            case "Reaction":
                run = false;
                stop = true;
                jump = false;
                isGrounded = true;
                isReacting = true;
                break;
            default:
                break;
        }
    }
}
