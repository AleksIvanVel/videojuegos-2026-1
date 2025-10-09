using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPortalPorMision : MonoBehaviour
{
    [Header("Configuración del portal")]
    public string itemId;               // ID del portal 
    public string misionIdRequerida;    // Misión que debe estar activa para habilitarlo

    [Header("Objetos relacionados")]
    public GameObject bloqueoPortal;    // Objeto que bloquea el portal 
    public Collider2D portalTriggerCollider;  // Collider que hace la transición

    void Awake()
    {
        if (portalTriggerCollider == null)
            portalTriggerCollider = GetComponent<Collider2D>();

        // Al inicio: portal desactivado, bloqueo activo
        if (portalTriggerCollider != null)
            portalTriggerCollider.enabled = false;

        if (bloqueoPortal != null)
            bloqueoPortal.SetActive(true);
    }

    void Update()
    {
        Mision mision = MisionManager.instance.ObtenerMisionPorId(misionIdRequerida);
        //Si la mision esta  o ya se ha completado
        if ((mision != null && mision.EstaActiva) || mision.EstaCompletada)
            //Mantiene activo el portal quitando el bloqueo
            ActivarPortal();
        else
            //Mantiene bloqueado el portal 
            DesactivarPortal();
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
