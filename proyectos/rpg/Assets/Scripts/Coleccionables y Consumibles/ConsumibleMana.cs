using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumibleMana : MonoBehaviour
{
    public Sprite empty, full;
    private int numMana;
    public int maxMana;
    private bool PuedeMana;
    public float tiempoDeCooldown;

    private GameObject player;
    private SpriteRenderer spriteRenderer;

    public GameObject consumible;
    void Start()
    {
        numMana = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (VidasPlayer.mana < 10) // Validar si el jugador no tiene el mana completo
        {
            PuedeMana = true;
        }
        else
        {
            PuedeMana = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D obj)
    {

        if (obj.CompareTag("Player") && numMana < maxMana)
        {
            if (PuedeMana)
            {
                numMana++;
            }
        }
        if (numMana == maxMana) // El objeto te puede reponer Mana n veces antes de desaparecer
        {
            spriteRenderer.sprite = empty;
            GetComponent<Collider2D>().enabled = false; //Se desactiva el Collider ya que esta vacia la botella

            StartCoroutine(RellenarBotella());
        }
    }
    
    IEnumerator RellenarBotella()
    {
        yield return new WaitForSeconds(tiempoDeCooldown);
            numMana = 0; // Restablecer el contador de curas
        
            // Cambiar al sprite de botella llena
            spriteRenderer.sprite = full;
            
            // Reactivar el collider para que el jugador pueda usarla de nuevo
            GetComponent<Collider2D>().enabled = true;
    }
        
}
