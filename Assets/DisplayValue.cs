using TMPro;  // Dodajemy przestrzeń nazw TextMeshPro
using UnityEngine;

public class DisplayValue : MonoBehaviour
{
    // Referencja do komponentu TextMeshPro
    public TextMeshProUGUI textMeshPro;

    public void UpdateText(string text)
    {
        // Zaktualizuj tekst w TextMeshPro z wartością selectedLevel
        textMeshPro.text = text;
    }
}
