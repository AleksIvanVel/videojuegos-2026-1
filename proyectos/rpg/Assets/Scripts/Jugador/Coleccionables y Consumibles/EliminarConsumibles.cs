using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminarConsumibles : MonoBehaviour
{
    public int numVisitas;

    private GameObject player;

    public GameObject consumible;
    void Start()
    {
        numVisitas = 0;
        player = GameObject.Find("Player");
    }

    public void OnTriggerEnter2D (Collider2D obj)
    {
        if (VidasPlayer.vida < 5)
        {
            numVisitas++;
        }

        if (numVisitas == 2) // El objeto te puede curar 2 veces antes de desaparecer
        {
            Destroy(consumible);
        }
    }
        
}
