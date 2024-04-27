using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public GameObject storeCropItemPrefab;
    private List<CropSO> cropList = new List<CropSO>();
    
    private void Awake()
    {
        var loadCrops = Resources.LoadAll<CropSO>("Crops");

        foreach (var crop in loadCrops)
        {
            cropList.Add(crop);
        }
        cropList.Sort(SortByPrice);
        
        foreach (var crop in cropList)
        {
            StoreCropItem newCropItem = Instantiate(storeCropItemPrefab, transform).GetComponent<StoreCropItem>();
            newCropItem.crop = crop;
        }
    }
    
    private int SortByPrice(CropSO a, CropSO b)
    {
        return a.price.CompareTo(b.price);
    }
    
    private int SortByTime(CropSO a, CropSO b)
    {
        return a.timeBtwStages.CompareTo(b.timeBtwStages);
    }
}
