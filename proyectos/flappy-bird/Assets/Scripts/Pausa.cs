using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    [Header("Panel de Pausa")]
    public GameObject panelPausa;
    public Text txtTituloPausa;
    public Text txtRecordPausa;
    
    [Header("Botones Principales")]
    public Button btnReanudar;
    public Button btnConfiguracion;
    public Button btnMenuPrincipal;
    
    [Header("Panel de Configuración")]
    public GameObject panelConfiguracion;
    public Slider sliderVolumenMusica;
    public Text txtVolumenMusica;
    public Slider sliderVolumenEfectos;
    public Text txtVolumenEfectos;
    public Button btnCerrarConfig;
    
    [Header("Botón de Pausa en Juego")]
    public Button btnPausa;
    
    private bool juegoPausado = false;
    private const string KEY_RECORD = "RecordJuego";

    void Start()
    {
        // Asegurar que los paneles estén ocultos al inicio
        if (panelPausa != null)
            panelPausa.SetActive(false);
        
        if (panelConfiguracion != null)
            panelConfiguracion.SetActive(false);
        
        // Configurar botones
        if (btnPausa != null)
            btnPausa.onClick.AddListener(PausarJuego);
        
        if (btnReanudar != null)
            btnReanudar.onClick.AddListener(ReanudarJuego);
        
        if (btnConfiguracion != null)
            btnConfiguracion.onClick.AddListener(AbrirConfiguracion);
        
        if (btnCerrarConfig != null)
            btnCerrarConfig.onClick.AddListener(CerrarConfiguracion);
        
        if (btnMenuPrincipal != null)
            btnMenuPrincipal.onClick.AddListener(VolverAlMenu);
        
        // Configurar sliders
        if (sliderVolumenMusica != null)
            sliderVolumenMusica.onValueChanged.AddListener(CambiarVolumenMusica);
        
        if (sliderVolumenEfectos != null)
            sliderVolumenEfectos.onValueChanged.AddListener(CambiarVolumenEfectos);
    }

    void Update()
    {
        // También permitir pausar con la tecla ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                if (panelConfiguracion.activeSelf)
                    CerrarConfiguracion();
                else
                    ReanudarJuego();
            }
            else
            {
                PausarJuego();
            }
        }
    }

    public void PausarJuego()
    {
        juegoPausado = true;
        Time.timeScale = 0f; // Detener el tiempo del juego
        
        // Mostrar récord actual
        if (txtRecordPausa != null)
        {
            int record = PlayerPrefs.GetInt(KEY_RECORD, 0);
            txtRecordPausa.text = "RÉCORD: " + record.ToString();
        }
        
        // Cargar volúmenes actuales
        if (Musica.instancia != null)
        {
            if (sliderVolumenMusica != null)
                sliderVolumenMusica.value = Musica.instancia.ObtenerVolumenMusica();
            
            if (sliderVolumenEfectos != null)
                sliderVolumenEfectos.value = Musica.instancia.ObtenerVolumenEfectos();
        }
        
        ActualizarTextoVolumenMusica();
        ActualizarTextoVolumenEfectos();
        
        // Mostrar panel de pausa
        if (panelPausa != null)
            panelPausa.SetActive(true);
    }

    public void ReanudarJuego()
    {
        juegoPausado = false;
        Time.timeScale = 1f; // Reanudar el tiempo del juego
        
        // Ocultar panel de pausa
        if (panelPausa != null)
            panelPausa.SetActive(false);
        
        // Asegurar que configuración esté cerrada
        if (panelConfiguracion != null)
            panelConfiguracion.SetActive(false);
    }

    private void AbrirConfiguracion()
    {
        if (panelConfiguracion != null)
            panelConfiguracion.SetActive(true);

        if (btnReanudar != null)
            btnReanudar.gameObject.SetActive(false);
        if (btnConfiguracion != null)
            btnConfiguracion.gameObject.SetActive(false);
        if (btnMenuPrincipal != null)
            btnMenuPrincipal.gameObject.SetActive(false);
        if (txtTituloPausa != null)
            txtTituloPausa.gameObject.SetActive(false);
        if (txtRecordPausa != null)
            txtRecordPausa.gameObject.SetActive(false);
    }

    private void CerrarConfiguracion()
    {
        if (panelConfiguracion != null)
            panelConfiguracion.SetActive(false);

        if (btnReanudar != null)
            btnReanudar.gameObject.SetActive(true);
        if (btnConfiguracion != null)
            btnConfiguracion.gameObject.SetActive(true);
        if (btnMenuPrincipal != null)
            btnMenuPrincipal.gameObject.SetActive(true);
        if (txtTituloPausa != null)
            txtTituloPausa.gameObject.SetActive(true);
        if (txtRecordPausa != null)
            txtRecordPausa.gameObject.SetActive(true);
    }

    private void VolverAlMenu()
    {
        Time.timeScale = 1f; // Restaurar el tiempo antes de cambiar de escena
        SceneManager.LoadScene("MenuPrincipal");
    }

    private void CambiarVolumenMusica(float valor)
    {
        if (Musica.instancia != null)
        {
            Musica.instancia.CambiarVolumenMusica(valor);
        }
        ActualizarTextoVolumenMusica();
    }

    private void CambiarVolumenEfectos(float valor)
    {
        if (Musica.instancia != null)
        {
            Musica.instancia.CambiarVolumenEfectos(valor);
        }
        ActualizarTextoVolumenEfectos();
    }

    private void ActualizarTextoVolumenMusica()
    {
        if (txtVolumenMusica != null && sliderVolumenMusica != null)
        {
            int porcentaje = Mathf.RoundToInt(sliderVolumenMusica.value * 100);
            txtVolumenMusica.text = porcentaje + "%";
        }
    }

    private void ActualizarTextoVolumenEfectos()
    {
        if (txtVolumenEfectos != null && sliderVolumenEfectos != null)
        {
            int porcentaje = Mathf.RoundToInt(sliderVolumenEfectos.value * 100);
            txtVolumenEfectos.text = porcentaje + "%";
        }
    }
}