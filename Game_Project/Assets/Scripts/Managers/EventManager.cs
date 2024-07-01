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

    //�̺�Ʈ ����Լ�
    public static void Subscribe(EventType eventType, UnityAction listener)
    {
        UnityEvent unityEvent = null;  
      
        if(dictionary.TryGetValue(eventType, out unityEvent))
        {
            //�̺�Ʈ�� ������ �̺�Ʈ ���
            unityEvent.AddListener(listener);
        }
        else
        {
            //���ٸ� ? unityEvent �ν��Ͻ� 
            unityEvent = new UnityEvent();
            //2. �̺�Ʈ ���
            unityEvent.AddListener(listener);
            //3.dicitionary�� �̺�Ʈ �߰�
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
