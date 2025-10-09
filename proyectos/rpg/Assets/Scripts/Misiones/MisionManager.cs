using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisionManager : MonoBehaviour
{
    public static MisionManager instance;

    public List<Mision> misiones = new List<Mision>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AgregarMision(Mision nuevaMision)
    {
        misiones.Add(nuevaMision);
    }

    public Mision ObtenerMisionPorId(string misionId)
    {
        return misiones.Find(q => q.misionId == misionId);
    }

    public void CompletarMision(string misionId)
    {
        Mision mision = ObtenerMisionPorId(misionId);
        if (mision != null)
        {
            mision.EstaCompletada = true;
            mision.EstaActiva = false;
            Debug.Log("Misión completada: " + mision.misionNombre);
        }
    }
}
