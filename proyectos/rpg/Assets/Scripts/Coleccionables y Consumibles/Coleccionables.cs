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
            if (VidasPlayer.mana < 5)
            {
                VidasPlayer.mana++;
                player.GetComponent<VidasPlayer>().DibujarMana(VidasPlayer.mana);
            }
        }
        if (obj.tag == "coleccionable")
        {
            AplicaCambios(obj);
        }
    }

    private void AplicaCambios(Collider2D obj)
    {
        ItemsID identificador = obj.GetComponent<ItemsID>();
        if (identificador != null)
        {
            objColeccionables = identificador.itemId;
            Debug.Log("Recolectado: "+ objColeccionables);
            inventario.EscribeEnArreglo();
            Destroy(obj.gameObject);
        }
    }
}
