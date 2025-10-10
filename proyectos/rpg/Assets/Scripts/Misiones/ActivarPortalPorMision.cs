using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPortalPorMision : MonoBehaviour
{
    [Header("Configuración del portal")]
    public string itemId;               // ID del portal 
    public string misionIdRequerida;    // Misión asociada al portal
    public bool activarSoloAlCompletarMision; 

    [Header("Objetos relacionados")]
    public GameObject bloqueoPortal;    // Objeto que bloquea el portal 
    public Collider2D portalTriggerCollider;  // Collider que hace la transición

    void Awake()
    {
        if (portalTriggerCollider == null)
            portalTriggerCollider = GetComponent<Collider2D>();

        // Bloquea el portal al iniciar
        if (portalTriggerCollider != null)
            portalTriggerCollider.enabled = false;

        if (bloqueoPortal != null)
            bloqueoPortal.SetActive(true);
    }

    void Update()
    {
        Mision mision = MisionManager.instance.ObtenerMisionPorId(misionIdRequerida);

        if (mision == null)
            return;

        //  Portal se activa mientras la misión está activa (no necesita completarse)
        if (!activarSoloAlCompletarMision && (mision.EstaActiva || mision.EstaCompletada))
        {
            ActivarPortal();
        }
        // Portal solo se activa al completar la misión
        else if (activarSoloAlCompletarMision && mision.EstaCompletada)
        {
            ActivarPortal();
        }
        // En cualquier otro caso, mantener bloqueado
        else
        {
            DesactivarPortal();
        }
    }

    private void ActivarPortal()
    {
        if (portalTriggerCollider != null)
            portalTriggerCollider.enabled = true;

        if (bloqueoPortal != null)
            bloqueoPortal.SetActive(false);
    }

    private void DesactivarPortal()
    {
        if (portalTriggerCollider != null)
            portalTriggerCollider.enabled = false;

        if (bloqueoPortal != null)
            bloqueoPortal.SetActive(true);
    }
}
