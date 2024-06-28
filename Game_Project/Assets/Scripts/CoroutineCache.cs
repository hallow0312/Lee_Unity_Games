using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoroutineCache : MonoBehaviour
{   
    class Compare:IEqualityComparer<float> //��ø Ŭ����
    {
        public bool Equals(float x, float y)
        {
            return x==y;
        }

        public int GetHashCode(float obj)
        {
            return obj.GetHashCode();
        }
    }
    private static readonly Dictionary<float,WaitForSeconds> dictionary=
        new Dictionary<float,WaitForSeconds>(new Compare());
    //readonly ��Ÿ�� ������ ���ȭ 
    //const�� �ӵ��� ������ ������ ���� 
    //readonly�� const ���� ������ �������� 
    public static WaitForSeconds waitForSeconds(float seconds)
    {
        WaitForSeconds wfs = null;
        if(!dictionary.TryGetValue(seconds,out wfs))
        {
            dictionary.Add(seconds,wfs=new WaitForSeconds(seconds));
        }
        return wfs; 
    }
}
