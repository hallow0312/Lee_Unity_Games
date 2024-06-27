using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour,IInteractable
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] Vector3 direction;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
        
    }

    private void OnEnable()
    {
        direction = Vector3.forward;
    }
    private void Update()
    {
        speed+=0.01f;
        transform.Translate(direction*speed*Time.deltaTime);
    }

    private void OnDisable()
    {
        
    }
    public void Interact()
    {
        gameObject.SetActive(false);
    }

}
