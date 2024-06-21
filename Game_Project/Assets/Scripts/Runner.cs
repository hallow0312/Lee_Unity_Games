using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

 public enum RoadLine
{
    LEFT=-1,
    MIDDLE=0,
    RIGHT=1
};
public class Runner : MonoBehaviour
{   
    [SerializeField] RoadLine line;
    [SerializeField] float positionX = 3.5f;
    [SerializeField] Animator animator;
    [SerializeField] AudioClip clip;
   

    private void OnEnable()
    {
        InputManager.Instance.keyAction += OnKeyUpdate;
    }
    private void Start()
    {
       line = RoadLine.MIDDLE;
       transform.position=new Vector3(0,0,0);
       animator= GetComponent<Animator>();
      
      
    }
    void OnKeyUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (line != RoadLine.LEFT)
            {
                line--;
                animator.Play("Left");
                SoundManager.Instance.Sound(clip); 
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (line != RoadLine.RIGHT)
            {
                animator.Play("Right");
                line++;
                SoundManager.Instance.Sound(clip); 
            }
        }
    }
    private void Update()
    {
        
       Move();
       
    }
    
    

    public void Move()
    {
        transform.position = new Vector3(positionX *(float)line,0,0); 
    
    }

    private void OnDisable()
    {
        InputManager.Instance.keyAction -= OnKeyUpdate;
    }

}
