using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventorySO inventory;
    public GameObject slotPrefab;

    private void Start()
    {
        InitializeUI();
    }
    
    private void InitializeUI()
    {
        for (int i = 0; i < inventory.maxSlotNum; i++)
        {
            Instantiate(slotPrefab, transform);
        }
    }
}
