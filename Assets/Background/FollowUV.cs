using UnityEngine;
using System.Collections;

public class FollowUV : MonoBehaviour
{
    [SerializeField] private float parralax = 2f;
    [SerializeField] private Transform followTarget; // Obiekt do śledzenia (piłka)
    [SerializeField] private Transform player;       // Gracz, który posiada piłki

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player object is not assigned!");
            return;
        }
    }

    void Update()
    {
        // Jeśli followTarget jest null, znajdź nową piłkę
        if (followTarget == null)
        {
            FindFollowTarget();
            if (followTarget == null)
                return; // Jeśli nadal brak piłki, nie kontynuuj
        }

        // Aktualizuj offset tekstury na podstawie pozycji piłki
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;

        offset.x = followTarget.transform.position.x / followTarget.transform.localScale.x / parralax * 0.1f;
        offset.y = followTarget.transform.position.y / followTarget.transform.localScale.y / parralax;

        mat.mainTextureOffset = offset;
    }

    private void FindFollowTarget()
    {
        // Szukaj pierwszego dziecka gracza z tagiem "Ball"
        foreach (Transform child in player)
        {
            if (child.CompareTag("Ball"))
            {
                followTarget = child; // Przypisz nową piłkę jako cel
                Debug.Log("New followTarget assigned: " + followTarget.name);
                return;
            }
        }

        Debug.LogWarning("No ball found to follow!");
    }
}
