using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    [SerializeField] private GameObject proyectil;
    public float timeCooldownAtaques;
    public float timeNextAtaque;
    public Transform puntoEmision;
    private Animator anim;

    private GameObject player;

    public static int dirDisparo = 0;
    public static bool disparando = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (timeNextAtaque < 0.05f && timeCooldownAtaques > 0)
        {
            disparando = false;
        }
        if (timeNextAtaque > 0)
        {
            timeNextAtaque -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire2") && timeNextAtaque <= 0 && VidasPlayer.mana > 0)
        {
            disparando = true;
            activaCapa("Atacar");
            Disparar();
            VidasPlayer.mana--;
            player.GetComponent<VidasPlayer>().DibujarMana(VidasPlayer.mana);
            timeNextAtaque = timeCooldownAtaques;
        }
    }

    private void Disparar()
    {
        if (MovPlayer.dirAtaque == 1)
        {
            anim.SetTrigger("DisparaFront");
        }
        else if (MovPlayer.dirAtaque == 2)
        {
            anim.SetTrigger("DisparaBack");
        }
        else if (MovPlayer.dirAtaque == 3)
        {
            anim.SetTrigger("DisparaIzquierda");
        }
        else if (MovPlayer.dirAtaque == 4)
        {
            anim.SetTrigger("DisparaDerecha");
        }
    }

    private void EmiteProyectil()
    {
        dirDisparo = MovPlayer.dirAtaque;
        Instantiate(proyectil, puntoEmision.position, transform.rotation);
    }

    private void activaCapa(string capa)
    {
        for (int i = 0; i<anim.layerCount; i++)
        {
            anim.SetLayerWeight(i, 0); // Desactiva todas las capas
        }
        anim.SetLayerWeight(anim.GetLayerIndex(capa), 1); // Activa la capa especificada
    }
}
