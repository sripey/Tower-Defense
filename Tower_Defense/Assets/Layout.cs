using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layout : MonoBehaviour
{
    [SerializeField] public List<Cube> waypoints;

    void Start ()
    {
        
    }


    private void Update()
    {
        
    }

    public void AddToLayout(Cube cube)
    {
        if (!waypoints.Contains(cube))
        {

            waypoints.Add(cube);
        }
        else
        {
            
        }
    }

}
