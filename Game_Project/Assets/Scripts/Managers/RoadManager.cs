using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RoadManager :State
{
    [SerializeField] float speed;
    [SerializeField] List<GameObject> roads;
    [SerializeField] float offset = 20.0f;

  

    private void Start()
    {
        Initialize();
        speed = SpeedManager.Speed/2;
       
    }
    private void Update()
    {
        if (state == false)
        {
            return;
        }
       
        MoveRoad();
       
    }
    public void Initialize()
    {
        speed = SpeedManager.Speed / 2;
    }
    
    private void MoveRoad()
    {   
        for (int i = 0; i < roads.Count; i++)
        {
            roads[i].transform.Translate(Vector3.back*speed*Time.deltaTime);
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


