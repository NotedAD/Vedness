using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Добавить анимацию удара, проверку что топором делается удар
    public float axeRange = 1.5f; // дистанция, на которой персонаж может рубить дерево
    public LayerMask treeLayer; // слой, на котором находятся деревья
    public Transform axeTransform; // позиция топора

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // предполагаем, что удар происходит при нажатии пробела
        {
            RaycastHit2D hit = Physics2D.Raycast(axeTransform.position, Vector2.right, axeRange, treeLayer.value);
            
            if (hit.collider != null)
            {
                TreeScript tree = hit.collider.GetComponent<TreeScript>();
                if (tree != null)
                {
                    tree.ChopTree();
                }
            }
        }
    }
}
