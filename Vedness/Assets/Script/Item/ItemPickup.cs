using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item; // Переменная для хранения информации о предмете

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryManager.Instance.AddItem(item);
            Destroy(gameObject); // Уничтожить предмет после подбора
        }
    }
}
