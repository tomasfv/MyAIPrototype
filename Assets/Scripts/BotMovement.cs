using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;


public class BotMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public AIStateManager stateManager;
    public Rigidbody botRb;
    //public Animator anim;

    public enum SequencePath { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, CustomOne }
    [Header("Bot Pathway")]
    public SequencePath sequencePath;
    public List<Transform> wayPointList;
    public int nextWayPointIndex = 0;
    
    [Header("Bot Detection")]
    public float raycastDistance = 15f;
    public LayerMask obstacleLayer;
    private RaycastHit hit;
    private bool isHit;

    [Header("Bot Impulse")]
    public bool isOnImpulseBox;

    [Header("Bot Reaction")]
    public bool isOnReactionBox;
    public bool avoidReactions;



    void Start()
    {
       

        switch (sequencePath)
        {
            case SequencePath.One:
                wayPointList = WayPointsManager.singleton.wpSequences[0];
                break;
            case SequencePath.Two:
                wayPointList = WayPointsManager.singleton.wpSequences[1];
                break;
            case SequencePath.Three:
                wayPointList = WayPointsManager.singleton.wpSequences[2];
                break;
            case SequencePath.Four:
                wayPointList = WayPointsManager.singleton.wpSequences[3];
                break;
            case SequencePath.Five:
                wayPointList = WayPointsManager.singleton.wpSequences[4];
                break;
            case SequencePath.Six:
                wayPointList = WayPointsManager.singleton.wpSequences[5];
                break;
            case SequencePath.Seven:
                wayPointList = WayPointsManager.singleton.wpSequences[6];
                break;
            case SequencePath.Eight:
                wayPointList = WayPointsManager.singleton.wpSequences[7];
                break;
            case SequencePath.Nine:
                wayPointList = WayPointsManager.singleton.wpSequences[8];
                break;
            case SequencePath.CustomOne:
                wayPointList = WayPointsManager.singleton.customSequenceOne;
                break;
            default:
                break;
        }


    }

    void Update()
    {
    
        FollowPathway();
        
       
    }

    public void FollowPathway()
    {
        if (wayPointList.Count == 0) return;
        //if (nextWayPointIndex == wayPointList.Count) nextWayPointIndex = 0;   //for circuit mode. 
        if (nextWayPointIndex == wayPointList.Count) return;
        if (isOnImpulseBox) return;
        if (isOnReactionBox) return;

        float distanceToWayPoint = Vector3.Distance(wayPointList[nextWayPointIndex].position, transform.position);
        
        

        if (distanceToWayPoint <= 5)
        {  
            nextWayPointIndex++; 
        }


        if(nextWayPointIndex != wayPointList.Count)
        {
            //BotRunState On
            stateManager.SelectState("Run");

        }
        else
        {
            //BotIdleState On
            stateManager.SelectState("Idle");
            
           

        }


        if (agent.isOnOffMeshLink)
        {
            //BotJumpState On
            stateManager.SelectState("Jump");

            

        }
        else
        {
            //BotIdleState On
            stateManager.SelectState("Idle");

            BotRaycastDetection();

        }

    }

    public void BotRaycastDetection()
    {

        //if Boxcast hits an obstacle:
        isHit = Physics.BoxCast(transform.position, new Vector3(1, 1, 1), transform.forward, out hit, transform.rotation, raycastDistance, obstacleLayer);
        
        //if Raycast hits an obstacle:
        //isHit = Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, obstacleLayer);

        if(isHit)
        {
            Debug.Log("OBSTACLE DETECTION: " + hit.collider.name);
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);

            
            //BotIdleState On
            stateManager.SelectState("Idle");
            



        }
        else if(nextWayPointIndex != wayPointList.Count)
        {
            Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green);

            //BotRunState On
            stateManager.SelectState("Run");
            
           


        }

    }

  

    private void OnDrawGizmos()
    {
        
        if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position + transform.forward * hit.distance, new Vector3(1, 1, 1));

        }
       
    }

    public void BotImpulse(float upForce, float forwardForce, bool xDirection, bool diagonalDirection)
    {
        isOnImpulseBox = true;

        //BotJumpState On
        stateManager.SelectState("Jump");

        botRb.isKinematic = false;
        agent.enabled = false;

        botRb.velocity = Vector3.zero;
        botRb.angularVelocity = Vector3.zero;

        if (xDirection)
        {
            botRb.AddForce(new Vector3(forwardForce, upForce, 0), ForceMode.Impulse);
        }
        else if (diagonalDirection)
        {
            botRb.AddForce(new Vector3(forwardForce, upForce, forwardForce), ForceMode.Impulse);
        }
        else
        {
            botRb.AddForce(new Vector3(0, upForce, forwardForce), ForceMode.Impulse);
        }

        //Rotation
        //Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward);
        //Quaternion targetRotation = Quaternion.LookRotation(wayPointList[nextWayPointIndex].position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10 * Time.deltaTime);

    }

    public void BotLand()
    {
        isOnImpulseBox = false;
        agent.enabled = true;
        botRb.isKinematic = true;

        //BotJumpState Off
        stateManager.SelectState("Idle");


    }

    public void BotReaction()
    {
        if (avoidReactions) return;

        //StartCoroutine(ReactionCoroutine());

    }

    //public IEnumerator ReactionCoroutine()
    //{
    //    BotReactionState reactionState = GetComponentInChildren<BotReactionState>();
    //    float duration = reactionState.selectedClip.length;
        
    //    isOnReactionBox = true;

    //    //BotReactionState On
    //    stateManager.SelectState("Reaction");
    //    yield return new WaitForSeconds(duration - 0.2f);
    //    isOnReactionBox = false;
    //    yield return new WaitForSeconds(1f);
    //    reactionState.GenerateRandomIndex();

    //}



}
