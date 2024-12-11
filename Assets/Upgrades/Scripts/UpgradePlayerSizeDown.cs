using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpradePlayerSizeDown : Upgrade
{
    [SerializeField] private GameObject UpgradeTarget; // Obiekt, którego rozmiar zmieniamy
    [SerializeField] private float scaleMod = 1f;


    void Start()
    {
        if (UpgradeTarget == null)
        {
            // Przypisanie obiektu gracza, jeśli UpgradeTarget nie zostało ustawione w Inspectorze
            UpgradeTarget = GameObject.FindWithTag("Player");
        }
    }
    protected override void ApplyUpgrade()
    {
        // Sprawdź, czy UpgradeTarget jest przypisany
        if (UpgradeTarget != null)
        {
            Vector3 scale = UpgradeTarget.transform.localScale;
            scale.x -= scaleMod; // Powiększenie skali w osi X
            UpgradeTarget.transform.localScale = scale;

            Debug.Log("Scale upgraded for " + UpgradeTarget.name);
        }
        else
        {
            Debug.LogWarning("UpgradeTarget is not assigned!");
        }
    }
}
