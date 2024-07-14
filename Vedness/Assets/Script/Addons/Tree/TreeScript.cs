using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    //Добавить анимацию
    public int hitsToChop = 3; // количество ударов для срубания дерева
    public GameObject logPrefab; // префаб бревна

    private int currentHits = 0;

    public void ChopTree()
    {
        currentHits++;

        if (currentHits >= hitsToChop)
        {
            SpawnLog();
            Destroy(gameObject); // уничтожаем дерево после рубки
        }
    }

    private void SpawnLog()
    {
        Instantiate(logPrefab, transform.position, Quaternion.identity);
    }
}
