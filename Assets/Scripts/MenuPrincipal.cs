
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject panelPrincipal;
    [SerializeField] private GameObject panelControles;
    [SerializeField] private string escenaJuego = "NivelPlataformas";

    void Start()
    {
        Time.timeScale = 1f;

        panelPrincipal.SetActive(true);
        panelControles.SetActive(false);
    }

    public void Jugar()
    {
        SceneManager.LoadScene(escenaJuego);
    }

    public void AbrirControles()
    {
        panelPrincipal.SetActive(false);
        panelControles.SetActive(true);
    }

    public void CerrarControles()
    {
        panelControles.SetActive(false);
        panelPrincipal.SetActive(true);
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Juego cerrado");
    }
}
