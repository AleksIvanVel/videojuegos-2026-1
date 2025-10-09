using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisionesEscenario0 : MonoBehaviour
{
    void Start()
    {
        Mision misionHierbas = new Mision
        {
            misionId = "nivel0_hierbas",
            misionNombre = "Recolectar hierbas finas",
            descripcion = "Héctor necesita 3 hierbas finas del bosque cercano. Entrégaselas para recibir una moneda.",
            tipoMision = TipoMision.Recoleccion,
            objetivo = "hierbas",
            cantidadRequerida = 3,
            recompenza = "moneda",
            cantidadRecompenza = 1,
            EstaActiva = false,
            EstaCompletada = false
        };

        MisionManager.instance.AgregarMision(misionHierbas);
    }
}
