using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSlotsManager : MonoBehaviour
{
    public static QuickSlotsManager Instance { get; private set; }

    public int quickSlotCount = 5;
    public GameObject quickSlotPrefab;
    public Transform quickSlotsParent;

    private List<QuickSlot> quickSlots = new List<QuickSlot>();

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

        InitializeQuickSlots();
    }

    void InitializeQuickSlots()
    {
        for (int i = 0; i < quickSlotCount; i++)
        {
            GameObject slotObj = Instantiate(quickSlotPrefab, quickSlotsParent);
            QuickSlot slot = slotObj.GetComponent<QuickSlot>();
            quickSlots.Add(slot);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) QuickSlotsManager.Instance.UseQuickSlot(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) QuickSlotsManager.Instance.UseQuickSlot(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) QuickSlotsManager.Instance.UseQuickSlot(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) QuickSlotsManager.Instance.UseQuickSlot(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) QuickSlotsManager.Instance.UseQuickSlot(4);
    }
    public void UseQuickSlot(int index)
    {
        if (index >= 0 && index < quickSlots.Count)
        {
            quickSlots[index].UseItem();
        }
    }
}
