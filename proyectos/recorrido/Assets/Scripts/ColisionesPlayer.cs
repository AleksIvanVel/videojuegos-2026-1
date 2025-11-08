using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColisionesPlayer : MonoBehaviour
{
    public AudioSource sonido;
    public AudioClip bombagas;
    public AudioClip policia;
    public AudioClip jardin;
    public AudioClip burger;
    public AudioClip atm;
    public Image comida;
    public GameObject videoGasolinera;
    public GameObject videoSabrina;
    public GameObject videoBurger;
    public GameObject videoWonderWoman;
    // Start is called before the first frame update
    void Start()
    {
        //Oculta por defecto la imagen de comida y el video
        comida.gameObject.SetActive(false);
        videoGasolinera.SetActive(false);
        videoSabrina.SetActive(false);
        videoWonderWoman.SetActive(false);
        videoBurger.SetActive(false);
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "bombagas")
        {
            sonido.PlayOneShot(bombagas);
        }
        if (obj.tag == "burger")
        {
            sonido.PlayOneShot(burger);
        }
        if (obj.tag == "jardin")
        {
            sonido.PlayOneShot(jardin);
        }
        if (obj.tag == "atm")
        {
            sonido.PlayOneShot(atm);
        }
        if (obj.tag == "policia")
        {
            sonido.PlayOneShot(policia);
        }
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
        if (obj.tag == "burgervid")
        {
            videoBurger.SetActive(true);
        }
        if (obj.tag == "wonderwoman")
        {
            videoWonderWoman.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider obj)
    {
        sonido.Stop();

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
        if (obj.tag == "burgervid")
        {
            videoBurger.SetActive(false);
        }
    }
}
