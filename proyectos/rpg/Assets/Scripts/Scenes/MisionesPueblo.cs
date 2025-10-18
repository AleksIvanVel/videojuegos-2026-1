using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisionesPueblo: MonoBehaviour
{
    void Start()
    {
        Mision misionHierbas = new Mision
        {
            idMision = "pueblo_hierbas",
            misionNombre = "Recolectar hierbas finas",
            descripcion = "Hector necesita 3 hierbas finas del bosque cercano. Entr�gaselas para recibir una moneda.",
            tipoMision = TipoMision.Recoleccion,
            objetivos = new List<ObjetivoMision>
            {
                new ObjetivoMision { itemRequerido = "hierbas", cantidadRequerida = 3 }
            },
            recompensas = new List<RecompensaMision>
            {
                new RecompensaMision { itemRecompensa = "moneda", cantidadRecompensa = 1 }
            },
            EstaActiva = false,
            EstaCompletada = false
        };

        MisionManager.instance.AgregarMision(misionHierbas);
    }
}
