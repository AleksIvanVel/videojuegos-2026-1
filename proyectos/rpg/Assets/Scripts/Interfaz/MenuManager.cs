using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

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
    public bool MenuInicialActive = true;



    [Header("UI de Ajustes")]
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        Time.timeScale = 0;
        MostrarMenuInicial();
        AudioManager.instance.PlayMusic(AudioManager.instance.Menu);
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        // La tecla de Esc como menu de pausa y boton de retroceso en los menus
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Regresar();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !AjustesActive && !MenuInicialActive)
        {
            StatusPausa();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && AjustesActive)
        {
            AjustesActive = false;
        }

    }

    public void IniciarJuego()
    {
        // Desactiva el panel del menú principal
        if (MenuInicialActive)
        {
            MenuInicial.SetActive(false);
            MenuInicialActive = false;
            Time.timeScale = 1;
        }

        AudioManager.instance.PlayMusic(AudioManager.instance.Juego);
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
            AudioManager.instance.PlayUnscaledSFX(AudioManager.instance.SalirPausa);
            PausaActive = false;
        }
        else
        {
            MostrarPausa(true);
            Time.timeScale = 0;
            AudioManager.instance.PlayUnscaledSFX(AudioManager.instance.Pausa);
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
            }
            else if (MenuInicialActive == true) //Se accedio a Ajustes desde el Menu Principal
            {
                MostrarMenuInicial();
                AjustesActive = false;
                CreditosActive = false;
            }
        }

        //Creditos
        if (CreditosActive)
        {
            MostrarMenuInicial();
        }
    }

    public void ReiniciarJuego()
    {
        Time.timeScale = 1f;
        if (MisionManager.instance != null)
        {
            MisionManager.instance.ReiniciarTodasLasMisiones();
        }

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void CerrarJuego()
    {
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