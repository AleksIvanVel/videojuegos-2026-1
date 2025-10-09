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

    public string[] dialogosIniciales;       // Antes de dar misión
    public string[] dialogosMisionActiva;    // Misión en curso
    public string[] dialogosMisionCompletada;// Misión completada
    public string[] dialogosSinMision;       // NPC sin misión

    private bool jugadorCerca = false;
    private bool dialogoActivo = false;

    [Header("Misiones")]
    public bool tieneMision = false;        // Si este NPC entrega misión
    private bool debeActivarMision = false; // Bandera para activar misión en próximo diálogo
    public string misionId;                 // ID de la misión
    private Mision mision;

    [Header("Sonidos")]
    public AudioClip InicioDialogo;
    public AudioClip SigDialogo;

    private int indiceDialogo = 0;

    private Inventario inventario;

    void Start()
    {
        panelDialogo.SetActive(false);
        indicadorInteraccion.SetActive(false);

        inventario = FindObjectOfType<Inventario>();
    }

    void Update()
    {
        // Obtener misión si aún no se ha asignado
        if (tieneMision && mision == null)
        {
            mision = MisionManager.instance.ObtenerMisionPorId(misionId);

            if (mision != null && mision.EstaCompletada)
            {
                indicadorInteraccion.SetActive(false);
            }
        }

        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            GestionarDialogo();

            if (!dialogoActivo)
                AudioManager.instance.PlaySFX(InicioDialogo);
            else
                AudioManager.instance.PlaySFX(SigDialogo);
        }

    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            jugadorCerca = true;
            indicadorInteraccion.SetActive(true);

            Debug.Log("Jugador cerca del NPC: " + gameObject.name + ", tieneMision=" + tieneMision);
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            jugadorCerca = false;
            indicadorInteraccion.SetActive(false);
            CerrarDialogo();
        }
    }

    private void GestionarDialogo()
    {
        dialogoActivo = true;
        panelDialogo.SetActive(true);
        indicadorInteraccion.SetActive(false);

        if (debeActivarMision)
        {
            ActivarMision();
            indiceDialogo = 0;
            debeActivarMision = false;
        }

        string[] dialogosAMostrar = dialogosSinMision;

        if (tieneMision && mision != null)
        {
            if (!mision.EstaActiva && !mision.EstaCompletada)
            {
                dialogosAMostrar = dialogosIniciales;

                if (indiceDialogo >= dialogosIniciales.Length)
                {
                    // No activamos de inmediato, esperamos próximo input
                    debeActivarMision = true;
                }
            }
            else if (mision.EstaActiva && !mision.EstaCompletada)
            {
                dialogosAMostrar = dialogosMisionActiva;
                if (TieneObjetosRequeridos())
                {
                    CompletarMision();
                    dialogosAMostrar = dialogosMisionCompletada;
                    indiceDialogo = 0;
                }
            }
            else if (mision.EstaCompletada)
            {
                dialogosAMostrar = dialogosMisionCompletada;
            }
        }

        MostrarDialogos(dialogosAMostrar);
    }

    private void MostrarDialogos(string[] dialogos)
    {
        if (dialogos == null || dialogos.Length == 0) return;

        if (indiceDialogo < dialogos.Length)
        {
            textoDelDialogo.text = dialogos[indiceDialogo];
            indiceDialogo++;
        }
        else
        {
            indiceDialogo = 0;
            CerrarDialogo();
        }
    }

    private void ActivarMision()
    {
        if (mision != null)
        {
            mision.EstaActiva = true;
            Debug.Log("Misión activada: " + mision.misionNombre);
        }
    }

    private bool TieneObjetosRequeridos()
    {
        if (mision == null || inventario == null) return false;

        switch (mision.tipoMision)
        {
            case TipoMision.Recoleccion:
                return inventario.GetCantidadItem(mision.objetivo) >= mision.cantidadRequerida;

            case TipoMision.Eliminacion:
                return mision.cantidadActual >= mision.cantidadRequerida;

            default:
                return false;
        }
    }


    private void CompletarMision()
    {

        if (mision == null) return;

        // Si es de recolección, restar ítems
        if (mision.tipoMision == TipoMision.Recoleccion)
        {
            inventario.RestarItem(mision.objetivo, mision.cantidadRequerida);
        }

        // Dar la recompensa
        for (int i = 0; i < mision.cantidadRecompenza; i++)
        {
            Coleccionables.objColeccionables = mision.recompenza;
            inventario.EscribeEnArreglo();
        }

        mision.EstaActiva = false;
        mision.EstaCompletada = true;
        MisionManager.instance.CompletarMision(mision.misionId);
        Debug.Log("Misión completada: " + mision.misionNombre);
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