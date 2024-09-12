using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBox : MonoBehaviour
{
    public enum BoxType { Impulse, Land, Reaction, LinksOn, LinksOff }
    public BoxType boxType;

    [Header("Impulse Force")]
    [Tooltip("Use for Impulse type boxes")]
    public float upForce;
    public float forwardForce;
    public bool xAxisForward;
    public bool diagonalForward;

    [Header("Links Activation")]
    [Tooltip("Use for Links type boxes")]
    public bool linksActivated;
    public GameObject[] linksArray;

    private void OnTriggerEnter(Collider other)
    {
        BotMovement botMovement = other.GetComponentInParent<BotMovement>();


        if (boxType == BoxType.Impulse && botMovement != null)
        { 
            botMovement.BotImpulse(upForce, forwardForce, xAxisForward, diagonalForward);
        }

        if (boxType == BoxType.Land && botMovement != null)
        {
            botMovement.BotLand();
        }

        if (boxType == BoxType.Reaction && botMovement != null)
        {
            
            botMovement.BotReaction();
            gameObject.SetActive(false);
        }

        if (boxType == BoxType.LinksOn && botMovement != null)
        {
            if (linksActivated == false)
            {
                foreach (GameObject link in linksArray)
                {
                    link.SetActive(true);

                }
                
                linksActivated = true;
               
            }
        }
        
        if (boxType == BoxType.LinksOff && botMovement != null)
        {
            if (linksActivated == true)
            {
                foreach (GameObject link in linksArray)
                {
                    link.SetActive(false);

                }

                linksActivated = false;

            }
        }
    }

}
