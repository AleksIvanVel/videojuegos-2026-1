using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionadorEstalactitas : MonoBehaviour
{
    private GameObject[] grupoEstalactitas;
    private float distancia = 8.0f;
    private float ultimaXEstalactita;
    private float yminEstalactita = -2.0f;
    private float ymaxEstalactita = 2.0f;

    void Awake()
    {
        grupoEstalactitas = GameObject.FindGameObjectsWithTag("grupoEstalactitas");
        for (int i = 0; i< grupoEstalactitas.Length; i++)
        {
            Vector3 temp = grupoEstalactitas[i].transform.position;
            temp.y = Random.Range(yminEstalactita, ymaxEstalactita);
            grupoEstalactitas[i].transform.position = temp;
        }

        ultimaXEstalactita = grupoEstalactitas[0].transform.position.x;

        for (int i = 0; i < grupoEstalactitas.Length; i++)
        {
            if (ultimaXEstalactita < grupoEstalactitas[i].transform.position.x)
            {
                ultimaXEstalactita = grupoEstalactitas[i].transform.position.x;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D objColisionado)
    {
        if (objColisionado.tag == "grupoEstalactitas")
        {
            Vector3 temp = objColisionado.transform.position;
            temp.x = ultimaXEstalactita + distancia;
            temp.y = Random.Range(yminEstalactita, ymaxEstalactita);
            objColisionado.transform.position = temp;
            ultimaXEstalactita = temp.x;
        }
    }
}
