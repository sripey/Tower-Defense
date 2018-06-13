using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> pathQueue = new Queue<Waypoint>();
    Waypoint searchCenter;
    List<Waypoint> path = new List<Waypoint>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    bool isRunning = true;

    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
        return path;
    }


    private void CreatePath()
    {
        path.Add(endWaypoint);
        Waypoint previous = endWaypoint.exploredFrom;

        while (previous != startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }

        path.Add(startWaypoint);
        path.Reverse();
    }


    private void BreadthFirstSearch()
    {
        pathQueue.Enqueue(startWaypoint);

        while (pathQueue.Count > 0 && isRunning)
        {
            searchCenter = pathQueue.Dequeue();
            HaltIfEndFound();
            ExporeNeighborBlocks();
            searchCenter.isExplored = true;
        }
    }


    private void HaltIfEndFound()
    {
        if(searchCenter == endWaypoint)

            {
            isRunning = false;
            }
    }


    private void ExporeNeighborBlocks()
    {
        if (!isRunning) { return; }

        foreach (var direction in directions)
        {
            Vector2Int neighborCoordinates = searchCenter.GetGridPos() + direction;

            bool blockIsInWorld = grid.ContainsKey(neighborCoordinates);
            if (blockIsInWorld)
            {
                QueueNewNeighbors(neighborCoordinates);
            }
            else
            {
            }
        }
    }

    private void QueueNewNeighbors(Vector2Int neighborCoordinates)
    {
        Waypoint neighbor = grid[neighborCoordinates];
        if (neighbor.isExplored || pathQueue.Contains(neighbor))
        {
        }
        else
        {
            pathQueue.Enqueue(neighbor);
            neighbor.exploredFrom = searchCenter;
            //neighbor.isExplored = true;
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.blue);
        endWaypoint.SetTopColor(Color.red);
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
