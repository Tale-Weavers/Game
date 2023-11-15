using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class AStarMind : MonoBehaviour
{
    private Stack<Square> currentPlan = new();
    public Square GetNextMove(Square currentPos, Square goal)
    {
        //if (currentPlan.Count != 0)
        //    return currentPlan.Pop();
        // calcular camino, devuelve resultado de A*
        currentPlan.Clear();
        var searchResult = Search(currentPos, goal);

        // recorre searchResult and copia el camino a currentPlan
        while (searchResult?.parent != null)
        {
            currentPlan.Push(searchResult.cellData);
            searchResult = searchResult.parent;
        }

        // returns next move (pop Stack)
        if (currentPlan.Any())
            return currentPlan.Pop();

        return null;

    }
    private Node Search(Square start, Square goal)
    {
        // crea una lista vacía de nodos
        var open = new List<Node>();
        var visited = new List<Square>();
        // node inicial
        var n = new Node(start);

        // añade nodo inicial a la lista
        open.Add(n);

        // mientras la lista no esté vacia
        while (open.Any())
        {
            // mira el primer nodo de la lista
            Node first = open.First();
            // si el primer nodo es goal, returns current node
            float distToGoal = (first.position - goal.transform.position).magnitude;
            if (!goal.isWalkable)
            {
                if (distToGoal <= 1.3)
                    return first;
            }
            else
            {
                if (first.position == goal.transform.position)
                {
                    return first;
                }
            }

            // expande vecinos (calcula coste de cada uno, etc)y los añade en la lista

            List<Square> vecinos = first.cellData.SeeNeighbours();
            for (int i = 0; i < vecinos.Count; i++)
            {
                //filtramos estados repetidos
                bool visitado = false;
                for (int j = 0; j < visited.Count; j++)
                {
                    if (vecinos[i] == visited[j])
                        visitado = true;
                }
                //añadimos a la lista los vecinos nuevos a los que podemos ir
                if (vecinos[i] != null && visitado == false)
                {

                    Node nuevo = new Node(first, vecinos[i]);
                    nuevo.CalcHeur(goal);
                    open.Add(nuevo);
                    visited.Add(nuevo.cellData);
                }
            }
            // ordenamos la lista abierta
            open.RemoveAt(0);
            Node temp;
            for (int j = 0; j <= open.Count - 2; j++)
            {
                for (int i = 0; i <= open.Count - 2; i++)
                {
                    if (open[i].heur > open[i + 1].heur)
                    {
                        temp = open[i + 1];
                        open[i + 1] = open[i];
                        open[i] = temp;
                    }
                }
            }
        }

        return null;
    }
}


