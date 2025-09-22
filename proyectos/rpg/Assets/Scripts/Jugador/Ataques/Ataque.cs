using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public Transform ControladorAtaque;
    public float radioGolpe;
    public int danioGolpe;
    public float timeCooldownAtaques;
    public float timeNextAtaque;
    private Animator anim;

    public static bool atacando;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeNextAtaque < 0.05f && timeCooldownAtaques > 0)
        {
            atacando = false;
        }
        if (timeNextAtaque > 0)
        {
            timeNextAtaque -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1") && timeNextAtaque <= 0)
        {
            atacando = true;
            activaCapa("Atacar");
            Golpe();
            timeNextAtaque = timeCooldownAtaques;
        }
    }

    private void Golpe()
    {
        if (MovPlayer.dirAtaque == 1)
        {
            anim.SetTrigger("AtaqueFront");
        }
        else if (MovPlayer.dirAtaque == 2)
        {
            anim.SetTrigger("AtaqueBack");
        }
        else if (MovPlayer.dirAtaque == 3)
        {
            anim.SetTrigger("AtaqueIzquierda");
        }
        else if (MovPlayer.dirAtaque == 4)
        {
            anim.SetTrigger("AtaqueDerecha");
        }
    }

    private void VerificaGolpe()
    {
        Collider2D[] objs = Physics2D.OverlapCircleAll(ControladorAtaque.position, radioGolpe); // Verifica que golpeó
        foreach (Collider2D colisionador in objs)
        {
            if (colisionador.CompareTag("enemigo"))
            {
                colisionador.transform.GetComponent<Enemigo>().TomarDaño(danioGolpe);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(ControladorAtaque.position, radioGolpe);
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
