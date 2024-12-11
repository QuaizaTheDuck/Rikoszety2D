using UnityEngine;

public class ZigzagBrick : Brick
{
    [SerializeField] private float moveRange = 5f; // Zakres ruchu
    [SerializeField] private float moveSpeed = 2f; // Prędkość ruchu
    [SerializeField] private bool moveHorizontally = true; // Ruch w poziomie (true) lub pionie (false)
    [SerializeField] private bool startMovingPositive = true; // Czy ruch zaczyna się w pozytywnym kierunku (prawo/góra)

    private Vector2 startPosition;
    private float moveDirection; // 1 oznacza ruch w przód, -1 w tył

    void Start()
    {
        startPosition = transform.position;

        // Ustawienie początkowego kierunku na podstawie startMovingPositive
        moveDirection = startMovingPositive ? 1f : -1f;
    }

    void Update()
    {
        float movement = moveSpeed * Time.deltaTime;

        if (moveHorizontally)
        {
            // Ruch w poziomie z zapętlaniem
            float newX = transform.position.x + movement * moveDirection;
            if (Mathf.Abs(newX - startPosition.x) > moveRange)
            {
                moveDirection *= -1f; // Zmiana kierunku
                newX = startPosition.x + moveRange * Mathf.Sign(newX - startPosition.x); // Zapętlany ruch
            }
            transform.position = new Vector2(newX, transform.position.y);
        }
        else
        {
            // Ruch w pionie z zapętlaniem
            float newY = transform.position.y + movement * moveDirection;
            if (Mathf.Abs(newY - startPosition.y) > moveRange)
            {
                moveDirection *= -1f; // Zmiana kierunku
                newY = startPosition.y + moveRange * Mathf.Sign(newY - startPosition.y); // Zapętlany ruch
            }
            transform.position = new Vector2(transform.position.x, newY);
        }
    }
}
