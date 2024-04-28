using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : MonoBehaviour
{
    // 生成地块
    public GameObject plotPrefab;
    public Vector2 startPos;
    public int columns = 7;
    public int rows = 3;

    public GameObject shopPanel;
    public GameObject leftBtns;
    public GameObject rightBtns;
    public GameObject actionBtns;
    
    // plant
    [HideInInspector] public CropSO selectedCrop;
    [HideInInspector] public bool plantMode = false;
    
    private enum Mode
    {
        Default,
        Shop,
        Plant,
    }
    
    public Action<CropSO> OnCropSelected;
    

    #region Singleton
    
    public static FarmManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    #endregion
    

    private void Start()
    {
        InitializePlot();
        
        shopPanel.SetActive(false);
        actionBtns.SetActive(false);
        
        OnCropSelected += EnterPlantMode;
    }

    private void InitializePlot()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Vector2 pos = new Vector2(startPos.x + i * 2f, startPos.y - j * 2f);
                Instantiate(plotPrefab, pos, Quaternion.identity, transform);
            }
        }
    }

    private void EnterPlantMode(CropSO crop)
    {
        selectedCrop = crop;
        
        plantMode = true;
        shopPanel.SetActive(false);
        leftBtns.SetActive(false);
        rightBtns.SetActive(false);
        actionBtns.SetActive(true);
        
    }
    
    
}
