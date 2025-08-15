using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    public Camera camara;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Colision con portales del Mundo 1
        //if (collision.gameObject.tag == "pArriba-m1")
        //{
        //   Vector3 posicionCamara = new Vector3(0, 10, -10);
        //    camara.transform.position = posicionCamara;

        //    Vector3 posicionPlayer = new Vector3(0, 4, 0);
        //    this.transform.position = posicionPlayer;
        //}

        //if (collision.gameObject.tag == "pAbajo-m1")
        //{
        //    Vector3 posicionCamara = new Vector3(0, 10, -10);
        //    camara.transform.position = posicionCamara;

        //    Vector3 posicionPlayer = new Vector3(0, 4, 0);
        //    this.transform.position = posicionPlayer;
        //}

        //if (collision.gameObject.tag == "pIzquierda-m1")
        //{
        //    Vector3 posicionCamara = new Vector3(0, 10, -10);
        //    camara.transform.position = posicionCamara;

        //    Vector3 posicionPlayer = new Vector3(0, 4, 0);
        //    this.transform.position = posicionPlayer;
        //}

        if (collision.gameObject.tag == "pDerecha-m1")
        {
            Vector3 posicionCamara = new Vector3(29f, 0, -10); // Va a mundo 2
            camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(21.4f, 0.7f, 0);
            this.transform.position = posicionPlayer;
        }

        // Colision con portales del Mundo 2
        //if (collision.gameObject.tag == "pArriba-1-m2")
        //{
        //    Vector3 posicionCamara = new Vector3(0, 10, -10);
        //    camara.transform.position = posicionCamara;

        //    Vector3 posicionPlayer = new Vector3(0, 4, 0);
        //    this.transform.position = posicionPlayer;
        //}
        //if (collision.gameObject.tag == "pArriba-2-m2")
        //{
        //    Vector3 posicionCamara = new Vector3(0, 10, -10);
        //    camara.transform.position = posicionCamara;

        //    Vector3 posicionPlayer = new Vector3(0, 4, 0);
        //    this.transform.position = posicionPlayer;
        //}
        //if (collision.gameObject.tag == "pAbajo-1-m2")
        //{
        //    Vector3 posicionCamara = new Vector3(0, 10, -10);
        //    camara.transform.position = posicionCamara;

        //    Vector3 posicionPlayer = new Vector3(0, 4, 0);
        //    this.transform.position = posicionPlayer;
        //}
        //if (collision.gameObject.tag == "pAbajo-1-m2")
        //{
        //    Vector3 posicionCamara = new Vector3(0, 10, -10);
        //    camara.transform.position = posicionCamara;

        //    Vector3 posicionPlayer = new Vector3(0, 4, 0);
        //    this.transform.position = posicionPlayer;
        //}

        if (collision.gameObject.tag == "pIzquierda-m2") //Regresa a mundo 1
        {
            Vector3 posicionCamara = new Vector3(0, 0, -10);
            camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(7.6f, 0.7f, 0);
            this.transform.position = posicionPlayer;
        }
    }

}
