using System.Dynamic;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Node parent;
    public Vector3 position;
    public Square cellData;
    public float heur;
    public float coste;
 

    //Constructor para el nodo padre
    public Node(Square datos)
    {
        this.parent = null;
        this.cellData = datos;
        position = datos.transform.position;
        this.coste = 0;
        this.heur = 0;
    }
    //Constructor para el resto de nodos
    public Node(Node padre, Square datos)
    {
        this.parent = padre;
        this.cellData = datos;
        position = datos.transform.position;
        this.heur = 0;
        Vector3 dist = datos.transform.position - padre.position;
        this.coste = padre.coste + dist.magnitude;

    }

    //Cálculo de heurística 
    public void CalcHeur(Square metas)
    {
        Vector3 dist = metas.transform.position - cellData.transform.position;
        this.heur = dist.magnitude;
        this.heur += this.coste;
    }


}