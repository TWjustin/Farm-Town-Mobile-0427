using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crop", menuName = "Items/Crop")]
public class CropSO : ItemSO
{
    public Sprite[] plantStagesSprites;
    public float timeBtwStages;
}
