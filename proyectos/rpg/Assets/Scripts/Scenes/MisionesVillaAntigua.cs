using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisionesVillaAntigua: MonoBehaviour
{
    void Start()
    {
        Mision misionAmuletos = new Mision
        {
            idMision = "villa_amuletos",
            misionNombre = "Recolectar fragmentos de amuletos",
            descripcion = "Gustavo puede ayudarte a reconstruir un amuelto con poder magico",
            tipoMision = TipoMision.Recoleccion,
            objetivos = new List<ObjetivoMision>
            {
                new ObjetivoMision { itemRequerido = "amuletoPlata", cantidadRequerida = 5 }
            },
            recompensas = new List<RecompensaMision>
            {
                new RecompensaMision { itemRecompensa = "amuleto", cantidadRecompensa = 1 }
            },
            EstaActiva = false,
            EstaCompletada = false
        };

        Mision misionIntercambio = new Mision
        {
            idMision = "villa_intercambio",
            misionNombre = "Intercambio por llave dorada",
            descripcion = "Andrea ofrece una llave dorada a cambio de algunos items",
            tipoMision = TipoMision.Recoleccion,
            objetivos = new List<ObjetivoMision>
            {
                new ObjetivoMision { itemRequerido = "pan", cantidadRequerida = 5 },
                new ObjetivoMision { itemRequerido = "moneda", cantidadRequerida = 3 }
            },
            recompensas = new List<RecompensaMision>
            {
                new RecompensaMision { itemRecompensa = "llaveDorada", cantidadRecompensa = 1 }
            },
            EstaActiva = false,
            EstaCompletada = false
        };

        Mision misionIntercambioGemaVerde = new Mision
        {
            idMision = "villa_gemaverde",
            misionNombre = "Intercambio de gema verde",
            descripcion = "Ramon necesita una gema verde para terminar sus tareas",
            tipoMision = TipoMision.Recoleccion,
            objetivos = new List<ObjetivoMision>
            {
                new ObjetivoMision { itemRequerido = "gemaVerde", cantidadRequerida = 1 },
            },
            recompensas = new List<RecompensaMision>
            {
                new RecompensaMision { itemRecompensa = "pan", cantidadRecompensa = 2 },
                new RecompensaMision { itemRecompensa = "moneda", cantidadRecompensa = 1 },
            },
            EstaActiva = false,
            EstaCompletada = false
        };

        MisionManager.instance.AgregarMision(misionAmuletos);
        MisionManager.instance.AgregarMision(misionIntercambio);
        MisionManager.instance.AgregarMision(misionIntercambioGemaVerde);
    }
}
