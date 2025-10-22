using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public string misionId;
    public GameObject winPanel;
    private bool isGameWon = false; // Bandera para evitar llamadas múltiples

    void Start()
    {
        winPanel.SetActive(false);
    }

    void Update()
    {
        // Si el juego ya terminó, no hagas nada.
        if (isGameWon) return;

        var mision = MisionManager.instance.ObtenerMisionPorId(misionId);

        if (mision != null && mision.EstaCompletada)
        {
            isGameWon = true;
            
            StartCoroutine(MostrarWinPanel());
        }
    }

    IEnumerator MostrarWinPanel()
    {
        AudioManager.instance.PlayUnscaledSFX(AudioManager.instance.WinGame);
        AudioManager.instance.StopMusic();

        // Usamos WaitForSecondsRealtime porque Time.timeScale se pondrá en 0
        yield return new WaitForSecondsRealtime(0.3f);
        
        winPanel.SetActive(true);
        Time.timeScale = 0f; // Pausa el juego
    }
}