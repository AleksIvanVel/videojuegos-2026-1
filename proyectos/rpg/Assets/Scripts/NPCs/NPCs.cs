using TMPro;
using UnityEngine;

public class NPCs : MonoBehaviour
{
    [Header("UI del Diálogo")]
    public GameObject panelDialogo;
    public TextMeshProUGUI textoDelDialogo;
    public TextMeshProUGUI nombreNPC;
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
    public string misionId;                 // ID de la misión
    private Mision mision;

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

            if (dialogoActivo == false)
            {
                if (AudioManager.instance.IniciarDialogo != null)
                {
                    AudioSource.PlayClipAtPoint(AudioManager.instance.IniciarDialogo, transform.position);
                }
            }
            else
            {
                if (AudioManager.instance.SiguienteDialogo != null)
                {
                    AudioSource.PlayClipAtPoint(AudioManager.instance.SiguienteDialogo, transform.position);
                }
            }

            
        }

    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            jugadorCerca = true;
            indicadorInteraccion.SetActive(true);
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
        nombreNPC.text = gameObject.name;

        string[] dialogosAMostrar = dialogosSinMision;

        if (tieneMision && mision != null)
        {
            // Misión no activa ni completada 
            if (!mision.EstaActiva && !mision.EstaCompletada)
            {
                dialogosAMostrar = dialogosIniciales;

                // Activar misión solo cuando se terminen todos los diálogos iniciales
                if (indiceDialogo >= dialogosIniciales.Length)
                {
                    ActivarMision();
                    indiceDialogo = 0;

                    // Cambiar a los diálogos de misión activa inmediatamente
                    dialogosAMostrar = dialogosMisionActiva;
                }
            }
            // Misión activa y no completada
            else if (mision.EstaActiva && !mision.EstaCompletada)
            {
                dialogosAMostrar = dialogosMisionActiva;

                // Si se cumplen los objetivos, completar misión
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

                // Reiniciar misión
                //if (indiceDialogo >= dialogosMisionCompletada.Length)
                //{
                //    ReiniciarMision();
                //    dialogosAMostrar = dialogosIniciales;
                //    indiceDialogo = 0;
                //}
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
            MisionManager.instance.ActivarMision(mision.idMision);
        }
    }

    private bool TieneObjetosRequeridos()
    {
        if (mision == null || inventario == null) return false;
        if (mision.tipoMision != TipoMision.Recoleccion) return false;

        foreach (var obj in mision.objetivos)
        {
            int cantidad = inventario.GetCantidadItem(obj.itemRequerido);
            if (cantidad < obj.cantidadRequerida)
                return false; // Falta algún objeto
        }

        return true;
    }


    private void CompletarMision()
    {
        if (mision == null) return;

        // Si es recolección, restar los ítems requeridos
        if (mision.tipoMision == TipoMision.Recoleccion)
        {
            foreach (var obj in mision.objetivos)
            {
                inventario.RestarItem(obj.itemRequerido, obj.cantidadRequerida);
            }
        }

        MisionManager.instance.CompletarMision(mision.idMision);
    }

    private void ReiniciarMision()
    {
        if (mision != null)
        {
            MisionManager.instance.ReiniciarMision(mision.idMision);
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