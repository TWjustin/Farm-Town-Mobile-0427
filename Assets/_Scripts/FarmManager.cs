using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : MonoBehaviour
{
    public GameObject plotPrefab;
    public Vector2 startPos;
    public int columns = 7;
    public int rows = 3;
    
    // plant
    [HideInInspector] public CropSO selectedCrop;
    [HideInInspector] public bool isPlanting = false;
    

    private void Start()
    {
        InitializePlot();
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
    
}
