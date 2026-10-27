
using UnityEngine;
using TMPro;

public class CartelInformativo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoAviso;

    private void Start()
    {
        textoAviso.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textoAviso.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textoAviso.gameObject.SetActive(false);
        }
    }
}
