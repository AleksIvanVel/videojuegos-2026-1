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
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);

            volumenMusica = PlayerPrefs.GetFloat(KEY_VOLUMEN_MUSICA, 0.5f);
            volumenEfectos = PlayerPrefs.GetFloat(KEY_VOLUMEN_EFECTOS, 1.0f);

            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = musicaFondo;
            audioSource.loop = true;
            audioSource.playOnAwake = true;
            audioSource.volume = volumenMusica;

            audioSource.Play();
        }
        else 
        {
            Destroy(gameObject);
        }
    }

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

    public void CambiarVolumenEfectos(float nuevoVolumen)
    {
        volumenEfectos = nuevoVolumen;
        PlayerPrefs.SetFloat(KEY_VOLUMEN_EFECTOS, nuevoVolumen);
        PlayerPrefs.Save();
    }

    public float ObtenerVolumenMusica()
    {
        return volumenMusica;
    }

    public float ObtenerVolumenEfectos()
    {
        return volumenEfectos;
    }

    public void DetenerMusica()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    public void ReanudarMusica()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}