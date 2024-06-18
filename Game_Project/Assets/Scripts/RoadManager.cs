using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roads;
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
}
    

