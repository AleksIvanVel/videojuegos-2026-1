using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    private Vector2 dirMov;
    public float velMov;
    public Rigidbody2D rb;
    public Animator anim;

    // Varibales para control de animacion entre caminar, atacar e idle
    private string capaIdle = "Idle";
    private string capaCaminar = "Caminar";
    private string capaAtaque = "Atacar";
    private bool PlayerMoviendose = false;
    private float ultMovx, ultMovy;

    public static int dirAtaque = 0; // 1 ~ Front, 2 ~ Back, 3 ~ Left, 4 ~ Right

    [Header("Sonidos")]

    public AudioClip Caminar;

    

    void FixedUpdate()
    {
        if (Ataque.atacando == false && Disparo.disparando == false)
        {
            Movimiento();
            AnimacionesPlayer();
        }
    }


    private void Movimiento()
    {
       float movX = Input.GetAxisRaw("Horizontal");
       float movY = Input.GetAxisRaw("Vertical");

        dirMov = new Vector2(movX, movY).normalized; 
        rb.velocity = new Vector2(dirMov.x * velMov, dirMov.y * velMov);

        // Ataque
        if (movX == -1)
        {
            dirAtaque = 3;
        }
        if (movX == 1)
        {
            dirAtaque = 4;
        }
        if (movY == -1)
        {
            dirAtaque = 1;
        }
        if (movY == 1)
        {
            dirAtaque = 2;
        }

        if (movX == 0 && movY == 0) // Idle
        {
            PlayerMoviendose = false;
        }
        else // Caminar
        {
            PlayerMoviendose = true;
            AudioManager.instance.PlaySFX(Caminar);
            ultMovx = movX;
            ultMovy = movY;
        }

        ActualizarCapa();
    }

    private void AnimacionesPlayer()
    {
        anim.SetFloat("movX", ultMovx);
        anim.SetFloat("movY", ultMovy);
    }

    private void ActualizarCapa()
    {
        if (Ataque.atacando == false && Disparo.disparando == false)
        {
            if (PlayerMoviendose)
            {
                activaCapa(capaCaminar);
            }
            else
            {
                activaCapa(capaIdle);
            }
        }
        else
        {
            activaCapa(capaAtaque);
        }
    }

    public void ForzarIdle()
    {
        activaCapa(capaIdle);
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
