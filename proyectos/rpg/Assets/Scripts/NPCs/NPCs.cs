using TMPro;
using UnityEngine;

public class NPCs : MonoBehaviour
{
    [Header("UI del Diálogo")]
    public GameObject panelDialogo;
    public TextMeshProUGUI textoDelDialogo;
    public GameObject indicadorInteraccion;

    [Header("Contenido del Diálogo")]
    [TextArea(3, 10)]

    public string[] dialogos;

    public int numVisitas = 0;
    private bool jugadorCerca = false;
    private bool dialogoActivo = false;

    void Start()
    {
        panelDialogo.SetActive(false);
        indicadorInteraccion.SetActive(false);
    }

    void Update()
    {
        // Si el jugador está cerca y presiona la tecla "E" (puedes cambiarla)
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            // Si el diálogo no estaba activo, lo iniciamos.
            if (!dialogoActivo)
            {
                IniciarDialogo();
            }
            // Si ya estaba activo, pasamos a la siguiente línea o lo cerramos.
            else
            {
                SiguienteDialogo();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        // Detectamos si el jugador entra en el área de interacción.
        if (obj.CompareTag("Player"))
        {
            jugadorCerca = true;
            indicadorInteraccion.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        // Si el jugador se va, cerramos el diálogo y reseteamos el estado.
        if (obj.CompareTag("Player"))
        {
            jugadorCerca = false;
            indicadorInteraccion.SetActive(false);
            CerrarDialogo();
        }
    }

    private void IniciarDialogo()
    {
        dialogoActivo = true;
        panelDialogo.SetActive(true);
        indicadorInteraccion.SetActive(false); 
        numVisitas = 0; // Siempre empezamos desde la primera línea.
        textoDelDialogo.text = dialogos[numVisitas];
    }

    private void SiguienteDialogo()
    {
        numVisitas++; // Pasamos a la siguiente línea de diálogo.

        // Si aún quedan diálogos por mostrar...
        if (numVisitas < dialogos.Length)
        {
            textoDelDialogo.text = dialogos[numVisitas];
        }
        else
        {
            // Si ya no hay más, cerramos la ventana de diálogo.
            CerrarDialogo();
        }
    }

    private void CerrarDialogo()
    {
        dialogoActivo = false;
        panelDialogo.SetActive(false);

        if (jugadorCerca)
        {
            indicadorInteraccion.SetActive(true);
        }
    }
}