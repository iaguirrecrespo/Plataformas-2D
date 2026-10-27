
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] public float velocidadX = 5.0f;
    [SerializeField] public float fuerzaSalto = 10.0f;

    private float movimientoX = 0f;
    private Rigidbody2D rb;
    private bool tocandosuelo = false;

    [Header("Monedas")]
    public int monedas = 0;
    [SerializeField] private TextMeshProUGUI textoMonedas;

    [Header("Tiempo")]
    [SerializeField] private TextMeshProUGUI textoTiempo;
    private float tiempo = 0f;

    [Header("Vidas")]
    [SerializeField] private int vidasMaximas = 3;
    private int vidasActuales;

    private Vector2 posicionInicial;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Guardar la posición inicial del jugador.
        posicionInicial = transform.position;

        // Inicializar las vidas.
        vidasActuales = vidasMaximas;

        // Actualizar las monedas en pantalla.
        ActualizarMonedas();

        // Reiniciar el contador de tiempo.
        tiempo = 0f;
    }

    private void Update()
    {
        // Movimiento horizontal.
        movimientoX = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(
            movimientoX * velocidadX,
            rb.linearVelocity.y
        );

        // Saltar con la barra espaciadora.
        if (Input.GetKeyDown(KeyCode.Space) && tocandosuelo)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                fuerzaSalto
            );

            tocandosuelo = false;
        }

        // Contador de tiempo.
        tiempo += Time.deltaTime;

        if (textoTiempo != null)
        {
            textoTiempo.text = "Tiempo: " + Mathf.FloorToInt(tiempo);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo") ||
            collision.gameObject.CompareTag("Plataforma"))
        {
            tocandosuelo = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo") ||
            collision.gameObject.CompareTag("Plataforma"))
        {
            tocandosuelo = false;
        }
    }

    // Sumar una moneda al recogerla.
    public void SumarMoneda()
    {
        monedas++;
        ActualizarMonedas();

        ZonaMeta zonaMeta = FindFirstObjectByType<ZonaMeta>();

        if (zonaMeta != null)
        {
            zonaMeta.ComprobarMonedas(monedas);
        }
    }

    private void ActualizarMonedas()
    {
        if (textoMonedas != null)
        {
            textoMonedas.text = "Monedas: " + monedas;
        }
    }

    // Perder una vida al tocar un peligro.
    public void RecibirDano()
    {
        if (vidasActuales <= 0)
        {
            return;
        }

        vidasActuales--;

        Debug.Log("Vidas restantes: " + vidasActuales);

        if (vidasActuales <= 0)
        {
            GameOver();
        }
        else
        {
            // Reaparecer en el punto inicial.
            transform.position = posicionInicial;
            rb.linearVelocity = Vector2.zero;
            tocandosuelo = false;
        }
    }

    // Cargar la escena de derrota.
    private void GameOver()
    {
        rb.linearVelocity = Vector2.zero;
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameOver");
    }
}
