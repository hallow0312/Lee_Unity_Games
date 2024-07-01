using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public enum EventType
{
    START,
    PAUSE,
    CONTINUE,
    STOP
}
public class EventManager
{  
   private static readonly IDictionary<EventType ,UnityEvent> dictionary= new Dictionary<EventType ,UnityEvent>();

    //이벤트 등록함수
    public static void Subscribe(EventType eventType, UnityAction listener)
    {
        UnityEvent unityEvent = null;  
      
        if(dictionary.TryGetValue(eventType, out unityEvent))
        {
            //이벤트가 있을때 이벤트 등록
            unityEvent.AddListener(listener);
        }
        else
        {
            //없다면 ? unityEvent 인스턴스 
            unityEvent = new UnityEvent();
            //2. 이벤트 등록
            unityEvent.AddListener(listener);
            //3.dicitionary에 이벤트 추가
            dictionary.Add(eventType, unityEvent);

        }
        
    }
    public static void Unsubscribe(EventType eventType, UnityAction listener) 
    {
        UnityEvent unityEvent = null;
        if(dictionary.TryGetValue(eventType, out unityEvent)) 
        {
            unityEvent.RemoveListener(listener);
        }

    }
    public static void Publish(EventType eventType)
    {
        UnityEvent unityEvent = null;
        if(dictionary.TryGetValue(eventType,out unityEvent))
        {
            unityEvent.Invoke();
        }

    }

   
}
