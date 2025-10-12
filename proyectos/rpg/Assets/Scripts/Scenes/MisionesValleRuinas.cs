using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisionesValleRuinas: MonoBehaviour
{
    void Start()
    {
        Mision misionAbrirCofreLlaveDorada = new Mision
        {
            idMision = "valle_abrirCofre_llaveDorada",
            misionNombre = "Abrir el cofre del valle que necesita la llave Dorada",
            descripcion = "El cofre del valle lleva tiempo sin abrirse, prece que guarda una buena recompenza",
            tipoMision = TipoMision.Recoleccion,
            objetivos = new List<ObjetivoMision>
            {
                new ObjetivoMision { itemRequerido = "llaveDorada", cantidadRequerida = 1 }
            },
            recompensas = new List<RecompensaMision>
            {
                new RecompensaMision { itemRecompensa = "anillo", cantidadRecompensa = 1 }
            },
            EstaActiva = false,
            EstaCompletada = false
        };
        Mision misionFinJuego = new Mision
        {
            idMision = "valle_fin",
            misionNombre = "Fin Juego",
            descripcion = "Las ruinas necesitan un anillo y un amuleto para poder calmar a los topos",
            tipoMision = TipoMision.Recoleccion,
            objetivos = new List<ObjetivoMision>
            {
                new ObjetivoMision { itemRequerido = "anillo", cantidadRequerida = 1 },
                new ObjetivoMision { itemRequerido = "amuleto", cantidadRequerida = 1 },
            },
            recompensas = new List<RecompensaMision> { },
            EstaActiva = false,
            EstaCompletada = false
        };

        MisionManager.instance.AgregarMision(misionAbrirCofreLlaveDorada);
        MisionManager.instance.AgregarMision(misionFinJuego);
    }
}
