using UnityEngine;
using UnityEngine.UI;
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

    private bool PausaActive = false;
    private bool AjustesActive;
    private bool CreditosActive;
    private bool MenuInicialActive = true;
    private bool playerActive;

    [Header("Pistas de Audio")]
    public AudioClip menuMusic;
    public AudioClip gameMusic;

    [Header("UI de Ajustes")]
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        MostrarMenuInicial();
        AudioManager.instance.PlayMusic(menuMusic);
    }

    void Update()
    {
        Player.SetActive(playerActive);
        // La tecla de Esc como menu de pausa y boton de retroceso en los menus
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Regresar();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && playerActive)
        {
            StatusPausa();
        }

    }

    public void IniciarJuego()
    {
        // Desactiva el panel del menú principal
        if (MenuInicialActive)
        {
            MenuInicial.SetActive(false);
            MenuInicialActive = false;
        }

        // Activa al jugador para que comience el juego
        if (playerActive == false)
        {
            playerActive = true;

        }

        AudioManager.instance.PlayMusic(gameMusic);
    }

    public void MostararAjustes()
    {
        Ajustes.SetActive(true);
        AjustesActive = true;
        // Desactivar el Resto de Menús
        MenuInicial.SetActive(false);
        Creditos.SetActive(false);
        Pausa.SetActive(false);

        MostrarValoresAjustes();

    }

    public void MostrarCreditos()
    {
        Creditos.SetActive(true);
        CreditosActive = true;
        // Desactivar el Resto de Menús
        MenuInicial.SetActive(false);
        Ajustes.SetActive(false);
        Pausa.SetActive(false);
    }

    public void MostrarMenuInicial()
    {
        MenuInicial.SetActive(true);
        MenuInicialActive = true;
        // Desactivar el Resto de Menús
        Ajustes.SetActive(false);
        Creditos.SetActive(false);
        Pausa.SetActive(false);
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
        if (PausaActive)
        {
            MostrarPausa(false);
            Time.timeScale = 1;
            PausaActive = false;
        }
        else
        {
            MostrarPausa(true);
            Time.timeScale = 0;
            PausaActive = true;
        }
    }

    public void Regresar()
    {
        //Ajustes
        if (AjustesActive)
        {
            if (PausaActive == true) //Se accedio a Ajustes por el Menu de Pausa
            {
                MostrarPausa(true);
                MenuInicial.SetActive(false);
            }
            else if (MenuInicialActive == true) //Se accedio a Ajustes desde el Menu Principal
            {
                MostrarMenuInicial();
            }
        }

        //Creditos
        if (CreditosActive)
        {
            MostrarMenuInicial();
            Debug.Log("Creditos a Menu");

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
    
    void MostrarValoresAjustes()
{
    // Carga el valor guardado para la música (usa el mismo valor por defecto que en AudioManager)
    float musicVol = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    musicSlider.value = musicVol;

    // Carga el valor guardado para los SFX
    float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
    sfxSlider.value = sfxVol;
}
}