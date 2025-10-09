using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public enum TipoMision
{
    Recoleccion,
    Eliminacion
}
public class Mision
{
    public string idMision;
    public string misionNombre;
    public string descripcion;

    public bool EstaActiva;
    public bool EstaCompletada;

    public TipoMision tipoMision;

    public List<ObjetivoMision> objetivos;
    public List<RecompensaMision> recompensas;
}

public class ObjetivoMision
{
    public string itemRequerido;
    public int cantidadRequerida;
    public int cantidadActual;
}

public class RecompensaMision
{
    public string itemRecompensa;
    public int cantidadRecompensa;
}
