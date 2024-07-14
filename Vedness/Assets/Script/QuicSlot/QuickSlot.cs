using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class QuickSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
public Item item;
    public Image iconImage;
    public Text countText; // Добавим текст для отображения количества

    private int itemCount;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 startPosition;
    private Canvas canvas;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void AssignItem(Item newItem, int count)
    {
        item = newItem;
        itemCount = count;
        UpdateUI();

        // Добавим отладочные сообщения для проверки
        if (item != null)
        {
            Debug.Log($"Assigned item: {item.itemName} with count: {itemCount}");
        }
        else
        {
            Debug.LogWarning("Assigned item is null");
        }
    }

    private void UpdateUI()
    {
        if (iconImage == null)
        {
            Debug.LogError("IconImage или CountText не назначены в QuickSlot!");
            return;
        }

        if (item != null)
        {
            iconImage.sprite = item.itemIcon;
            iconImage.color = Color.white;
            // countText.text = itemCount > 1 ? itemCount.ToString() : "";
        }
        else
        {
            iconImage.sprite = null;
            iconImage.color = Color.white;
            // countText.text = "";
        }
    }

    public void UseItem()
    {
        if (item != null && !IsEmpty())
        {
            Debug.Log($"Использован предмет: {item.itemName}");
            // itemCount--;
            // if (itemCount <= 0)
            // {
            //     ClearSlot();
            // }
            // UpdateUI();
        }
    }
    public bool IsEmpty()
    {
        return item == null || itemCount <= 0;
    }
    public void ClearSlot()
    {
        item = null;
        itemCount = 0;
        UpdateUI();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!IsEmpty())
        {
            startPosition = rectTransform.anchoredPosition;
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!IsEmpty())
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        GameObject hitObject = eventData.pointerCurrentRaycast.gameObject;
        if (hitObject != null)
        {
            // Пробуем получить InventorySlot напрямую
            InventorySlot inventorySlot = hitObject.GetComponent<InventorySlot>();

            // Если не удалось получить InventorySlot, ищем его в родительских объектах
            if (inventorySlot == null)
            {
                inventorySlot = hitObject.GetComponentInParent<InventorySlot>();
            }

            if (inventorySlot != null)
            {
                // Логика перемещения предмета в инвентарь
                if (InventoryManager.Instance.AddItemToInventory(item, itemCount))
                {
                    ClearSlot();
                    // Debug.Log($"Предмет {item.itemName} успешно возвращен в инвентарь!");
                }
                else
                {
                    Debug.LogWarning("Не удалось вернуть предмет в инвентарь. Возможно, инвентарь полон.");
                }
            }
            else
            {
                Debug.Log("Hit object is not an InventorySlot or its child.");
            }
        }
        else
        {
            Debug.Log("No object hit by raycast.");
        }

        // Возвращаем на исходную позицию в любом случае
        rectTransform.anchoredPosition = startPosition;
    }
}
