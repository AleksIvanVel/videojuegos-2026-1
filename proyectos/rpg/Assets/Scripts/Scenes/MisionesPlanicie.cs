using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisionesPlanicie : MonoBehaviour
{
    void Start()
    {
        Mision misionAbrirCofreLlaveAzul = new Mision
        {
            idMision = "planicie_abrircofre_llaveAzul",
            misionNombre = "Abrir el cofre de la planicie que necesita la llave azul",
            descripcion = "El cofre de la planicie lleva tiempo sin abrirse, prece que guarda una buena recompenza",
            tipoMision = TipoMision.Recoleccion,
            objetivos = new List<ObjetivoMision>
            {
                new ObjetivoMision { itemRequerido = "llaveAzul", cantidadRequerida = 1 }
            },
            recompensas = new List<RecompensaMision>
            {
                new RecompensaMision { itemRecompensa = "armadura1", cantidadRecompensa = 1 },
                new RecompensaMision { itemRecompensa = "armadura2", cantidadRecompensa = 1 }
            },
            EstaActiva = false,
            EstaCompletada = false
        };


        Mision misionAbrirCofreLlaveVerde = new Mision
        {
            idMision = "planicie_abrircofre_llaveVerde",
            misionNombre = "Abrir el cofre de la planicie que necesita la llave Verde",
            descripcion = "El cofre de la planicie lleva tiempo sin abrirse, prece que guarda una buena recompenza",
            tipoMision = TipoMision.Recoleccion,
            objetivos = new List<ObjetivoMision>
            {
                new ObjetivoMision { itemRequerido = "llaveVerde", cantidadRequerida = 1 }
            },
            recompensas = new List<RecompensaMision>
            {
                new RecompensaMision { itemRecompensa = "armadura3", cantidadRecompensa = 1 },
                new RecompensaMision { itemRecompensa = "armadura4", cantidadRecompensa = 1 },
                new RecompensaMision { itemRecompensa = "amuletoPlata", cantidadRecompensa = 1 },

            },
            EstaActiva = false,
            EstaCompletada = false
        };

        MisionManager.instance.AgregarMision(misionAbrirCofreLlaveAzul);
        MisionManager.instance.AgregarMision(misionAbrirCofreLlaveVerde);
    }
}
