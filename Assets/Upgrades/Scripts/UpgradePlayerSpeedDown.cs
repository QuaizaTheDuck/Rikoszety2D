using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePlayerSpeedDown : Upgrade
{
    [SerializeField] private GameObject UpgradeTarget; // Obiekt, którego rozmiar zmieniamy
    [SerializeField] private Player playerScript; // Referencja do skryptu gracza
    [SerializeField] private float scaleMod = 5f;


    void Start()
    {
        if (UpgradeTarget == null)
        {
            // Przypisanie obiektu gracza, jeśli UpgradeTarget nie zostało ustawione w Inspectorze
            UpgradeTarget = GameObject.FindWithTag("Player");
            if (UpgradeTarget != null)
            {
                playerScript = UpgradeTarget.GetComponent<Player>();
            }
        }
    }
    protected override void ApplyUpgrade()
    {
        if (playerScript != null) // Sprawdź, czy playerScript został przypisany
        {
            playerScript.PlayerSpeed -= scaleMod; // Zwiększ prędkość piłki
        }
    }

}
