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

    public Mision ObtenerMisionPorId(string idMision)
    {
        return misiones.Find(m => m.idMision == idMision);
    }

    public void CompletarMision(string idMision)
    {
        Mision m = ObtenerMisionPorId(idMision);

        // si no existe la misión, termina la función
        if (m == null) return;

        //Si ya está completada termian la funcion
        if (m.EstaCompletada) return;

        m.EstaActiva = false;
        m.EstaCompletada = true;

        // Asigna recompensas en el inventario del jugador
        Inventario inventario = GameObject.FindObjectOfType<Inventario>();
        if (inventario != null)
        {
            foreach (var recompensa in m.recompensas)
            {
                inventario.AgregarItem(recompensa.itemRecompensa, recompensa.cantidadRecompensa);
            }

            inventario.RedibujarInventario();
        }
    }

    public void ActualizarProgresoMision(string itemAfectado, int cantidad = 1)
    {
        foreach (var m in misiones)
        {

            foreach (var obj in m.objetivos)
            {
                // Si el objetivo coincide con el item afectado (enemigo eliminado o ítem recolectado)
                if (obj.itemRequerido == itemAfectado)
                {
                    obj.cantidadActual += cantidad;

                    // Si completó este objetivo, verifica si ya completó todos
                    if (obj.cantidadActual >= obj.cantidadRequerida)
                    {
                        bool todosCompletos = true;
                        foreach (var o in m.objetivos)
                        {
                            if (o.cantidadActual < o.cantidadRequerida)
                            {
                                todosCompletos = false;
                                break;
                            }
                        }

                        if (todosCompletos)
                        {
                            CompletarMision(m.idMision);
                        }
                    }
                }
            }
        }
    }
    public void ActivarMision(string idMision)
    {
        Mision mision = ObtenerMisionPorId(idMision);
        if (mision != null)
        {

            mision.EstaActiva = true;
            mision.EstaCompletada = false;
        }
    }
    public void ReiniciarMision(string idMision)
    {
        Mision mision = ObtenerMisionPorId(idMision);
        if (mision != null)
        {
            // Reinicia los objetivos
            foreach (var obj in mision.objetivos)
                obj.cantidadActual = 0;

            mision.EstaActiva = false;
            mision.EstaCompletada = false;
        }
    }
}
