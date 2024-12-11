using UnityEngine;

public class OrbitingBrick : Brick
{
    [SerializeField] private float orbitRadius = 2f; // Docelowy promień orbity
    [SerializeField] private float orbitSpeed = 1f; // Prędkość obrotu (w radianach na sekundę)
    [SerializeField] private bool isClockwise = true; // Kierunek orbity
    [SerializeField] public float initialOrbitAngle = 0f; // Początkowy kąt orbity w stopniach

    private Vector2 orbitCenter; // Centrum orbity (miejsce stworzenia bricka)
    private float currentRadius = 0f; // Aktualny promień orbity
    private float radiusIncreaseSpeed; // Prędkość powiększania promienia
    private float orbitAngle = 0f; // Aktualny kąt orbity w radianach

    void Start()
    {
        // Ustawienie centrum orbity na aktualną pozycję bricka
        orbitCenter = transform.position;

        // Obliczenie prędkości zwiększania promienia na podstawie 200% prędkości orbitowania
        radiusIncreaseSpeed = (orbitSpeed * orbitRadius * 2f) / (2 * Mathf.PI); // 200% prędkości orbitowania

        // Ustawienie początkowego kąta orbity na podstawie wartości w stopniach
        orbitAngle = initialOrbitAngle * Mathf.Deg2Rad;
    }

    void Update()
    {
        // Zwiększanie aktualnego promienia, aż osiągnie docelowy promień
        if (currentRadius < orbitRadius)
        {
            currentRadius += radiusIncreaseSpeed * Time.deltaTime;
            currentRadius = Mathf.Min(currentRadius, orbitRadius); // Upewnij się, że nie przekracza docelowego promienia
        }

        // Aktualizacja kąta orbity
        float angleDelta = orbitSpeed * Time.deltaTime * (isClockwise ? -1 : 1);
        orbitAngle += angleDelta;

        // Oblicz nową pozycję bricka na orbicie
        float x = orbitCenter.x + Mathf.Cos(orbitAngle) * currentRadius;
        float y = orbitCenter.y + Mathf.Sin(orbitAngle) * currentRadius;
        transform.position = new Vector2(x, y);
    }
}