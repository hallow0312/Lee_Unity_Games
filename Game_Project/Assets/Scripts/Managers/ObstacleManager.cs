using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] GameObject[] ObstaclePrefabs;
    [SerializeField] List<GameObject> obstaclesList;
   
    
   
    
    void Start()
    {
        obstaclesList.Capacity = 10;
        Create();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Create()
    {
       for(int i =0; i<ObstaclePrefabs.Length; i++)
        {
            GameObject obstacle = Instantiate(ObstaclePrefabs[i]);
            obstaclesList.Add(obstacle);

            ObstaclePrefabs[i].SetActive(false);
        }
    }
      
  
   

}
