using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackDetector : MonoBehaviour
{
   
   
    private void OnCollisionEnter(Collision collision)
    {
       Obstacle clone = collision.gameObject.GetComponent<Obstacle>();
        if (clone != null)
        {
            clone.Speed = transform.parent.GetComponent<Obstacle>().Speed;
        }
       
    }
}
