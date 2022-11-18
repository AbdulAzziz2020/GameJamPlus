using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerPoint : MonoBehaviour
{
    public int maxPocket = 100;
    public int pocket = 0;
    public List<int> pointHandler = new List<int>();
    public Text pointText;

    private void Update()
    {
        OnUpdatePoint();
    }

    public void AddPoint(int point)
    {
        if (IsComplete()) SetNewValue();
        else
        {
            pocket += point;
            pointHandler.Add(point); 
        }
    }

    public void RemovePoint(int point)
    {
        if (IsComplete()) SetNewValue();
        else
        {
            foreach (int removable in pointHandler)
            {
                if (removable == point)
                {
                    pocket -= removable;
                    pointHandler.Remove(removable);
                    break;
                }
            }  
        }
    }

    public void OnUpdatePoint()
    {
        pointText.text = pocket.ToString() + " / " + maxPocket.ToString();
        pointText.color = pocket > maxPocket ? Color.red : Color.white;
    }

    public bool IsComplete()
    {
        return pocket == maxPocket;
    }

    public void SetNewValue()
    {
        if (IsComplete())
        {
            pocket = 0;
            maxPocket = maxPocket + 50;
            pointHandler.Clear();
        }
    }
}
