
using UnityEngine;

public class Peligro : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController jugador =
                collision.GetComponent<PlayerController>();

            if (jugador != null)
            {
                jugador.RecibirDano();
            }
        }
    }
}
