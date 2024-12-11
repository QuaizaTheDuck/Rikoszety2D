using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadLevelBTN : MonoBehaviour
{
    [SerializeField] private GameObject BallPrefab;
    [SerializeField] private GameObject ballParent;
    [SerializeField] private GameObject LevelMenager;

    private LoadLevel LevelMenagerScript;
    [SerializeField] private GameObject SelectedLevelText;
    private DisplayValue SelectedLevelScript;
    [SerializeField] private GameObject UI;

    void Start()
    {
        LevelMenagerScript = LevelMenager.GetComponent<LoadLevel>(); // Pobierz skrypt gracza
        SelectedLevelScript = SelectedLevelText.GetComponent<DisplayValue>();
        SelectedLevelScript.UpdateText(LevelMenagerScript.selectedLevel + "/" + LevelMenagerScript.LevelPrefabs.Count);
    }
    public void ResetButton()
    {
        // Wypisuje tekst w konsoli
        Debug.Log("Przycisk został naciśnięty!");

        GameObject newBall = Instantiate(BallPrefab, transform.position, Quaternion.identity);
        newBall.transform.SetParent(ballParent.transform);
        UI.SetActive(false);
        LevelMenagerScript.LoadSelectedLevel();


    }
    public void selectNextLevel()
    {
        if (LevelMenagerScript.selectedLevel < LevelMenagerScript.LevelPrefabs.Count)
        {
            LevelMenagerScript.selectedLevel++;
            SelectedLevelScript.UpdateText(LevelMenagerScript.selectedLevel + "/" + LevelMenagerScript.LevelPrefabs.Count);
        }
    }

    public void selectPreviousLevel()
    {
        if (LevelMenagerScript.selectedLevel > 1)
        {
            LevelMenagerScript.selectedLevel--;
            SelectedLevelScript.UpdateText(LevelMenagerScript.selectedLevel + "/" + LevelMenagerScript.LevelPrefabs.Count);
        }

    }
}
