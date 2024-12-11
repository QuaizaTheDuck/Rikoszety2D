using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBallMultiply : Upgrade
{

    [SerializeField] private GameObject UpgradeTarget; // Obiekt, którego rozmiar zmieniamy

    void Start()
    {
        if (UpgradeTarget == null)
        {
            // Przypisanie obiektu gracza, jeśli UpgradeTarget nie zostało ustawione w Inspectorze
            UpgradeTarget = GameObject.FindWithTag("Balls");
        }
    }
    protected override void ApplyUpgrade()
    {
        // Pobierz wszystkie obecne piłki w dzieciach gracza
        List<Ball> currentBalls = new List<Ball>();
        foreach (Transform child in UpgradeTarget.transform)
        {
            Ball ballScript = child.GetComponent<Ball>();
            if (ballScript != null)
            {
                currentBalls.Add(ballScript); // Dodaj piłkę do listy
            }
        }

        // Teraz dla każdej piłki wywołaj MultiplyBalls
        foreach (Ball ball in currentBalls)
        {
            ball.MultiplyBalls(); // Mnożenie piłek
        }
    }
}
