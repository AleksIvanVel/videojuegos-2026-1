using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumibleVida : MonoBehaviour
{
    public Sprite empty, full;
    private int numCuras;
    public int maxCuras;
    private bool PuedeCurar;
    public float tiempoDeCooldown;

    private GameObject player;
    private SpriteRenderer spriteRenderer;

    public GameObject consumible;
    void Start()
    {
        numCuras = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (VidasPlayer.vida < 5) // Validar si el jugador no tiene la vida completa
        {
            PuedeCurar = true;
        }
        else
        {
            PuedeCurar = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D obj)
    {

        if (obj.CompareTag("Player") && numCuras < maxCuras)
        {
            if (PuedeCurar)
            {
                numCuras++;
                AudioManager.instance.PlaySFX(AudioManager.instance.Cura);
            }
        }
        if (numCuras == maxCuras) // El objeto te puede curar n veces antes de desaparecer
        {
            spriteRenderer.sprite = empty;
            GetComponent<Collider2D>().enabled = false; //Se desactiva el Collider ya que esta vacia la botella

            StartCoroutine(RellenarBotella());
        }
    }

    IEnumerator RellenarBotella()
    {
        yield return new WaitForSeconds(tiempoDeCooldown);
            numCuras = 0; // Restablecer el contador de curas
        
            // Cambiar al sprite de botella llena
            spriteRenderer.sprite = full;
            
            // Reactivar el collider para que el jugador pueda usarla de nuevo
            GetComponent<Collider2D>().enabled = true;
    }
        
}
