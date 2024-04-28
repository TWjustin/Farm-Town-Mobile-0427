using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CropPanel : MonoBehaviour
{
    [HideInInspector] public CropSO crop;
    
    public Image icon;
    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI priceTxt;
    private Button button;
    

    private void Start()
    {
        InitializeUI();
        
        button = GetComponent<Button>();
        button.onClick.AddListener(SelectSelf);
    }


    private void InitializeUI()
    {
        icon.sprite = crop.icon;
        nameTxt.text = crop.itemName;
        priceTxt.text = crop.price.ToString();
    }

    private void SelectSelf()
    {
        FarmManager.Instance.OnCropSelected?.Invoke(crop);
    }
}
