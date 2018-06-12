using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;

    void Start ()
    {

        
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint wayPoint in path)
        {
            transform.position = wayPoint.transform.position;
            print(wayPoint.name);
            yield return new WaitForSeconds(1f);
        }
    }
}
