
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private string escenaNivel = "NivelPlataformas";
    [SerializeField] private string escenaMenu = "MenuPrincipal";

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void Reintentar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(escenaNivel);
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(escenaMenu);
    }

    public void Salir()
    {
        Debug.Log("Juego cerrado");
        Application.Quit();
    }
}
