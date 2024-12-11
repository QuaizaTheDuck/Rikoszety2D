using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10f; // Prędkość piłki (początkowa)
    private Rigidbody2D rb;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ballParent;
    [SerializeField] private Player playerScript; // Referencja do skryptu gracza
    private bool isAttached = true; // Czy piłka jest przyczepiona do paletki

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // ustaw parenta na Balls
        if (ballParent == null)
        {
            ballParent = GameObject.FindWithTag("Balls");
        }
        // Znajdz obiekt gracza
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                playerScript = player.GetComponent<Player>(); // Pobierz skrypt gracza
            }
        }
    }

    void Update()
    {
        Debug.Log(rb.velocity.normalized);
        // Jeśli piłka jest przyczepiona, podąża za paletką gracza
        if (isAttached)
        {
            Vector3 newPosition = player.transform.position;
            newPosition.y += 1f; // Przesuń piłkę nad paletkę
            transform.position = newPosition;

            // Sprawdź, czy gracz nacisnął strzałkę w górę
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                LaunchBall();
            }
        }
    }

    void LaunchBall()
    {
        isAttached = false; // Uwolnij piłkę
        // Użyj prędkości gracza do ustalenia prędkości piłki
        rb.velocity = new Vector2(0, 1).normalized * playerScript.BallSpeed; // Wystrzel piłkę w górę, z prędkością zależną od gracza
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BallDestroyer"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            HandlePlayerCollision(collision);
        }
        else
        {
            NormalizeBallVelocity();
        }
    }

    void HandlePlayerCollision(Collision2D collision)
    {
        float paddleX = collision.transform.position.x;
        float ballX = transform.position.x;
        float offset = ballX - paddleX;

        float paddleWidth = collision.collider.bounds.size.x;
        float normalizedOffset = Mathf.Clamp(offset / (paddleWidth / 2), -1f, 1f);

        float bounceAngle = normalizedOffset * 75f;
        float angleRad = bounceAngle * Mathf.Deg2Rad;
        Vector2 newDirection = new Vector2(Mathf.Sin(angleRad), Mathf.Cos(angleRad)).normalized;

        rb.velocity = newDirection * playerScript.BallSpeed; // Użyj prędkości gracza do zmiany prędkości piłki
    }

    void NormalizeBallVelocity()
    {
        rb.velocity = rb.velocity.normalized * playerScript.BallSpeed; // Użyj prędkości gracza

        if (Mathf.Abs(rb.velocity.y) < 0.3f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y > 0 ? 0.3f : -0.3f).normalized * playerScript.BallSpeed;
        }
    }

    public void MultiplyBalls()
    {
        for (int i = 0; i < 2; i++) // Mnożenie o 2 dodatkowe piłki
        {
            // Utwórz nową piłkę w tej samej pozycji co oryginalna piłka
            GameObject newBall = Instantiate(gameObject, transform.position, Quaternion.identity);
            Rigidbody2D newRb = newBall.GetComponent<Rigidbody2D>();

            // Ustawienie piłki jako dziecko gracza
            newBall.transform.SetParent(ballParent.transform);
            // Skopiowanie skali z oryginalnej piłki
            newBall.transform.localScale = transform.localScale;

            // Losowanie kąta i kierunku piłki
            float angle = Random.Range(-180f, 180f); // Losowy kąt w poziomie
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;

            // Ustawienie prędkości piłki
            newRb.velocity = direction * playerScript.BallSpeed;

            // Wyłącz przypisanie do paletki gracza
            Ball newBallScript = newBall.GetComponent<Ball>();
            newBallScript.isAttached = false;
        }
    }
}
