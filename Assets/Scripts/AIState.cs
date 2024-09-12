using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class AIState : MonoBehaviour
{
    public AIStateManager stateManager;
    public NavMeshAgent agent;
    //public Animator anim;
    public abstract AIState SetCurrentState();
}
