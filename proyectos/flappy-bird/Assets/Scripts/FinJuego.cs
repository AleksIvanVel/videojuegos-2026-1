using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinJuego : MonoBehaviour
{
    [Header("Panel Fin Juego")]
    public GameObject panelFinJuego;
    public Text txtFinJuego;
    public Text txtPuntuacionFinal;
    public Text txtRecord;

    [Header("Botones")]
    public Button btnVolverJugar;
    public Button btnMenuPrincipal;

    [Header("Configuración")]
    public float tiempoEsperaParaMostrar = 1.5f;

    private const string KEY_RECORD = "RecordJuego";

    void Start()
    {
        if (panelFinJuego != null)
            panelFinJuego.SetActive(false);

        if (btnVolverJugar != null)
            btnVolverJugar.onClick.AddListener(Reintentar);

        if (btnMenuPrincipal != null)
            btnMenuPrincipal.onClick.AddListener(VolverAlMenu);
    }

    public void MostrarFinJuego(int puntuacion)
    {
        StartCoroutine(MostrarPanelConRetraso(puntuacion));
    }

    private IEnumerator MostrarPanelConRetraso(int puntuacion)
    {
        yield return new WaitForSeconds(tiempoEsperaParaMostrar);

        if (txtPuntuacionFinal != null)
            txtPuntuacionFinal.text = "PUNTUACIÓN: " + puntuacion.ToString();

        int recordActual = PlayerPrefs.GetInt(KEY_RECORD, 0);
        if (puntuacion > recordActual)
        {
            PlayerPrefs.SetInt(KEY_RECORD, puntuacion);
            PlayerPrefs.Save();

            if (txtRecord != null)
                txtRecord.text = "¡NUEVO RÉCORD!";
        }
        else 
        {
            if (txtRecord != null)
                txtRecord.text = "RÉCORD: " + recordActual.ToString();
        }

        if (panelFinJuego != null)
            panelFinJuego.SetActive(true);
    }

    private void Reintentar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void VolverAlMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}