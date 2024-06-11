using System.Collections;
using System.Collections.Generic;
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
    private void Start()
    {
       line = RoadLine.MIDDLE;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(line!=RoadLine.LEFT)
            {
                line--;
            }
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(line!=RoadLine.RIGHT) 
            {
                line++;
            }
        }
       
    }

}
