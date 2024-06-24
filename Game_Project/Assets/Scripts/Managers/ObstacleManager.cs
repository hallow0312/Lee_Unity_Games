using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] int random;
    [SerializeField] int randomPostion;
    
    [SerializeField] List<GameObject> obstaclesList;

    [SerializeField] GameObject[] ObstaclePrefabs;
    [SerializeField] Transform[] activePositions;
    
    void Start()
    {
        obstaclesList.Capacity = 10;
       
        Create();
        StartCoroutine(ActiveObstacle());
       
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

    IEnumerator ActiveObstacle()
    {
      
        WaitForSeconds waitForSeconds = new WaitForSeconds(5.0f);
        while(true)
        {
            random= Random.Range(0,obstaclesList.Count);
            randomPostion = Random.Range(0, activePositions.Length);

            if (obstaclesList[random].activeSelf==true)
            {
                random = (random + 1) % obstaclesList.Count;
            }

            obstaclesList[random].transform.position = activePositions[randomPostion].position;
            obstaclesList[random].SetActive(true);

            yield return waitForSeconds;
            
        }       
       
    }
   

}
