using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColisionesPlayer : MonoBehaviour
{
    public AudioSource sonido;
    public AudioClip agua;
    public Image comida;
    public GameObject videoGasolinera;
    public GameObject videoSabrina;
    public GameObject videoWonderWoman;
    // Start is called before the first frame update
    void Start()
    {
        //Oculta por defecto la imagen de comida y el video
        comida.gameObject.SetActive(false);
        videoGasolinera.SetActive(false);
        videoSabrina.SetActive(false);
        videoWonderWoman.SetActive(false);
    }

    private void OnTriggerEnter(Collider obj)
    {
        if(obj.tag == "comida")
        {
            comida.gameObject.SetActive(true);
        }
        if (obj.tag == "gasolinera")
        {
            videoGasolinera.SetActive(true);
        }
        if (obj.tag == "sabrina")
        {
            videoSabrina.SetActive(true);
        }
        if (obj.tag == "wonderwoman")
        {
            videoWonderWoman.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider obj)
    {
        if (obj.tag == "comida")
        {
            comida.gameObject.SetActive(false);
        }
        if (obj.tag == "gasolinera")
        {
            videoGasolinera.SetActive(false);
        }
        if (obj.tag == "sabrina")
        {
            videoSabrina.SetActive(false);
        }
        if (obj.tag == "wonderwoman")
        {
            videoWonderWoman.SetActive(false);
        }
    }
}
