using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DepositArea : MonoBehaviour
{
    public int maxDeposit = 100;
    public int curDeposit = 0;
    public TMP_Text textAmount;
    public List<Item> deposit = new List<Item>();
    public DepositArea newDeposit;

    public bool isComplete;

    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        if (isComplete)
        {
            if (newDeposit != null)
            {
                newDeposit.gameObject.SetActive(true);
                gameObject.SetActive(false);
            }
                    
            UpdateUI();
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Object"))
        {
            Item itm = col.GetComponent<Item>();
            
            if (itm.hasDrop)
            {
                if (curDeposit != maxDeposit)
                {
                    curDeposit += itm.itemData.itemWeight;
                    col.gameObject.SetActive(false);
                    itm.transform.SetParent(transform);
                    deposit.Add(itm);
            
                    UpdateUI();

                    if (curDeposit == maxDeposit) isComplete = true;
                }
            }
        }
    }

    public void Removeable(int weight, Transform parent)
    {
        foreach (var removeable in deposit)
        {
            if (removeable.itemData.itemWeight == weight)
            {
                curDeposit -= removeable.itemData.itemWeight;
                removeable.gameObject.SetActive(true);
                removeable.transform.SetParent(parent);
                removeable.hasDrop = false;
                
                deposit.Remove(removeable);
                
                UpdateUI();
                break;
            }
        }
    }
    

    void UpdateUI()
    {
        textAmount.text = curDeposit.ToString() + " / " + maxDeposit.ToString();
        textAmount.color = curDeposit > maxDeposit ? Color.red : Color.white;
    }
}
