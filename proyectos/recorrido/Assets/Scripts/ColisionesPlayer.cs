using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColisionesPlayer : MonoBehaviour
{
    public AudioSource sonido;
    public AudioClip agua;
    public Image comida;
    public GameObject video;
    // Start is called before the first frame update
    void Start()
    {
        //Oculta por defecto la imagen de comida y el video
        comida.gameObject.SetActive(false);
        video.SetActive(false);
    }

    private void OnTriggerEnter(Collider obj)
    {
        if(obj.tag == "comida")
        {
            comida.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider obj)
    {
        if (obj.tag == "comida")
        {
            comida.gameObject.SetActive(false);
        }
    }
}
