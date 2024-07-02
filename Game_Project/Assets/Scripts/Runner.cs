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
[RequireComponent(typeof(Rigidbody))]
public class Runner:State
{   
    [SerializeField] Animator animator;
    [SerializeField] AudioClip clip;
   
    [SerializeField] RoadLine line;
    [SerializeField] RoadLine PreviousLine;
    
    [SerializeField] float positionX = 3.5f;
    [SerializeField] float speed = 20.0f;

    Rigidbody rigidBody;
    private void OnEnable()
    {
        base.OnEnable();
        InputManager.Instance.keyAction += OnKeyUpdate;
        
    }
    private void Start()
    {
        Component();
       line = RoadLine.MIDDLE;
       transform.position=new Vector3(0,0,0);
       PreviousLine = RoadLine.MIDDLE;
       animator= GetComponent<Animator>();
    }
    void Component()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
    }
    void OnKeyUpdate()
    {   
        if(state==false)
        {
            return;
        }
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
    public void Initialize()
    {
        animator.speed = SpeedManager.Speed / 20.0f;
    }
    
    

    public void Move()
    {
        if (state == false)
        {
            return;
        }
        transform.position = Vector3.Lerp
        (
            transform.position,
            new Vector3(positionX * (float)line, 0, 0),
            speed*Time.deltaTime

        );
    
    }
    

    private void OnDisable()
    {
        base.OnDisable();
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
