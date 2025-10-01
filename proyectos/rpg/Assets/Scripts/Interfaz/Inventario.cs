using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    private bool muestraInventario;
    public GameObject goInventario;
    [SerializeField] private string[] valoresInventario; // "" - sin elemento, string - elemento
    private int numGemasAzules, numGemasRojas, numGemasVerdes, numMonedas;
    public Image[] espaciosInventario; // Arreglo para los slots
    public Text[] textoContadores; // Arreglo para los textos de cantidad
    public Sprite gemaAzul, gemaRoja, gemaVerde, moneda, contenedor;

    void Start()
    {
        muestraInventario = false;
        BorrarArreglo();
        numGemasAzules = 0;
        numGemasRojas = 0;
        numGemasVerdes = 0;
        numMonedas = 0;

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
        if (muestraInventario)
        {
            muestraInventario = false;
            goInventario.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            muestraInventario = true;
            goInventario.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void EscribeEnArreglo()
    {
        Debug.Log("EscribeEnArreglo llamado. Tamaño de valoresInventario: " + valoresInventario.Length);
        if (VerificaEnArreglo() == -1) //No esta en el inventario
        {
            for (int i = 0; i < valoresInventario.Length; i++)
            {
                if (valoresInventario[i] == "") //Lo coloca en la primera posicion vacia que encuentre
                {
                    valoresInventario[i] = Coleccionables.objColeccionables;
                    DibujaElementos(i);
                    break;
                }
            }
        }
        else // Si ya esta en el inventario ubica su posicion y suma uno al elemento
        {
            DibujaElementos(VerificaEnArreglo());
        }
    }

    private int VerificaEnArreglo()
    {
        
        int pos = -1;
        for (int i = 0; i < valoresInventario.Length; i++)
        {
            
            if (valoresInventario[i] == Coleccionables.objColeccionables)
            {
                pos = i;
                Debug.Log(pos.ToString());
                break;
            }
        }
        return pos;
    }

    public void DibujaElementos(int pos)
    {
         Debug.Log("Intentando dibujar '" + Coleccionables.objColeccionables + "' en la posición " + pos);
        switch (Coleccionables.objColeccionables)
        {
            case "gemaRoja":
                contenedor = gemaRoja;
                numGemasRojas++;
                textoContadores[pos].text = "x" + numGemasRojas.ToString();
                textoContadores[pos].enabled = true;
                break;
            case "gemaAzul":
                contenedor = gemaAzul;
                numGemasAzules++;
                textoContadores[pos].text = "x" + numGemasAzules.ToString();
                textoContadores[pos].enabled = true;
                break;
            case "gemaVerde":
                contenedor = gemaVerde;
                numGemasVerdes++;
                textoContadores[pos].text = "x" + numGemasVerdes.ToString();
                textoContadores[pos].enabled = true;
                break;
            case "moneda":
                contenedor = moneda;
                numMonedas++;
                textoContadores[pos].text = "x" + numMonedas.ToString();
                textoContadores[pos].enabled = true;
                break;
        }
        if (contenedor != null)
        {
        espaciosInventario[pos].sprite = contenedor;
        espaciosInventario[pos].enabled = true; // Hacemos visible el sprite
        }
    }

    private void BorrarArreglo()
    {
        for (int i = 0; i < valoresInventario.Length; i++)
        {
            valoresInventario[i] = "";
        }
    }
}
