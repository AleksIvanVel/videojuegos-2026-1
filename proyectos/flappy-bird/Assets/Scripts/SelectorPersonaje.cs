using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorPersonaje : MonoBehaviour
{
    [Header("UI Elements")]
    public Image imagenPersonaje;
    public Text txtNombrePersonaje;
    public Button btnAnterior;
    public Button btnSiguiente;
    public Button btnSeleccionar;
    public GameObject iconoBloqueado;
    public Text txtPuntosNecesarios;

    [Header("Indicadores")]
    public Text txtContador;

    [Header("Colores")]
    public Color colorSeleccionado = Color.yellow;
    public Color colorSeleccionar = Color.white;

    private int indexActual = 0;
    private Coroutine corrutineRestauro;

    void Start()
    {
        if (Personajes.instancia != null)
        {
            indexActual = Personajes.instancia.ObtenerIndexPersonajeSeleccionado();
        }

        // Configurar botones
        if (btnAnterior != null)
            btnAnterior.onClick.AddListener(PersonajeAnterior);

        if (btnSiguiente != null)
            btnSiguiente.onClick.AddListener(PersonajeSiguiente);

        if (btnSeleccionar != null)
            btnSeleccionar.onClick.AddListener(SeleccionarPersonaje);

        // Mostrar personaje actual
        ActualizarVisualizacion();
    }

    private void PersonajeAnterior()
    {
        if (Personajes.instancia == null) return;

        indexActual--;
        if (indexActual < 0)
            indexActual = Personajes.instancia.ObtenerCantidadPersonajes() - 1;

        ActualizarVisualizacion();
    }

    private void PersonajeSiguiente()
    {
        if (Personajes.instancia == null) return;

        indexActual++;
        if (indexActual >= Personajes.instancia.ObtenerCantidadPersonajes())
            indexActual = 0;

        ActualizarVisualizacion();
    }

    private void SeleccionarPersonaje()
    {
        if (Personajes.instancia == null) return;

        Personaje personaje = Personajes.instancia.ObtenerPersonajePorIndex(indexActual);

        if (personaje != null && personaje.desbloqueado)
        {
            // Solo hacer animación si NO estaba ya seleccionado
            if (indexActual != Personajes.instancia.ObtenerIndexPersonajeSeleccionado())
            {
                Personajes.instancia.SeleccionarPersonaje(indexActual);

                // Detener corrutina anterior si existe
                if (corrutineRestauro != null)
                {
                    StopCoroutine(corrutineRestauro);
                }

                // Iniciar nueva corrutina
                if (btnSeleccionar != null)
                {
                    Text txtBoton = btnSeleccionar.GetComponentInChildren<Text>();
                    if (txtBoton != null)
                    {
                        txtBoton.text = "SELECCIONADO";
                        txtBoton.color = colorSeleccionado;
                        corrutineRestauro = StartCoroutine(RestaurarTextoBoton(txtBoton));
                    }
                }
            }
            else
            {
                // Ya estaba seleccionado, no hacer nada especial
                ActualizarVisualizacion();
            }
        }
    }
    
    private IEnumerator RestaurarTextoBoton(Text txtBoton)
    {
        yield return new WaitForSeconds(1.5f);
        if (txtBoton != null)
        {
            txtBoton.text = "SELECCIONADO";
            txtBoton.color = colorSeleccionado;
        }
    }

    private void ActualizarVisualizacion()
    {
        if (Personajes.instancia == null) return;
        
        Personaje personaje = Personajes.instancia.ObtenerPersonajePorIndex(indexActual);
        
        if (personaje != null)
        {
            // Actualizar imagen
            if (imagenPersonaje != null && personaje.spriteIdle != null)
            {
                imagenPersonaje.sprite = personaje.spriteIdle;
                imagenPersonaje.color = personaje.desbloqueado ? Color.white : new Color(0.3f, 0.3f, 0.3f);
            }
            
            // Actualizar nombre
            if (txtNombrePersonaje != null)
            {
                txtNombrePersonaje.text = personaje.nombre;
            }

            // Actualizar contador
            if (txtContador != null)
            {
                txtContador.text = (indexActual + 1) + " / " + Personajes.instancia.ObtenerCantidadPersonajes();
            }
            
            // Mostrar puntos necesarios si está bloqueado
            if (txtPuntosNecesarios != null)
            {
                if (personaje.desbloqueado)
                {
                    txtPuntosNecesarios.text = "";
                }
                else
                {
                    int puntosNecesarios = Personajes.instancia.ObtenerPuntosParaDesbloquear(indexActual);
                    int recordActual = PlayerPrefs.GetInt("RecordJuego", 0);
                    txtPuntosNecesarios.text = "Desbloquea con " + puntosNecesarios + " puntos\n(Récord actual: " + recordActual + ")";
                }
            }
            
            // Mostrar/ocultar icono de bloqueado
            if (iconoBloqueado != null)
            {
                iconoBloqueado.SetActive(!personaje.desbloqueado);
            }
            
            // Habilitar/deshabilitar botón de seleccionar
            if (btnSeleccionar != null)
            {
                btnSeleccionar.interactable = personaje.desbloqueado;
            }
            
            // Actualizar estado del botón
            if (btnSeleccionar != null)
            {
                Text txtBoton = btnSeleccionar.GetComponentInChildren<Text>();
                if (txtBoton != null)
                {
                    // Verificar si es el personaje seleccionado actualmente
                    if (indexActual == Personajes.instancia.ObtenerIndexPersonajeSeleccionado())
                    {
                        txtBoton.text = "SELECCIONADO";
                        txtBoton.color = colorSeleccionado;
                    }
                    else
                    {
                        txtBoton.text = "SELECCIONAR";
                        txtBoton.color = colorSeleccionar;
                    }
                }
            }
        }
    }
}