using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionadorFondo : MonoBehaviour
{
    private GameObject[] fondos;
    private GameObject[] pisos;

    private float ultimaXFondo;
    private float ultimaXPiso;

    void Awake()
    {
        fondos = GameObject.FindGameObjectsWithTag("fondo");
        pisos = GameObject.FindGameObjectsWithTag("piso");

        ultimaXFondo = fondos[0].transform.position.x;
        ultimaXPiso = pisos[0].transform.position.x;

        for (int i = 0; i < fondos.Length; i++)
        {
            if (ultimaXFondo < fondos[i].transform.position.x)
            {
                ultimaXFondo = fondos[i].transform.position.x;
            }
        }

        for (int i = 0; i < pisos.Length; i++)
        {
            if (ultimaXPiso < pisos[i].transform.position.x)
            {
                ultimaXPiso = pisos[i].transform.position.x;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D objColisionado)
    {
        if (objColisionado.tag == "fondo")
        {
            Vector3 temp = objColisionado.transform.position;
            float ancho = ((BoxCollider2D) objColisionado).size.x;
            temp.x = ultimaXFondo + ancho;

            objColisionado.transform.position = temp;
            ultimaXFondo = temp.x;
        }

        if (objColisionado.tag == "piso")
        {
            Vector3 temp = objColisionado.transform.position;
            float ancho = ((BoxCollider2D)objColisionado).size.x;
            temp.x = ultimaXPiso + ancho;
            objColisionado.transform.position = temp;
            ultimaXPiso = temp.x;
        }
    }
}
