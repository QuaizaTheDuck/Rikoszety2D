using UnityEngine;

public class DirectionalBrick : Brick
{
    [SerializeField] private bool canBeDestroyedFromTop = true; // Czy cegła może zostać zniszczona od góry
    [SerializeField] private bool canBeDestroyedFromBottom = false; // Czy cegła może zostać zniszczona od dołu
    [SerializeField] private bool canBeDestroyedFromLeft = false; // Czy cegła może zostać zniszczona od lewej
    [SerializeField] private bool canBeDestroyedFromRight = false; // Czy cegła może zostać zniszczona od prawej

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Sprawdzamy, czy kolizja była z piłką
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Obliczamy kierunek uderzenia piłki względem cegły
            Vector2 collisionDirection = collision.relativeVelocity.normalized;

            // Sprawdzamy, z której strony nastąpiło uderzenie
            if (canBeDestroyedFromBottom && collisionDirection.y > 0)  // Uderzenie z góry
            {
                Destroy(gameObject);
            }
            else if (canBeDestroyedFromTop && collisionDirection.y < 0)  // Uderzenie z dołu
            {
                Destroy(gameObject);
            }
            else if (canBeDestroyedFromLeft && collisionDirection.x < 0)  // Uderzenie z lewej
            {
                Destroy(gameObject);
            }
            else if (canBeDestroyedFromRight && collisionDirection.x > 0)  // Uderzenie z prawej
            {
                Destroy(gameObject);
            }
        }
    }



}
