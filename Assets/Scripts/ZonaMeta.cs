
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ZonaMeta : MonoBehaviour
{
    [SerializeField] private string escenaFinal = "FinNivel";
    [SerializeField] private int monedasNecesarias = 5;
    [SerializeField] private TextMeshProUGUI textoAviso;

    private bool puertaAbierta = false;
    private bool jugadorEnZona = false;
    private PlayerController jugador;

    private void Start()
    {
        if (textoAviso != null)
        {
            textoAviso.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        jugador = collision.GetComponent<PlayerController>();
        jugadorEnZona = true;

        if (jugador == null)
            return;

        if (puertaAbierta || jugador.monedas >= monedasNecesarias)
        {
            CargarEscenaFinal();
        }
        else
        {
            ComprobarMonedas(jugador.monedas);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorEnZona = false;

            if (textoAviso != null)
                textoAviso.gameObject.SetActive(false);
        }
    }

    public void ComprobarMonedas(int monedas)
    {
        if (monedas >= monedasNecesarias)
        {
            puertaAbierta = true;

            if (textoAviso != null)
                textoAviso.gameObject.SetActive(false);

            if (jugadorEnZona)
                CargarEscenaFinal();
        }
        else if (jugadorEnZona && textoAviso != null)
        {
            textoAviso.text = "Necesitas " + monedasNecesarias
                + " monedas. Te faltan: "
                + (monedasNecesarias - monedas);

            textoAviso.gameObject.SetActive(true);
        }
    }

    private void CargarEscenaFinal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(escenaFinal);
    }
}
