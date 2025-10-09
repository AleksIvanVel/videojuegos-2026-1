using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Inventario : MonoBehaviour
{
    private bool muestraInventario;
    public GameObject goInventario;
    [SerializeField] private string[] valoresInventario; // "" - sin elemento, string - elemento

    public Image[] espaciosInventario; // Arreglo para los slots
    public Text[] textoContadores; // Arreglo para los textos de cantidad
    
    // Sprites de items
    public Sprite amuleto, amuletoPlata, anillo, armadura1, armadura2, armadura3, armadura4,
    escudo, gemaAzul, gemaRoja, gemaVerde, hierbas, hacha, llave, moneda, pan, contenedor;

    [Header("Sonidos")]
    public AudioClip AbrirInventario;
    public AudioClip CerrarInventario;

    // Evento público que otros scripts pueden suscribirse
    public static event Action<string> OnItemAgregado;

    // Diccionario para manejar cantidades de items
    private Dictionary<string, int> cantidadItems = new Dictionary<string, int>();

    void Start()
    {
        muestraInventario = false;
        BorrarArreglo();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            StatusInventario();
        }
    }

    public void StatusInventario()
    {
        muestraInventario = !muestraInventario;
        goInventario.SetActive(muestraInventario);
        Time.timeScale = muestraInventario ? 0 : 1;

        AudioManager.instance.PlaySFX(muestraInventario ? AbrirInventario : CerrarInventario);
    }

    public void EscribeEnArreglo()
    {

        string item = Coleccionables.objColeccionables;

        // Sumar cantidad en el diccionario
        if (!cantidadItems.ContainsKey(item))
            cantidadItems[item] = 0;
        cantidadItems[item]++;

        // Colocar en inventario visual
        int pos = VerificaEnArreglo(item);
        if (pos == -1)
        {
            for (int i = 0; i < valoresInventario.Length; i++)
            {
                if (valoresInventario[i] == "")
                {
                    valoresInventario[i] = item;
                    DibujaElementos(i, item);
                    OnItemAgregado?.Invoke(item);
                    break;
                }
            }
        }
        else
        {
            DibujaElementos(pos, item);
            OnItemAgregado?.Invoke(item);
        }
    }

    private int VerificaEnArreglo(string item)
    {

        for (int i = 0; i < valoresInventario.Length; i++)
            if (valoresInventario[i] == item) return i;
        return -1;
    }

    public void DibujaElementos(int pos, string item)
    {

        Sprite contenedor = null;
        int cantidad = cantidadItems[item];

        switch (item)
        {
            case "amuleto": contenedor = amuleto; break;
            case "amuletoPlata": contenedor = amuletoPlata; break;
            case "anillo": contenedor = anillo; break;
            case "armadura1": contenedor = armadura1; break;
            case "armadura2": contenedor = armadura2; break;
            case "armadura3": contenedor = armadura3; break;
            case "armadura4": contenedor = armadura4; break;
            case "escudo": contenedor = escudo; break;
            case "hacha": contenedor = hacha; break;
            case "hierbas": contenedor = hierbas; break;
            case "gemaRoja": contenedor = gemaRoja; break;
            case "gemaAzul": contenedor = gemaAzul; break;
            case "gemaVerde": contenedor = gemaVerde; break;
            case "llave": contenedor = llave; break;
            case "moneda": contenedor = moneda; break;
            case "pan": contenedor = pan; break;
        }

        if (contenedor != null)
        {
            espaciosInventario[pos].sprite = contenedor;
            espaciosInventario[pos].enabled = true;
            textoContadores[pos].text = "x" + cantidad;
            textoContadores[pos].enabled = true;
        }
    }

    // Funciones genéricas para misiones
    public int GetCantidadItem(string item)
    {
        if (cantidadItems.ContainsKey(item))
            return cantidadItems[item];
        return 0;
    }

    public void RestarItem(string item, int cantidad)
    {
        if (!cantidadItems.ContainsKey(item)) return;
        cantidadItems[item] = Mathf.Max(0, cantidadItems[item] - cantidad);

        // Actualizar visual si está en inventario
        int pos = VerificaEnArreglo(item);
        if (pos != -1)
            textoContadores[pos].text = "x" + cantidadItems[item];
    }

    private void BorrarArreglo()
    {
        for (int i = 0; i < valoresInventario.Length; i++)
        {
            valoresInventario[i] = "";
        }
    }
}
