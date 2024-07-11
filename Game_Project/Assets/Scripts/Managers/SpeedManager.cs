using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpeedManager :State
{
    [SerializeField] static float speed;
    [SerializeField] float Maxspeed=60.0f;
    [SerializeField] UnityEvent callback;
    public static float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private void Awake()
    {
        speed = 20.0f;
        
        StartCoroutine(IncreaseSpeed());
    }

    IEnumerator IncreaseSpeed()
    {
       while(speed < Maxspeed && state==true) 
        {
            if(callback!=null)
            {
                callback.Invoke();
            }
            yield return CoroutineCache.waitForSeconds(2.5f);
            speed++;
        }
      
    }
 
}
