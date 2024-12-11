using UnityEngine;

public class GalaxyBrick : Brick
{
    [SerializeField] private int numberOfOrbitingBricks = 3; // Liczba orbitujących cegieł
    [SerializeField] private GameObject orbitingBrickPrefab; // Prefab OrbitingBrick


    void Start()
    {

        GenerateOrbitingBricks();
    }


    void GenerateOrbitingBricks()
    {
        if (numberOfOrbitingBricks <= 1)
        {
            Debug.LogWarning("Number of orbiting bricks should be greater than 1 for orbiting effect to be visible.");
            return;
        }

        float angleBetweenOrbitingBricks = 360f / numberOfOrbitingBricks; // Obliczanie kąta odstępu

        float startAngle = 0f;

        // Tworzenie orbitujących cegieł w równych odstępach
        for (int i = 0; i < numberOfOrbitingBricks; i++)
        {
            // Obliczanie początkowego kąta dla każdej cegły
            float orbitAngle = startAngle + i * angleBetweenOrbitingBricks;

            // Tworzymy orbitującą cegłę
            GameObject orbitingBrick = Instantiate(orbitingBrickPrefab, transform.position, Quaternion.identity);
            // Ustawiamy GalaxyBrick jako parenta nowej orbitującej cegły
            orbitingBrick.transform.SetParent(gameObject.transform);

            // Ustawienie początkowego kąta dla każdej cegły
            OrbitingBrick orbitingBrickScript = orbitingBrick.GetComponent<OrbitingBrick>();
            orbitingBrickScript.initialOrbitAngle = orbitAngle;
        }
    }
}
