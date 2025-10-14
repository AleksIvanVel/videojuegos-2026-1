using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public int vidaEnemigo = 1;
    public int numEnemigosEliminados = 0;
    private float frecAtaque = 0.5f, tiempoSigAtaque = 0, iniciaConteo;

    public Transform personaje;
    private NavMeshAgent agente;
    public Transform[] puntosRuta;
    private int indiceRuta = 0;
    private bool playerEnRango = false;
    [SerializeField] private float distanciaDeteccionPlayer;
    private SpriteRenderer spriteEnemigo;
    private Transform mirarHacia;
    [SerializeField] private float umbralLlegada = 0.2f; // Distancia para considerar que llegó al punto de ruta


    [SerializeField] 
    private string tipoEnemigo; 

    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        spriteEnemigo = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        vidaEnemigo = 1;
        agente.updateRotation = false;
        agente.updateUpAxis = false;
        agente.stoppingDistance = 0.05f;
        agente.autoBraking = false;
    }

    void Update()
    {
        this.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        float distancia = Vector3.Distance(personaje.position, this.transform.position);

        var objetivoRuta = puntosRuta[indiceRuta].position;
        // Usa una tolerancia para considerar que llego al punto
        if (Vector2.Distance(transform.position, objetivoRuta) <= umbralLlegada)
        {
            if (indiceRuta < puntosRuta.Length - 1)
            {
                indiceRuta++;
            }
            else
            {
                indiceRuta = 0;
            }
        }

        if (distancia < distanciaDeteccionPlayer)
        {
            playerEnRango = true;
        }
        else
        {
            playerEnRango = false;
        }

        if (tiempoSigAtaque > 0) {
            tiempoSigAtaque = frecAtaque + iniciaConteo - Time.time;
        } else {
            tiempoSigAtaque = 0;
            VidasPlayer.puedePerderVida = 1;
            SigueAlPlayer(playerEnRango);
            RotaEnemigo();
        }
    }

    private void SigueAlPlayer(bool playerEnRango)
    {
        if (playerEnRango) // Sigue al Player
        {
            agente.SetDestination(personaje.position);
            mirarHacia = personaje;
        }
        else // Regresa a su Ruta
        {
            agente.SetDestination(puntosRuta[indiceRuta].position);
            mirarHacia = puntosRuta[indiceRuta];
        }
    }

    private void RotaEnemigo()
    {
        if (this.transform.position.x > mirarHacia.position.x)
        {
            spriteEnemigo.flipX = true;
            Debug.Log("FipX");
        }
        else
        {
            spriteEnemigo.flipX = false;
            Debug.Log("Sin FipX");
        }
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            tiempoSigAtaque = frecAtaque;
            iniciaConteo = Time.time;
            obj.transform.GetComponentInChildren<VidasPlayer>().TomarDaño(1);
        }
    }

    public void TomarDaño(int daño)
    {
        vidaEnemigo -= daño;
        if (vidaEnemigo <= 0)
        {
            numEnemigosEliminados++;
            MisionManager.instance.ActualizarProgresoMision("enemigo", numEnemigosEliminados);
            if (AudioManager.instance.EliminarEnemigo != null)
            {
                AudioSource.PlayClipAtPoint(AudioManager.instance.EliminarEnemigo, transform.position);
            }
            Destroy(gameObject);
        }
    }
}
