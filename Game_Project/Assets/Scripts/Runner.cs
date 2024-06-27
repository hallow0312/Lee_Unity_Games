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
    [SerializeField] Animator animator;
    [SerializeField] AudioClip clip;
   
    [SerializeField] RoadLine line;
    [SerializeField] RoadLine PreviousLine;
    [SerializeField] float positionX = 3.5f;
    [SerializeField] float speed = 20.0f;

    
    private void OnEnable()
    {
        InputManager.Instance.keyAction += OnKeyUpdate;
    }
    private void Start()
    {
       line = RoadLine.MIDDLE;
       transform.position=new Vector3(0,0,0);
       PreviousLine = RoadLine.MIDDLE;
       animator= GetComponent<Animator>();
    }

    void OnKeyUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (line != RoadLine.LEFT)
            {
                PreviousLine = line;
                line--;
                animator.Play("Left");
                SoundManager.Instance.Sound(clip); 
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (line != RoadLine.RIGHT)
            {
                PreviousLine = line;

                animator.Play("Right");
                line++;
                SoundManager.Instance.Sound(clip); 
            }
        }
    }
    public void RevertPosition()
    {
        line = PreviousLine;
    }
    private void Update()
    {
        
       Move();
       
    }
    
    

    public void Move()
    {
        
        transform.position = Vector3.Lerp
        (
            transform.position,
            new Vector3(positionX * (float)line, 0, 0),
            speed*Time.deltaTime

        );
    
    }
    

    private void OnDisable()
    {
        InputManager.Instance.keyAction -= OnKeyUpdate;
    }

    public void DieScene()
    {
        animator.Play("Die");
    }
    private void OnTriggerEnter(Collider other)
    {
       IHitable hitable =other.GetComponent<IHitable>();
       if(hitable != null )
        {
            hitable.Activate(this);
        }
    }
}
