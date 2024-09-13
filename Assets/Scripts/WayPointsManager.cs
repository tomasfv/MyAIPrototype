using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsManager : MonoBehaviour
{
    public static WayPointsManager singleton;
    public List<WayPointsZone> wayPointZones;
    public List<Transform>[] wpSequences;       //Array of Lists(of Transforms) not visible in inspector. 
    
    public List<Transform> customSequenceOne;   //Optional customizable sequence. 
   

    private void Awake()
    {
        if (singleton != null)
            Destroy(this);

        singleton = this;

        // Initialize list with nº of WayPoints per Zone:
        wpSequences = new List<Transform>[9];       
        for (int i = 0; i < 9; i++)
        {
            wpSequences[i] = new List<Transform>();
        }

        // Fill sequences with unique random WayPoints:
        for (int i = 0; i < wayPointZones.Count; i++)
        {
            int[] randomIndices = GenerateUniqueRandomIndices(9);

            for (int j = 0; j < 9; j++)
            {
                wpSequences[j].Add(wayPointZones[i].wayPoints[randomIndices[j]]);
            }
        }
    }

    // Generate a List converted to array of unique random indexes:
    private int[] GenerateUniqueRandomIndices(int count)
    {
        List<int> indices = new List<int>();
        for (int i = 0; i < count; i++)
        {
            indices.Add(i);
        }

        indices = indices.OrderBy(x => Random.Range(0, 1000)).ToList();
        return indices.ToArray();
    }



}

