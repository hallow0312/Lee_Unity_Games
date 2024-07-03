using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class ObstacleManager : State
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
            ObstaclePrefabs[i].SetActive(false);
            obstaclesList.Add(obstacle);

        }
        
        

    }

    IEnumerator ActiveObstacle()
    {
    

        while (state==true)
        {
            yield return CoroutineCache.waitForSeconds(2.5f);
            random= Random.Range(0,obstaclesList.Count);
            randomPostion = Random.Range(0, activePositions.Length);

            while (obstaclesList[random].activeSelf==true)
            {
                if(ExamineActive()==true)
                {
                    GameObject obstacle = Instantiate (ObstaclePrefabs[Random.Range(0,ObstaclePrefabs.Length)]);
                    obstacle.SetActive(false);
                    obstaclesList.Add(obstacle);
              
                }
                random = (random + 1) % obstaclesList.Count;
            }

            obstaclesList[random].transform.position = activePositions[randomPostion].position;
            obstaclesList[random].SetActive(true);

        }       
    }
            
       
   public bool ExamineActive() 
    {
        for(int i =0; i< obstaclesList.Count; i++)
        {
            if(obstaclesList[i].activeSelf==false)
            {
                return false;
            }
        }
        return true;
    }
   

}
