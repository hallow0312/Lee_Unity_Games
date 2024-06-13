using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : SingleTon<InputManager>
{   
   
    public Action keyAction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey==false)
        {
            return;
        }
       
        if(keyAction != null)
        {
            keyAction.Invoke();
        }
    }
}
