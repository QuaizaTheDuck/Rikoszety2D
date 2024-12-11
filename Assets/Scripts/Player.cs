using UnityEngine;

public class Player : MonoBehaviour
{
    public float PlayerSpeed = 20f; // Zwiększ prędkość, jeśli potrzeba
    public float BallSpeed = 20f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Pobranie wejścia użytkownika
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // Użycie "Input.GetAxisRaw" dla ostrzejszej reakcji

        // Ustawienie prędkości (reset przed ruchem)
        rb.velocity = new Vector2(horizontalInput * PlayerSpeed, rb.velocity.y);
    }
}
