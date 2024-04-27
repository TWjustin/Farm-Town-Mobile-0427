using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopInfo : MonoBehaviour
{
    private int maxBuyNum = 99; // todo 減
    
    [Header("UI")]
    public Image icon;
    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI unitPriceTxt;
    
    public TextMeshProUGUI numTxt;
    public Button minusBtn;
    public Button plusBtn;
    
    public TextMeshProUGUI totalPriceTxt;
    public Button buyBtn;

    // Events
    public static Action<CropSO> displayCropInfo;
    
    private void Start()
    {
        InitializeUI();
        
        minusBtn.onClick.AddListener(DecreaseNum);
        plusBtn.onClick.AddListener(IncreaseNum);
        buyBtn.onClick.AddListener(BuyCrop);
        
        displayCropInfo += DisplayCropInfo;
        
    }
    
    private void InitializeUI()
    {
        icon.color = Color.clear;
        nameTxt.text = "";
        SetText(1, 0);

        plusBtn.interactable = false;
        minusBtn.interactable = false;
        buyBtn.interactable = false;

    }
    
    private void SetText(int num, int unitPrice)
    {
        unitPriceTxt.text = unitPrice.ToString();
        numTxt.text = num.ToString();
        totalPriceTxt.text = (num * unitPrice).ToString();
    }
    
    private void DecreaseNum()
    {
        int num = int.Parse(numTxt.text);
        int unitPrice = int.Parse(unitPriceTxt.text);
        if (num > 1)
        {
            num--;
            SetText(num, unitPrice);
        }
    }
    
    private void IncreaseNum()
    {
        int num = int.Parse(numTxt.text);
        int unitPrice = int.Parse(unitPriceTxt.text);
        if (num < maxBuyNum)
        {
            num++;
            SetText(num, unitPrice);
        }
    }

    private void BuyCrop()
    {
        // TODO: inventory
        
        InitializeUI();
    }
    
    private void DisplayCropInfo(CropSO crop)
    {
        icon.sprite = crop.icon;
        icon.color = Color.white;
        
        nameTxt.text = crop.itemName;
        unitPriceTxt.text = crop.price.ToString();
        
        numTxt.text = "1";
        totalPriceTxt.text = crop.price.ToString();
        
        plusBtn.interactable = true;
        minusBtn.interactable = true;
        buyBtn.interactable = true;
    }
}
