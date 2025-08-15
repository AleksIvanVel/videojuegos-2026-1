using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector2 dirMov;
    public float velMov;
    public Rigidbody2D rb;
    public Animator anim;

    // Varibales para control de animacion entre caminar e idle
    private string capaIdle = "Idle";
    private string capaCaminar = "Caminar";
    private bool PlayerMoviendose = false;
    private float ultMovx, ultMovy;

    void FixedUpdate()
    {
        Movimiento();
        AnimacionesPlayer();
    }


    private void Movimiento()
    {
       float movX = Input.GetAxisRaw("Horizontal");
       float movY = Input.GetAxisRaw("Vertical");

        dirMov = new Vector2(movX, movY).normalized; 
        rb.velocity = new Vector2(dirMov.x * velMov, dirMov.y * velMov);

        if (movX == 0 && movY == 0) // Idle
        {
            PlayerMoviendose = false;
        }
        else // Caminar
        {
            PlayerMoviendose = true;
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
        if (PlayerMoviendose) 
        { 
            activaCapa(capaCaminar);
            Debug.Log("Capa de caminar activada");
        }
        else
        {
            activaCapa(capaIdle);
            Debug.Log("Capa de idle activada");
        }
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
