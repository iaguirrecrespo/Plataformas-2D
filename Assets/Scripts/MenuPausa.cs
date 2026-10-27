
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject panelPausa;
    [SerializeField] private string escenaMenu = "MenuPrincipal";

    private bool pausado = false;

    void Start()
    {
        Time.timeScale = 1f;
        panelPausa.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Pausar()
    {
        pausado = true;
        panelPausa.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Reanudar()
    {
        pausado = false;
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SalirAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(escenaMenu);
    }
}
