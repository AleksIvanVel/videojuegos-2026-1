using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [Header("UI Elements")]
    public Text txtTitulo;
    public Text txtRecord;
    public Button btnJugar;
    public Button btnConfiguracion;
    public Button btnCreditos;
    public Button btnPersonajes;
    
    [Header("Panel de Configuración")]
    public GameObject panelConfiguracion;
    public Slider sliderVolumenMusica;
    public Text txtVolumenMusica;
    public Slider sliderVolumenEfectos;
    public Text txtVolumenEfectos;
    public Button btnCerrarConfig;

    [Header("Panel de Personajes")]
    public GameObject panelPersonajes;
    public Button btnCerrarPersonajes;
    
    [Header("Panel de Créditos")]
    public GameObject panelCreditos;
    public Text txtCreditos;
    public Button btnCerrarCreditos;
    
    private int recordActual;
    private const string KEY_RECORD = "RecordJuego";

    void Start()
    {
        // Cargar récord guardado
        recordActual = PlayerPrefs.GetInt(KEY_RECORD, 0);
        ActualizarTextoRecord();
        
        // Configurar volumen inicial
        if (Musica.instancia != null)
        {
            sliderVolumenMusica.value = Musica.instancia.ObtenerVolumenMusica();
            sliderVolumenEfectos.value = Musica.instancia.ObtenerVolumenEfectos();
        }
        else
        {
            sliderVolumenMusica.value = 0.5f;
            sliderVolumenEfectos.value = 1.0f;
        }

        ActualizarTextoVolumenMusica();
        ActualizarTextoVolumenEfectos();

        // Configurar botones
        btnJugar.onClick.AddListener(IniciarJuego);
        btnConfiguracion.onClick.AddListener(AbrirConfiguracion);
        btnCerrarConfig.onClick.AddListener(CerrarConfiguracion);
        btnCreditos.onClick.AddListener(AbrirCreditos);
        btnCerrarCreditos.onClick.AddListener(CerrarCreditos);
        btnPersonajes.onClick.AddListener(AbrirPersonajes);
        btnCerrarPersonajes.onClick.AddListener(CerrarPersonajes);
        
        // Configurar sliders
        sliderVolumenMusica.onValueChanged.AddListener(CambiarVolumenMusica);
        sliderVolumenEfectos.onValueChanged.AddListener(CambiarVolumenEfectos);
        
        // Asegurar que los paneles estén cerrados al inicio
        panelConfiguracion.SetActive(false);
        panelCreditos.SetActive(false);
        panelPersonajes.SetActive(false);
        
        // Configurar texto de créditos
        ConfigurarTextoCreditos();
    }

    private void ActualizarTextoRecord()
    {
        txtRecord.text = "RÉCORD: " + recordActual.ToString();
    }

    private void ActualizarTextoVolumenMusica()
    {
        int porcentaje = Mathf.RoundToInt(sliderVolumenMusica.value * 100);
        txtVolumenMusica.text = porcentaje + "%";
    }

    private void ActualizarTextoVolumenEfectos()
    {
        int porcentaje = Mathf.RoundToInt(sliderVolumenEfectos.value * 100);
        txtVolumenEfectos.text = porcentaje + "%";
    }

    private void ConfigurarTextoCreditos()
    {
        txtCreditos.text = "FLAPPY STEVE © 2025\n\n" +
                          "Desarrollado por:\n\n" +
                          "Diego Arroyo Palacios\n" +
                          "Ricardo Madrigal Urencio\n" +
                          "Aleks Iván Velázquez Arriaga\n\n" +
                          "Inspirado en Flappy Bird\n\n" +
                          "¡Gracias por jugar!\n\n";
    }

    private void IniciarJuego()
    {
        SceneManager.LoadScene("Main");
    }

    private void AbrirConfiguracion()
    {
        panelConfiguracion.SetActive(true);
    }

    private void CerrarConfiguracion()
    {
        panelConfiguracion.SetActive(false);
    }

    private void AbrirCreditos()
    {
        panelCreditos.SetActive(true);
    }

    private void CerrarCreditos()
    {
        panelCreditos.SetActive(false);
    }

    private void AbrirPersonajes()
    {
        panelPersonajes.SetActive(true);
    }

    private void CerrarPersonajes()
    {
        panelPersonajes.SetActive(false);
    }

    private void CambiarVolumenMusica(float valor)
    {
        if (Musica.instancia != null) 
            Musica.instancia.CambiarVolumenMusica(valor);

        ActualizarTextoVolumenMusica();
    }

    private void CambiarVolumenEfectos(float valor)
    {
        if (Musica.instancia != null)
            Musica.instancia.CambiarVolumenEfectos(valor);

        ActualizarTextoVolumenEfectos();
    }

    // Método público para actualizar el récord desde otros scripts
    public static void ActualizarRecord(int nuevoScore)
    {
        int recordActual = PlayerPrefs.GetInt(KEY_RECORD, 0);
        if (nuevoScore > recordActual)
        {
            PlayerPrefs.SetInt(KEY_RECORD, nuevoScore);
            PlayerPrefs.Save();
        }
    }
}