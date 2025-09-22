using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionables : MonoBehaviour
{
    private GameObject player;
    public static string objColeccionables;
    private Inventario inventario;
    void Start()
    {
        player = GameObject.Find("Player");
        objColeccionables = "";
        inventario = FindObjectOfType<Inventario>();
    }

    public void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "vida")
        {
            if (VidasPlayer.vida < 5)
            {
                VidasPlayer.vida++;
                player.GetComponent<VidasPlayer>().DibujarVida(VidasPlayer.vida);
            }
        }
        if (obj.tag == "mana")
        {
            Debug.Log("mana");
            Destroy(obj.gameObject);
        }
        if (obj.tag == "coleccionable")
        {
            Debug.Log("coleccionable");
            Destroy(obj.gameObject);
        }
    }

    private void AplicaCambios(Collider2D obj)
    {
        objColeccionables = obj.tag;
        inventario.EscribeEnArreglo();
        Destroy(obj.gameObject);
    }
}
