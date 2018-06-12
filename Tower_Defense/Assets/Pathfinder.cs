using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };


    void Start ()
    {
        LoadBlocks();
        ColorStartAndEnd();
        ExporeNeighborBlocks(startWaypoint);
    }

    private void ExporeNeighborBlocks(Waypoint waypoint)
    {
        foreach (var direction in directions)
        {
            Vector2Int neighborCoordinates = waypoint.GetGridPos() + direction;

            bool blockIsInWorld = grid.ContainsKey(neighborCoordinates);
            if (blockIsInWorld)
            {
                print("Exploring..." + neighborCoordinates);
                grid[neighborCoordinates].SetTopColor(Color.yellow);
            }
            else
            {
                print(neighborCoordinates + "...is not in world.");
            }
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.blue);
        endWaypoint.SetTopColor(Color.red);
    }

    void Update ()
    {
        
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();

        foreach (Waypoint waypoint in waypoints)
        {
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos());
            if (isOverlapping)
            {
                Debug.LogWarning("Overlapping block " + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
                
            }

        }
        
        print("Loaded " + grid.Count + " blocks");

    }
}
