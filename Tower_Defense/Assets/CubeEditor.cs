using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]

public class CubeEditor : MonoBehaviour
{
    [SerializeField] [Range(1f,20f)] float gridSize = 10f;
    //Layout layout;
    TextMesh textMesh;
    //List<Cube> cubes;
    
    void Start()
    {
        
        
    }

    void Update ()
    {
        Layout layout = GetComponentInParent<Layout>();
        //EnemyPath path = GetComponentInParent<EnemyPath>();
        Vector3 snapPos;
        snapPos.y = 0f;
        snapPos.x = Mathf.RoundToInt(transform.position.x /gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPos.x, snapPos.y, snapPos.z);
        
        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = snapPos.x /gridSize + "," + snapPos.z/gridSize;
        textMesh.text = labelText;
        gameObject.name = "Cube" + "(" + labelText + ")";

        Cube cube = GetComponent<Cube>();
        
       
        cube.cubeName = gameObject.name;
        cube.cubeLoction = new Vector3(snapPos.x,snapPos.y,snapPos.z);
        //cubes.Add(cube);

         layout.AddToLayout(cube);
        //path.AddToEnemyPath(cube);

        
        


    }
}
