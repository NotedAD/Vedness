using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite itemIcon;
    public int maxStackCount = 64; // Максимальное количество предметов в стаке
    public int count = 1; 
}
