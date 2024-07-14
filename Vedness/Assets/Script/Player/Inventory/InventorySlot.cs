using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public Image icon;
    public Text countText; // Текст для отображения количества предметов в стаке

    private Item item;
     private int itemCount;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    private Vector2 startPosition;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void AddItem(Item newItem, int count = 1)
    {
        if (item == null || item.itemName != newItem.itemName)
        {
            // Новый предмет в пустой слот или другой тип предмета
            item = newItem;
            itemCount = count;
        }
        else
        {
            // Стакирование существующего предмета
            itemCount = Mathf.Min(itemCount + count, item.maxStackCount);
        }

        UpdateUI();
    }

    public bool CanAddItem(Item newItem, int count = 1)
    {
        if (item == null) return true;
        if (item.itemName != newItem.itemName) return false;
        return itemCount + count <= item.maxStackCount;
    }

    public int AddItemToStack(Item newItem, int count)
    {
        if (newItem == null)
        {
            Debug.LogError("item is null in AddItemToStack");
            return count; // Возвращаем количество, так как стек не может быть обновлен
        }

        int spaceLeft = newItem.maxStackCount - itemCount;
        int amountToAdd = Mathf.Min(count, spaceLeft);
        itemCount += amountToAdd;
        UpdateUI();
        return count - amountToAdd; // Возвращаем остаток, который не поместился в стак
    }

    public bool IsEmpty()
    {
        return item == null;
    }

    public void ClearSlot()
    {
        item = null;
        itemCount = 0;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (item != null)
        {
            icon.sprite = item.itemIcon;
            countText.text = itemCount > 1 ? itemCount.ToString() : "";
        }
        else
        {
            icon.sprite = null;
            countText.text = "";
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!IsEmpty())
        {
            startPosition = rectTransform.anchoredPosition;
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }        
        else
        {
            eventData.pointerDrag = null; 
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

        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            InventorySlot targetSlot = eventData.pointerCurrentRaycast.gameObject.GetComponent<InventorySlot>();
            if (targetSlot != null && targetSlot != this)
            {
                // Логика перемещения предмета между слотами
                SwapItems(targetSlot);
            }
            else
            {
                QuickSlot quickSlot = eventData.pointerCurrentRaycast.gameObject.GetComponent<QuickSlot>();
                if (quickSlot != null)
                {
                    // Перенос предмета в быстрый слот
                    quickSlot.AssignItem(item, itemCount);
                    ClearSlot();
                }
                else
                {
                    // Возврат на исходную позицию
                    rectTransform.anchoredPosition = startPosition;
                }
            }
        }
        else
        {
            rectTransform.anchoredPosition = startPosition;
        }
    }

    private void SwapItems(InventorySlot targetSlot)
    {
        Item tempItem = targetSlot.item;
        int tempCount = targetSlot.itemCount;

        targetSlot.SetItem(item, itemCount);
        SetItem(tempItem, tempCount);
    }

    public void SetItem(Item newItem, int count)
    {
        item = newItem;
        itemCount = count;
        UpdateUI();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            // Обработка правого клика (например, использование предмета)
            UseItem();
        }
    }

    private void UseItem()
    {
        if (item != null)
        {
            // Здесь логика использования предмета
            Debug.Log($"Использован предмет: {item.itemName}");
            itemCount--;
            if (itemCount <= 0)
            {
                ClearSlot();
            }
            else
            {
                UpdateUI();
            }
        }
    }

    // Геттеры для доступа к приватным полям
    public Item GetItem() => item;
    public int GetItemCount() => itemCount;
}
