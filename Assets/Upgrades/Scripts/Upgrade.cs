using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public float fallSpeed = 2.0f; // Prędkość opadania

    void Update()
    {
        // Ruch w dół
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BallDestroyer"))
        {
            Destroy(gameObject);
        }
        // Dodatkowa logika (opcjonalna), np. co się dzieje po dotknięciu gracza
        if (collision.gameObject.CompareTag("Player"))
        {
            ApplyUpgrade(); // Funkcja aplikująca efekt upgradu
            Destroy(gameObject); // Zniszczenie upgradu po zebraniu
        }
    }

    // Dodaj słowo kluczowe 'virtual'
    protected virtual void ApplyUpgrade()
    {
        // Domyślna logika upgradu
        Debug.Log("Upgrade collected!");
    }
}
