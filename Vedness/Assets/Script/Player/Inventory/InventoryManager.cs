using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    public int slotCount = 25;
    public GameObject slotPrefab;

    public GridLayoutGroup gridLayoutGroup;
    public CanvasGroup canvasGroup;

    private List<InventorySlot> slots = new List<InventorySlot>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        canvasGroup = GetComponent<CanvasGroup>();

        if (gridLayoutGroup == null)
        {
            Debug.LogError("GridLayoutGroup не найден на текущем объекте!");
            return;
        }

        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup не найден на текущем объекте!");
            return;
        }

        for (int i = 0; i < slotCount; i++)
        {
            GameObject slotObj = Instantiate(slotPrefab, transform);
            InventorySlot slot = slotObj.GetComponent<InventorySlot>();
            slots.Add(slot);
        }

        CloseInventory();
    }

    public void AddItem(Item item)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.IsEmpty())
            {
                slot.AddItem(item); // Ошибка возможна здесь, если slot не был правильно инициализирован
                return;
            }
        }
    }

    public void OpenInventory()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void CloseInventory()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void ToggleInventory()
    {
        if (canvasGroup.alpha > 0)
        {
            CloseInventory();
        }
        else
        {
            OpenInventory();
        }
    }

    public bool AddItemToInventory(Item item, int count)
    {
        // foreach (InventorySlot slot in slots)
        // {
        //     if (slot.CanAddItem(item, count))
        //     {
        //         int remainder = slot.AddItemToStack(item, count);
        //         count = remainder;
        //         if (count == 0)
        //         {
        //             Debug.Log("Предмет успешно добавлен к существующему стеку.");
        //             return true;
        //         }
        //     }
        // }

        if (count > 0)
        {
            InventorySlot emptySlot = slots.Find(s => s.IsEmpty());
            if (emptySlot != null)
            {
                emptySlot.AddItem(item, count);
                return true;
            }
        }

        Debug.LogWarning("Не удалось добавить предмет в инвентарь. Инвентарь полон.");
        return false;
    }
}
