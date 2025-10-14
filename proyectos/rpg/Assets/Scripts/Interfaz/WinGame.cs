using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{

    public string misionId;
    public GameObject winPanel;
    // Start is called before the first frame update
    void Start()
    {
        winPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        var mision = MisionManager.instance.ObtenerMisionPorId(misionId);

        if (mision != null)
        {
            if (mision.EstaCompletada)
            {
                MostrarWinPanel();
            }
        }
    }

    IEnumerator MostrarWinPanel()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.WinGame);
        AudioManager.instance.StopMusic();
        yield return new WaitForSeconds(0.3f);
        winPanel.SetActive(true);
        
        Time.timeScale = 0f; // Pausa el juego
    }
}
