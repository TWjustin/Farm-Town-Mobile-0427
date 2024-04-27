using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    private FarmManager farmManager;
    private CropSO crop;
    
    private bool isPlanted = false;
    public SpriteRenderer plant;    // crop
    // boxcollider2d

    private int currentStage = 0;
    private float timer;

    private void Start()
    {
        farmManager = FindObjectOfType<FarmManager>();
        plant.gameObject.SetActive(false);
    }

    private void OnMouseDown()  //
    {
        if (isPlanted)
        {
            if (currentStage == crop.plantStagesSprites.Length - 1)
            {
                Harvest();
            }
            else
            {
                Debug.Log("Plant is not ready yet");
            }
        }
        else if (farmManager.isPlanting)
        {
            Plant(farmManager.selectedCrop);
        }
    }
    
    private void Update()
    {
        if (isPlanted)
        {
            timer -= Time.deltaTime;

            if (timer <= 0 && currentStage < crop.plantStagesSprites.Length - 1)
            {
                timer = crop.timeBtwStages;
                currentStage++;
                UpdatePlant();
            }
        }
    }
    
    private void Plant(CropSO newCrop)
    {
        crop = newCrop;
        isPlanted = true;
        currentStage = 0;
        UpdatePlant();
        timer = crop.timeBtwStages;
        plant.gameObject.SetActive(true);
    }

    private void UpdatePlant()
    {
        plant.sprite = crop.plantStagesSprites[currentStage];
    }

    private void Harvest()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }

    
}
