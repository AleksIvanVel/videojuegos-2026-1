using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class AudioManager : MonoBehaviour
{
    // --- SINGLETON ---
    public static AudioManager instance;

    [Header("Audio Mixer")]
    public AudioMixer mainMixer;

    [Header("Audio Sources")]
    public AudioSource musicSource; 
    public AudioSource sfxSource;

    public TextMeshProUGUI PorcentajeMusica;
    public TextMeshProUGUI PorcentajeSFX;

    void Awake()
    {
        // Configuración del Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ¡No destruir este objeto al cargar otra escena!
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruir esta duplicada.
        }
    }

    void Start()
    {
        // Cargar las preferencias de volumen guardadas al iniciar el juego
        LoadVolume();
    }

    void Update()
    {
        LoadVolume();
    }

    // --- Control de Volumen ---

    public void SetMusicVolume(float volume)
    {
        mainMixer.SetFloat("MusicVolume", Mathf.Log(volume) * 40);
        PlayerPrefs.SetFloat("MusicVolume", volume); // Guardar la preferencia

        PorcentajeMusica.SetText($"{(volume * 100).ToString("N0")}%");
    }

    public void SetSFXVolume(float volume)
    {
        mainMixer.SetFloat("SFXVolume", Mathf.Log(volume) * 40);
        PlayerPrefs.SetFloat("SFXVolume", volume); // Guardar la preferencia

        PorcentajeSFX.SetText($"{(volume*100).ToString("N0")}%");
    }

    private void LoadVolume()
    {
        // Carga el volumen de la música, si no hay nada guardado, usa 0.75 por defecto
        float musicVol = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        SetMusicVolume(musicVol);

        // Carga el volumen de los SFX, si no hay nada guardado, usa 0.75 por defecto
        float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
        SetSFXVolume(sfxVol);
        
        // Aquí podrías actualizar los sliders de la UI si estuvieran visibles al inicio
    }


    // --- Reproducción de Sonido ---

    public void PlayMusic(AudioClip musicClip)
    {
        musicSource.clip = musicClip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip sfxClip)
    {
        sfxSource.PlayOneShot(sfxClip); // PlayOneShot permite que varios efectos suenen a la vez
    }
}