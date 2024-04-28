using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopContent : MonoBehaviour   // 附在content上
{
    public GameObject cropPanelPrefab;
    private List<CropSO> cropList = new List<CropSO>();
    
    private void Awake()
    {
        InitializeUI();
    }

    private void InitializeUI()
    {
        var loadCrops = Resources.LoadAll<CropSO>("Crops");

        foreach (var crop in loadCrops)
        {
            cropList.Add(crop);
        }
        cropList.Sort(SortByPrice);
        
        foreach (var crop in cropList)
        {
            CropPanel cropPanel = Instantiate(cropPanelPrefab, transform).GetComponent<CropPanel>();
            cropPanel.crop = crop;
        }
    }
    
    private int SortByPrice(CropSO a, CropSO b)
    {
        return a.price.CompareTo(b.price);
    }
    
    private int SortByTime(CropSO a, CropSO b)  // example
    {
        return a.timeBtwStages.CompareTo(b.timeBtwStages);
    }
}
