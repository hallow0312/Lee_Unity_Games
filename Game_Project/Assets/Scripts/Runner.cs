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
    [SerializeField] Rigidbody rigidBody;
    
    [SerializeField] RoadLine line;
    [SerializeField] RoadLine PreviousLine;
    
    [SerializeField] bool IsJumping = false;
    [SerializeField] float positionX = 3.5f;
    [SerializeField] float speed = 20.0f;
    [SerializeField] float jumpPower = 10.0f;
    private void OnEnable()
    {
        base.OnEnable();
        InputManager.Instance.keyAction += OnKeyUpdate;
        
    }
    private void Awake() //start보다 먼저 호출됨.
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
        else if(!IsJumping&&Input.GetKeyDown(KeyCode.Space))
        {
         
          animator.Play("Jump");
          Jump();
          SoundManager.Instance.Sound(clip);
         
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
        animator.speed = 0.5f+SpeedManager.Speed / 25.0f;
    }
    
    public void Jump()
    {
       IsJumping = true;  
       
       rigidBody.AddForce(Vector3.up * jumpPower,ForceMode.Impulse);
    }

    public void Move()
    {
        if (state == false)
        {
            return;
        }
        rigidBody.position = Vector3.Lerp
        (
            rigidBody.position,
            new Vector3(positionX * (float)line, rigidBody.position.y, 0),
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Road"))
        {
            IsJumping = false;
            animator.SetTrigger("Active");
        }
    }
}
