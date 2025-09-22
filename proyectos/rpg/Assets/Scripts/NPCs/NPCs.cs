using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCs : MonoBehaviour
{

    public GameObject txtDialogo;
    public  int numVisitas;

    public Sprite txt1, txt2;

    void Start()
    {
        txtDialogo.SetActive(false);
        numVisitas = 0;
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            txtDialogo.SetActive(true);
            EscribeDialogo();
            numVisitas++;
        }
        
    }

    private void EscribeDialogo()
    {
        switch (numVisitas)
        {
            case 0:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = txt1;
                break;
            case 1:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = txt2;
                numVisitas = -1;
                break;
        }
    }
}
