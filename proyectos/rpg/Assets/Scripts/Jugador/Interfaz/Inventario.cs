using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    private bool muestraInventario;
    public GameObject goInventario;
    [SerializeField] private string[] valoresInventario; // "" - sin elemento, string - elemento
    private int numGemasVerdes, numGemasAzules, numGemasRojas, numPocionesVerdes, numPocionesAzules, numPocionesRojas;
    Button boton; //botones del inventario
    public Sprite mochila, sobre, mapa, pergamino, libro, herramientas, gemaRoja, gemaVerde, gemaAzul, pocionRoja, pocionVerde, pocionAzul, contenedor;

    void Start()
    {
        muestraInventario = false;
        BorrarArreglo();
        numGemasAzules = 0;
        numGemasRojas = 0;
        numGemasVerdes = 0;
        numPocionesAzules = 0;
        numPocionesRojas = 0;
        numPocionesVerdes = 0;

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
                break;
            }
        }
        return pos;
    }

    public void DibujaElementos(int pos)
    {
        boton = GameObject.Find("elemento (" + pos + ")").GetComponent<Button>();
        switch (Coleccionables.objColeccionables)
        {
            case "mochila":
                contenedor = mochila;
                break;
            case "sobre":
                contenedor = sobre;
                break;
            case "mapa":
                contenedor = mapa;
                break;
            case "pergamino":
                contenedor = pergamino;
                break;
            case "libro":
                contenedor = libro;
                break;
            case "herramientas":
                contenedor = herramientas;
                break;
            case "gemaRoja":
                contenedor = gemaRoja;
                numGemasRojas++;
                boton.GetComponentInChildren<Text>().text = "x" + numGemasRojas.ToString();
                break;
            case "gemaAzul":
                contenedor = gemaAzul;
                numGemasAzules++;
                boton.GetComponentInChildren<Text>().text = "x" + numGemasAzules.ToString();
                break;
            case "gemaVerde":
                contenedor = gemaVerde;
                numGemasVerdes++;
                boton.GetComponentInChildren<Text>().text = "x" + numGemasVerdes.ToString();
                break;
            case "pocionAzul":
                contenedor = pocionAzul;
                numPocionesAzules++;
                boton.GetComponentInChildren<Text>().text = "x" + numPocionesAzules.ToString();
                break;
            case "pocionRoja":
                contenedor = pocionRoja;
                numPocionesRojas++;
                boton.GetComponentInChildren<Text>().text = "x" + numPocionesRojas.ToString();
                break;
            case "pocionVerde":
                contenedor = pocionVerde;
                numPocionesVerdes++;
                boton.GetComponentInChildren<Text>().text = "x" + numPocionesVerdes.ToString();
                break;
        }
        boton.GetComponent<Image>().sprite = contenedor;
    }

    private void BorrarArreglo()
    {
        for (int i = 0; i < valoresInventario.Length; i++)
        {
            valoresInventario[i] = "";
        }
    }
}
