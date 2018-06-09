using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //[SerializeField] List<Block> path;

    void Start ()
    {

        StartCoroutine(FollowPath());
        
    }

    IEnumerator FollowPath()
    {
        EnemyPath path = GetComponent<EnemyPath>();
        foreach (Cube wayPoint in path.enemyPath)
        {
            transform.position = wayPoint.transform.position;
            print(wayPoint.name);
            yield return new WaitForSeconds(1f);
        }
    }
}
