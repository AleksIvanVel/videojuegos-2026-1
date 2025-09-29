using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminarConsumibles : MonoBehaviour
{
    private int numCuras;
    public int maxCuras;

    private GameObject player;

    public GameObject consumible;
    void Start()
    {
        numCuras = 0;
        player = GameObject.Find("Player");
    }

    public void OnTriggerEnter2D(Collider2D obj)
    {

        if (obj.CompareTag("Player"))
        {
            if (VidasPlayer.vida < 5)
            {
                numCuras++;
            }
        }
        if (numCuras == maxCuras) // El objeto te puede curar n veces antes de desaparecer
            {
                Destroy(consumible);
            }
    }
        
}
