using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Objetos del Juego")]
    public GameObject Player;

    [Header("Paneles del Menú")]
    public GameObject MenuInicial;
    public GameObject Ajustes;
    public GameObject Creditos;
    public GameObject Pausa;

    private bool muestraPausa = false;
    private bool playerActive;

    void Start()
    {
        MostrarMenuInicial();
    }

    void Update()
    {
        Player.SetActive(playerActive);
        // La tecla de Esc como menu de pausa y boton de retroceso en los menus
        if (playerActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                StatusPausa();
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Regresar();
        }
    }

    public void IniciarJuego()
    {
        // Desactiva el panel del menú principal
        if (MenuInicial != null)
        {
            MenuInicial.SetActive(false);
        }

        // Activa al jugador para que comience el juego
        if (Player != null)
        {
            playerActive = true;
            
        }
    }

    public void MostararAjustes()
    {
        if (Player)
        Ajustes.SetActive(true);
        // Desactivar el Resto de Menús
        MenuInicial.SetActive(false);
        Creditos.SetActive(false);
        Pausa.SetActive(false);
    }

    public void MostrarCreditos()
    {
        Creditos.SetActive(true);
        // Desactivar el Resto de Menús
        MenuInicial.SetActive(false);
        Ajustes.SetActive(false);
        Pausa.SetActive(false);
    }

    public void MostrarMenuInicial()
    {
        MenuInicial.SetActive(true);
        // Desactivar el Resto de Menús
        Ajustes.SetActive(false);
        Creditos.SetActive(false);
        Pausa.SetActive(false);
        playerActive = false;
    }

    public void MostrarPausa(bool active)
    {
        Pausa.SetActive(active);
        MenuInicial.SetActive(false);
        Ajustes.SetActive(false);
        Creditos.SetActive(false);
    }

    public void StatusPausa()
    {
        if (muestraPausa)
        {
            MostrarPausa(false);
            Time.timeScale = 1;
            muestraPausa = false;
        }
        else
        {
            MostrarPausa(true);
            Time.timeScale = 0;
            muestraPausa = true;
        }
    }

    public void Regresar()
    {
        //Ajustes
        if (Ajustes != null && muestraPausa) //Se asume que se accedio a Ajustes por el Menu de Pausa
        {
            MostrarPausa(true);
             MenuInicial.SetActive(false);
            Debug.Log("Ajustes a Pausa");
        }
        else //Se asume que se accedio a Ajustes desde el Menu Principal
        {
            MostrarMenuInicial();
            Debug.Log("Ajustes a Menu");
        }
        //Creditos
        if (Creditos != null)
        {
            MostrarMenuInicial();
        }
    }

    public void RecargarEscena()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1;
    }

    public void CerrarJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}