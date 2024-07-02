using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpeedManager : MonoBehaviour
{
    [SerializeField] static float speed;
    [SerializeField] float Maxspeed=60.0f;
    [SerializeField] UnityEvent callback;
    public static float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private void Start()
    {
        speed = 20.0f;
        
        StartCoroutine(IncreaseSpeed());
    }

    IEnumerator IncreaseSpeed()
    {
       while(speed < Maxspeed) 
        {
            yield return CoroutineCache.waitForSeconds(2.5f);
            if(callback!=null)
            {
                callback.Invoke();
            }
            speed++;
        }
      
    }
 
}
