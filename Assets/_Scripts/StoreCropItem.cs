using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreCropItem : MonoBehaviour
{
    public CropSO crop;
    
    public Image icon;
    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI priceTxt;
    private Button buyBtn;
    
    private FarmManager farmManager;
    
    private void Start()
    {
        farmManager = FindObjectOfType<FarmManager>();
        
        buyBtn = GetComponent<Button>();
        buyBtn.onClick.AddListener(BuyPlant);
        
        // InitializeUI();
    }

    private void InitializeUI()
    {
        icon.sprite = crop.icon;
        nameTxt.text = crop.cropName;
        priceTxt.text = crop.price.ToString();
    }

    public void BuyPlant()
    {
        farmManager.SelectCrop(crop);
    }
}
