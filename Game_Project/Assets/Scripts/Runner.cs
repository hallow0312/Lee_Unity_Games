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

    private void Start()
    {
       line = RoadLine.MIDDLE;
       transform.position=new Vector3(0,0,0);
       animator= GetComponent<Animator>();
      
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(line!=RoadLine.LEFT)
            {
                line--;
                animator.Play("Left");
                
            }
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(line!=RoadLine.RIGHT) 
            {
                animator.Play("Right");
                
                line++;
            }
        }
                Status(line);
       
    }
    
    public void Status(RoadLine line)
    {
        switch(line)
        {
            case RoadLine.LEFT:
                Move(-positionX);
                break;
     
            case RoadLine.MIDDLE:
                Move(0);
                break;

            case RoadLine.RIGHT:
                Move(positionX);
                break;

        }
    }

    public void Move(float PositionX)
    {
        transform.position = new Vector3(PositionX,0,0);
    
    }


}
