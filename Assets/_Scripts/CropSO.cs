using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crop", menuName = "Crop")]
public class CropSO : ScriptableObject
{
    public string cropName;
    public Sprite[] plantStagesSprites;
    public float timeBtwStages;
    public int price;
    public Sprite icon;
}
