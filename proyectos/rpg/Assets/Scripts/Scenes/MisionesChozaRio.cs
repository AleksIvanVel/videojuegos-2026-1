using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisionesChozaRio : MonoBehaviour
{
    void Start()
    {
        Mision misionTopos = new Mision
        {
            idMision = "choza_eliminatopos",
            misionNombre = "Eliminar a los Topos",
            descripcion = "Demasiados Topos estan destruyendo la choza del rio. Deshazte de ellos.",
            tipoMision = TipoMision.Eliminacion,
            objetivos = new List<ObjetivoMision>
            {
                new ObjetivoMision { itemRequerido = "enemigo", cantidadRequerida = 5 }
            },
            recompensas = new List<RecompensaMision>
            {
                new RecompensaMision { itemRecompensa = "gemaRoja", cantidadRecompensa = 3 },
                new RecompensaMision { itemRecompensa = "gemaAzul", cantidadRecompensa = 2 }

            },
            EstaActiva = false,
            EstaCompletada = false
        };

        Mision misionBuscarHacha = new Mision
        {
            idMision = "choza_buscarhacha",
            misionNombre = "Buscar el hacha de Alex",
            descripcion = "Alex fue a talar al bosque pero algo lo asusto y por salir huyendo dejo su hacha por algun lugar del bosque",
            tipoMision = TipoMision.Recoleccion,
            objetivos = new List<ObjetivoMision>
            {
                new ObjetivoMision { itemRequerido = "hacha", cantidadRequerida = 1 }
            },
            recompensas = new List<RecompensaMision>
            {
                new RecompensaMision { itemRecompensa = "gemaVerde", cantidadRecompensa = 2 },
                new RecompensaMision { itemRecompensa = "moneda", cantidadRecompensa = 5 }
            },
            EstaActiva = false,
            EstaCompletada = false
        };

        Mision misionIntercambio = new Mision
        {
            idMision = "choza_intercambiogemas",
            misionNombre = "Intercambio de gemas por llave",
            descripcion = "Manuel un comerciante del pueblo ofrece un intercambio de gemas por una llave que parece ser de utilidad",
            tipoMision = TipoMision.Recoleccion,
            objetivos = new List<ObjetivoMision>
            {
                new ObjetivoMision { itemRequerido = "gemaRoja", cantidadRequerida = 2 },
                new ObjetivoMision { itemRequerido = "gemaAzul", cantidadRequerida = 2 },
                new ObjetivoMision { itemRequerido = "moneda", cantidadRequerida = 1 }
            },
            recompensas = new List<RecompensaMision>
            {
                new RecompensaMision { itemRecompensa = "llaveAzul", cantidadRecompensa = 1 }
            },
            EstaActiva = false,
            EstaCompletada = false
        };

        MisionManager.instance.AgregarMision(misionTopos);
        MisionManager.instance.AgregarMision(misionBuscarHacha);
        MisionManager.instance.AgregarMision(misionIntercambio);
    }
}
