using System;
using System.Collections.Generic;
using UnityEngine;

public static class EdgeGenerator
{
    public static void CreateEdges(HashSet<Vector2Int> pathPositions, TilemapVisualize tileVisualize)
    {
        var edgePositions = FindEdgesInDirections(pathPositions, Directions.directionList);
        foreach (var edge in edgePositions)
        {
            tileVisualize.PaintEdgeTile(edge);
        }
    }

    private static HashSet<Vector2Int> FindEdgesInDirections(HashSet<Vector2Int> pathPositions, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> edgePositions = new HashSet<Vector2Int>();
        foreach (var position in pathPositions) 
        {
            foreach (var direction in directionList)
            {
                var neighbourPos = position + direction;
                if(!pathPositions.Contains(neighbourPos))
                {
                    edgePositions.Add(neighbourPos);
                }
            }
        }
        return edgePositions;
    }
}
