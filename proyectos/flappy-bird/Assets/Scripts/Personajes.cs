using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Personaje
{
    public string nombre;
    public Sprite spriteIdle; // Sprite principal del personaje
    public RuntimeAnimatorController animatorController; // Su propio Animator
    public bool desbloqueado = true;
    public int puntosParaDesbloquear = 0;
}

public class Personajes : MonoBehaviour
{
    public static Personajes instancia;
    
    [Header("Lista de Personajes")]
    public List<Personaje> personajes = new List<Personaje>();
    
    private int personajeSeleccionadoIndex = 0;
    private const string KEY_PERSONAJE = "PersonajeSeleccionado";
    private const string KEY_RECORD = "RecordJuego";

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
            
            // Cargar personaje guardado
            personajeSeleccionadoIndex = PlayerPrefs.GetInt(KEY_PERSONAJE, 0);
            
            // Verificar qué personajes están desbloqueados
            VerificarDesbloqueos();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void VerificarDesbloqueos()
    {
        int recordActual = PlayerPrefs.GetInt(KEY_RECORD, 0);
        
        foreach (Personaje personaje in personajes)
        {
            if (recordActual >= personaje.puntosParaDesbloquear)
            {
                personaje.desbloqueado = true;
            }
            else
            {
                personaje.desbloqueado = false;
            }
        }
    }

    public void SeleccionarPersonaje(int index)
    {
        if (index >= 0 && index < personajes.Count)
        {
            personajeSeleccionadoIndex = index;
            PlayerPrefs.SetInt(KEY_PERSONAJE, index);
            PlayerPrefs.Save();
        }
    }

    public Personaje ObtenerPersonajeSeleccionado()
    {
        if (personajeSeleccionadoIndex >= 0 && personajeSeleccionadoIndex < personajes.Count)
        {
            return personajes[personajeSeleccionadoIndex];
        }
        return personajes[0];
    }

    public int ObtenerIndexPersonajeSeleccionado()
    {
        return personajeSeleccionadoIndex;
    }

    public int ObtenerCantidadPersonajes()
    {
        return personajes.Count;
    }

    public Personaje ObtenerPersonajePorIndex(int index)
    {
        if (index >= 0 && index < personajes.Count)
        {
            return personajes[index];
        }
        return null;
    }

    public int ObtenerPuntosParaDesbloquear(int index)
    {
        Personaje personaje = ObtenerPersonajePorIndex(index);
        if (personaje != null)
        {
            return personaje.puntosParaDesbloquear;
        }
        return 0;
    }

    public void ActualizarDesbloqueos()
    {
        VerificarDesbloqueos();
    }
}