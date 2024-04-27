using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
public class InventorySO : ScriptableObject
{
    [Serializable]
    public class ItemNum
    {
        public ItemSO item;
        public int num;
        public int maxItemNum;
    }
    
    public int maxSlotNum;
    public ItemNum[] itemNums;

    private void Awake()
    {
        itemNums = new ItemNum[maxSlotNum];
    }
    
    // todo: can add
    
    public void AddItem(ItemSO item, int num)
    {
        
        foreach (var i in itemNums)
        {
            if (i.item == item)
            {
                i.num += num;
                return;
            }
            else if (i.item == null)
            {
                i.item = item;
                i.num = num;
                return;
            }
        }
        
    }
    
}
