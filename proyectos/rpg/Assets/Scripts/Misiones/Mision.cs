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
    public string misionId;
    public string misionNombre;
    public string descripcion;

    public bool EstaActiva;
    public bool EstaCompletada;

    public TipoMision tipoMision;
    public string objetivo;
    public int cantidadRequerida;
    public int cantidadActual;

    public string recompenza;
    public int cantidadRecompenza;
}
