using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roads;
    [SerializeField] float offset = 20.0f;
    private float roadSpeed = 3.0f;
    
 
    private void Start()
    {
        roads.Capacity = 10;
       
    }
    private void Update()
    {
        MoveRoad();
       
    }

    private void MoveRoad()
    {   
       
        roadSpeed += 0.001f;
        for (int i = 0; i < roads.Count; i++)
        {
            roads[i].transform.Translate(Vector3.back*roadSpeed*Time.deltaTime);
        }

    }
    public void NewPosition()
    {
        GameObject newRoad = roads[0];

        roads.Remove(newRoad);

        float newZ = roads[roads.Count - 1].transform.position.z + offset;
        newRoad.transform.position = new Vector3(0, 0, newZ);

        roads.Add(newRoad);
        
    }
}
    

