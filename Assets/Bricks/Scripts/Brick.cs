using UnityEngine;
using System.Collections.Generic;

public class Brick : MonoBehaviour
{
    [SerializeField] private List<GameObject> dropPrefabs; // Lista prefabów do upuszczenia
    [SerializeField][Range(0f, 1f)] private float dropChance = 1f; // Szansa na drop (1% domyślnie)


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            TryDropItem(); // Próba upuszczenia obiektu
            Destroy(gameObject); // Zniszczenie cegły

        }
    }

    void TryDropItem()
    {
        // Sprawdzenie szansy na drop
        if (Random.value <= dropChance)
        {
            DropItem();
        }
    }

    void DropItem()
    {
        if (dropPrefabs.Count > 0) // Sprawdzenie, czy lista prefabów nie jest pusta
        {
            // Wybór losowego prefabu z listy
            int randomIndex = Random.Range(0, dropPrefabs.Count);
            GameObject selectedPrefab = dropPrefabs[randomIndex];

            // Instancjonowanie prefabu w miejscu cegły
            Instantiate(selectedPrefab, transform.position, Quaternion.identity);
        }
    }
}
