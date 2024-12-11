using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    void Update()
    {
        // Sprawdzenie, czy obiekt ma dzieci
        if (transform.childCount == 0)
        {
            TriggerGameOver();
        }
    }

    private void TriggerGameOver()
    {
        UI.SetActive(true);
        Debug.LogError("Game over!");

    }
}
