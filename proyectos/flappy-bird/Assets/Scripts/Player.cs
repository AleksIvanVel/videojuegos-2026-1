using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instancia;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Animator anim;
    public bool yaVolo, estaVivo;
    public float valorOffset = 0;

    private float velocidad = 3.0f, fuerzarebote = 4.0f;
    private Button btnvolar;

    private int score;

    public AudioClip sonidoPunto, sonidoMorir, sonidoVuelo;
    private AudioSource audioVuelo;
    private AudioSource audioPunto;
    private AudioSource audioMorir;

    public Text txtScore;
    public FinJuego finJuegoManager;

    void Awake()
    {
        score = 0;
        if (instancia == null)
        {
            instancia = this;
        }
        estaVivo = true;
        btnvolar = GameObject.FindGameObjectWithTag("btnVolar").GetComponent<Button>();
        btnvolar.onClick.AddListener( () => VuelaSteve() );
        AsignaPosXCamara();

        ConfigurarAudioSources();
    }

    private void ConfigurarAudioSources()
    {
        audioVuelo = gameObject.AddComponent<AudioSource>();
        audioVuelo.clip = sonidoVuelo;
        audioVuelo.playOnAwake = false;

        audioPunto = gameObject.AddComponent<AudioSource>();
        audioPunto.clip = sonidoPunto;
        audioPunto.playOnAwake = false;

        audioMorir = gameObject.AddComponent<AudioSource>();
        audioMorir.clip = sonidoMorir;
        audioMorir.playOnAwake = false;

        ActualizarVolumenEfectos();
    }

    void FixedUpdate()
    {
        if (estaVivo)
        {
            Vector3 temp = transform.position;
            temp.x += velocidad * Time.deltaTime;
            transform.position = temp;

            if (yaVolo)
            {
                yaVolo = false;
                rb2d.velocity = new Vector2(0, fuerzarebote);
                anim.SetTrigger("volando");

                ActualizarVolumenEfectos();
                audioVuelo.Play();
            }

            if (rb2d.velocity.y >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            } else
            {
                float angulo = 0;
                angulo = Mathf.Lerp(0, -90, -rb2d.velocity.y / 21);
                transform.rotation = Quaternion.Euler(0, 0, angulo);
            }
        }
    }

    private void AsignaPosXCamara()
    {
        CamaraScript.offsetX = Camera.main.transform.position.x - transform.position.x - valorOffset;
    }

    public float ObtenerPosX()
    {
        return transform.position.x;
    }

    private void VuelaSteve()
    {
        yaVolo = true;
    }

    private void ActualizarVolumenEfectos()
    {
        if (Musica.instancia != null)
        {
            float volumen = Musica.instancia.ObtenerVolumenEfectos();
            if (audioVuelo != null)
                audioVuelo.volume = volumen;
            if (audioPunto != null)
                audioPunto.volume = volumen;
            if (audioMorir != null)
                audioMorir.volume = volumen;
        }
    }

    private void OnTriggerEnter2D(Collider2D objColisionado)
    {
        if (objColisionado.tag == "grupoEstalactitas")
        {
            score++;
            txtScore.text = score.ToString();
            
            ActualizarVolumenEfectos();
            audioPunto.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D objColisionado)
    {
        if (objColisionado.gameObject.tag == "piso" || objColisionado.gameObject.tag == "estalactita")
        {
            if (estaVivo)
            {
                estaVivo = false;
                anim.SetTrigger("muere");
                
                ActualizarVolumenEfectos();
                audioMorir.Play();

                MenuPrincipal.ActualizarRecord(score);

                if (finJuegoManager != null)
                {
                    finJuegoManager.MostrarFinJuego(score);
                }
            }
        }
    }
}
