using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCropItem : MonoBehaviour
{
    [HideInInspector] public CropSO crop;
    public Image icon;
    private Button button;
    
    
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        
        InitializeUI();
    }

    private void InitializeUI()
    {
        icon.sprite = crop.icon;
    }
    
    private void OnClick()
    {
        ShopInfo.displayCropInfo?.Invoke(crop);
    }
    
}
