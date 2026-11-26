using UnityEngine;

public class CardPunchDetector : MonoBehaviour
{
    [SerializeField] Card card;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Poincon")) return;

        card.Punch(other.transform.position);
    }
}