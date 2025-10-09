using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisionesEscenario1 : MonoBehaviour
{
    void Start()
    {
        Mision misionTopos = new Mision
        {
            misionId = "nivel1_eliminatopos",
            misionNombre = "Eliminar a los Topos",
            descripcion = "Demasiados Topos estan destruyendo la choza del rio. Deshazte de ellos.",
            tipoMision = TipoMision.Eliminacion,
            objetivo = "enemigo",
            cantidadRequerida = 5,
            cantidadActual = 0,
            recompenza = "gemaAzul",
            cantidadRecompenza = 5,
            EstaActiva = false,
            EstaCompletada = false
        };

        Mision misionBuscarHacha = new Mision
        {
            misionId = "nivel1_buscarhacha",
            misionNombre = "Buscar el hacha de Alex",
            descripcion = "Alex fue a talar al bosque pero algo lo asusto y por salir huyendo dejo su hacha por algun lugar del bosque",
            tipoMision = TipoMision.Recoleccion,
            objetivo = "hacha",
            cantidadRequerida = 1,
            cantidadActual = 0,
            recompenza = "gemaRoja",
            cantidadRecompenza = 3,
            EstaActiva = false,
            EstaCompletada = false
        };

        Mision misionIntercambio = new Mision
        {
            misionId = "nivel1_intercambiogemas",
            misionNombre = "Intercambio de gemas por llave",
            descripcion = "Manuel un comerciante del pueblo ofrece un intercambio de gemas por una llave que parece ser de utilidad",
            tipoMision = TipoMision.Recoleccion,
            objetivo = "gemaAzul",
            cantidadRequerida = 2,
            cantidadActual = 0,
            recompenza = "llave",
            cantidadRecompenza = 1,
            EstaActiva = false,
            EstaCompletada = false
        };

        MisionManager.instance.AgregarMision(misionTopos);
        MisionManager.instance.AgregarMision(misionBuscarHacha);
        MisionManager.instance.AgregarMision(misionIntercambio);
    }
}
