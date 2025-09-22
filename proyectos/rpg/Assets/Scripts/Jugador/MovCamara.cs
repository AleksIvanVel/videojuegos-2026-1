using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    public Camera camara;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Colision con portales del Mundo 1
        if (collision.gameObject.tag == "UpM1") // Ir a Mundo 3
        {
           Vector3 posicionCamara = new Vector3(0, 17, -10);
           camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(3.45f, 13.66f, 0);
            this.transform.position = posicionPlayer;
        }

        if (collision.gameObject.tag == "AbM1") // Ir a Mundo 5
        {
            Vector3 posicionCamara = new Vector3(0, -17, -10);
            camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(3.45f, -13.29f, 0);
            this.transform.position = posicionPlayer;
        }

        if (collision.gameObject.tag == "IzM1")
        {
            Vector3 posicionCamara = new Vector3(0, 10, -10);
            camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(0, 4, 0);
            this.transform.position = posicionPlayer;
        }

        if (collision.gameObject.tag == "DrM1") // Ir a mundo 2
        {
            Vector3 posicionCamara = new Vector3(29f, 0, -10);
            camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(21.4f, 0.7f, 0);
            this.transform.position = posicionPlayer;
        }

        // Colision con portales del Mundo 2
        if (collision.gameObject.tag == "UpM2") // Ir a Mundo 4
        {
            Vector3 posicionCamara = new Vector3(29, 17, -10);
            camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(22f, 13.7f, 0);
            this.transform.position = posicionPlayer;
        }
        if (collision.gameObject.tag == "Up2M2") // Ir a Mundo 4
        {
            Vector3 posicionCamara = new Vector3(29, 17, -10);
            camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(36, 13.7f, 0);
            this.transform.position = posicionPlayer;
        }
        if (collision.gameObject.tag == "AbM2") // Ir a Mundo 6
        {
            Vector3 posicionCamara = new Vector3(29, -17, -10);
            camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(21.5f, -13.35f, 0);
            this.transform.position = posicionPlayer;
        }
        
        if (collision.gameObject.tag == "Ab2M2") // Ir a Mundo 6
        {
            Vector3 posicionCamara = new Vector3(29, -17, -10);
            camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(24.5f, -13.35f, 0);
            this.transform.position = posicionPlayer;
        }

        if (collision.gameObject.tag == "IzM2") //Ir a mundo 1
        {
            Vector3 posicionCamara = new Vector3(0, 0, -10);
            camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(7.6f, 0.7f, 0);
            this.transform.position = posicionPlayer;
        }

        // Colision con portales del Mundo 3
        if (collision.gameObject.tag == "AbM3") // Ir a Mundo 1
        {
            Vector3 posicionCamara = new Vector3(0, 0, -10);
            camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(3.45f, 4f, 0);
            this.transform.position = posicionPlayer;
        }

        if (collision.gameObject.tag == "IzM3")
        {
            Vector3 posicionCamara = new Vector3(0, 17, -10);
            camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(-7.66f, 17.75f, 0);
            this.transform.position = posicionPlayer;
        }

        if (collision.gameObject.tag == "DrM3") //Ir a Mundo 4
        {
            Vector3 posicionCamara = new Vector3(29, 17, -10);
            camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(21.48f, 21.6f, 0);
            this.transform.position = posicionPlayer;
        }

        if (collision.gameObject.tag == "Dr2M3") //Ir a Mundo 4
        {
            Vector3 posicionCamara = new Vector3(29, 17, -10);
            camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(21.48f, 13.7f, 0);
            this.transform.position = posicionPlayer;
        }

        // Colision con portales del Mundo 4
        if (collision.gameObject.tag == "AbM4") // Ir a Mundo 2
        {
            Vector3 posicionCamara = new Vector3(29f, 0, -10);
            camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(22f, 4f, 0);
            this.transform.position = posicionPlayer;
        }

        if (collision.gameObject.tag == "Ab2M4") // Ir a Mundo 2
        {
            Vector3 posicionCamara = new Vector3(29f, 0, -10);
            camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(36f, 4f, 0);
            this.transform.position = posicionPlayer;
        }

        if (collision.gameObject.tag == "IzM4") //Ir a Mundo 3
        {
            Vector3 posicionCamara = new Vector3(0, 17, -10);
           camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(7.5f, 21.6f, 0);
            this.transform.position = posicionPlayer;
        }

        if (collision.gameObject.tag == "Iz2M4") //Ir a Mundo 3
        {
            Vector3 posicionCamara = new Vector3(0, 17, -10);
           camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(7.5f, 13.6f, 0);
            this.transform.position = posicionPlayer;
        }

        // Colision con portales del Mundo 5
        if (collision.gameObject.tag == "UpM5") // Ir a Mundo 1
        {
            Vector3 posicionCamara = new Vector3(0, 0, -10);
            camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(3.45f, -3.5f, 0);
            this.transform.position = posicionPlayer;
        }

        if (collision.gameObject.tag == "DrM5") // Ir a Mundo 6
        {
            Vector3 posicionCamara = new Vector3(29, -17, -10);
            camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(21.46f, -17.3f, 0);
            this.transform.position = posicionPlayer;
        }

        // Colision con portales del Mundo 6
        if (collision.gameObject.tag == "UpM6") // Ir a Mundo 2
        {
            Vector3 posicionCamara = new Vector3(29, 0, -10);
            camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(21.5f, -4f, 0);
            this.transform.position = posicionPlayer;
        }

        if (collision.gameObject.tag == "Up2M6") // Ir a Mundo 2
        {
            Vector3 posicionCamara = new Vector3(29, 0, -10);
            camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(24.5f, -4f, 0);
            this.transform.position = posicionPlayer;
        }

        if (collision.gameObject.tag == "IzM6") // Ir a Mundo 5
        {
            Vector3 posicionCamara = new Vector3(0, -17, -10);
            camara.transform.position = posicionCamara;

            Vector3 posicionPlayer = new Vector3(7f, -17.4f, 0);
            this.transform.position = posicionPlayer;
        }
    }
}