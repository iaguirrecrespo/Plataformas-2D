
using UnityEngine;

public class Moneda : MonoBehaviour
{
    [SerializeField] private GameObject FX_Explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController jugador =
                collision.GetComponent<PlayerController>();

            if (jugador != null)
            {
                jugador.SumarMoneda();

                if (FX_Explosion != null)
                {
                    Instantiate(
                        FX_Explosion,
                        transform.position,
                        Quaternion.identity
                    );
                }

                Destroy(gameObject);
            }
        }
    }
}
