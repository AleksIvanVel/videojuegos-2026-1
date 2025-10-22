using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour
{
    public static Musica instancia;
    
    [Header("Configuración de Música")]
    public AudioClip musicaFondo;
    public float volumenMusica = 0.5f;
    
    [Header("Configuración de Efectos")]
    public float volumenEfectos = 1.0f;
    
    private AudioSource audioSource;
    private const string KEY_VOLUMEN_MUSICA = "VolumenMusica";
    private const string KEY_VOLUMEN_EFECTOS = "VolumenEfectos";

    void Awake()
    {
        // Patrón Singleton - Solo una instancia de música
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // No destruir al cambiar de escena
            
            // Cargar volúmenes guardados
            volumenMusica = PlayerPrefs.GetFloat(KEY_VOLUMEN_MUSICA, 0.5f);
            volumenEfectos = PlayerPrefs.GetFloat(KEY_VOLUMEN_EFECTOS, 1.0f);
            
            // Configurar AudioSource para música
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = musicaFondo;
            audioSource.loop = true; // Música en bucle
            audioSource.playOnAwake = true;
            audioSource.volume = volumenMusica;
            
            // Reproducir música
            audioSource.Play();
        }
        else
        {
            // Si ya existe una instancia, destruir este objeto duplicado
            Destroy(gameObject);
        }
    }

    // Método para cambiar el volumen de la música
    public void CambiarVolumenMusica(float nuevoVolumen)
    {
        volumenMusica = nuevoVolumen;
        if (audioSource != null)
        {
            audioSource.volume = nuevoVolumen;
        }
        PlayerPrefs.SetFloat(KEY_VOLUMEN_MUSICA, nuevoVolumen);
        PlayerPrefs.Save();
    }

    // Método para cambiar el volumen de los efectos
    public void CambiarVolumenEfectos(float nuevoVolumen)
    {
        volumenEfectos = nuevoVolumen;
        PlayerPrefs.SetFloat(KEY_VOLUMEN_EFECTOS, nuevoVolumen);
        PlayerPrefs.Save();
    }

    // Método para obtener el volumen actual de efectos
    public float ObtenerVolumenEfectos()
    {
        return volumenEfectos;
    }

    // Método para obtener el volumen actual de música
    public float ObtenerVolumenMusica()
    {
        return volumenMusica;
    }

    // Método para detener la música
    public void DetenerMusica()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    // Método para reanudar la música
    public void ReanudarMusica()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}