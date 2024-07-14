using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.Tab; // Клавиша для открытия/закрытия инвентаря
    private InventoryManager inventoryUI;
    void Start()
    {
        inventoryUI = GetComponent<InventoryManager>();
        if (inventoryUI == null)
        {
            Debug.LogError("InventoryUI не найден на текущем объекте!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            inventoryUI.ToggleInventory();
        }
    }
}
