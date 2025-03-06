using System;
using System.Collections.Generic;
using UnityEngine;

public static class EdgeGenerator
{
    public static void CreateEdges(HashSet<Vector2Int> pathPositions, TilemapEnviro tileVisualize)
    {
         var edgePositions = FindEdgesInDirections(pathPositions, Directions.cardinalDirectionList);
         foreach (var edge in edgePositions)
         {
             tileVisualize.PaintUniversalEdgeTile(edge);
         }
         
    }
    private static void PlaceCardinaEdges(HashSet<Vector2Int> pathPositions, TilemapEnviro tileEnviro)
    {
        List<Vector2Int> directionList = Directions.cardinalDirectionList;
        foreach (var position in pathPositions)
        {
            for (int i = 0; i < directionList.Count; i++)
            {
                var neighbourPos = position + directionList[i];
                if (!pathPositions.Contains(neighbourPos))
                {
                    if (i == (int)directions.right)
                        tileEnviro.PaintRightEdgeTile(neighbourPos);
                    if (i == (int)directions.left)
                        tileEnviro.PaintLeftEdgeTile(neighbourPos);
                    if (i == (int)directions.top)
                        tileEnviro.PaintTopEdgeTile(neighbourPos);
                    if (i == (int)directions.bottom)
                        tileEnviro.PaintBotEdgeTile(neighbourPos);
                }
            }
        }
    }

    private static HashSet<Vector2Int> FindEdgesInDirections(HashSet<Vector2Int> pathPositions, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> edgePositions = new HashSet<Vector2Int>();
        foreach (var position in pathPositions) 
        {
            for(int i = 0; i < directionList.Count; i++)
            {
                var neighbourPos = position + directionList[i];
                if(!pathPositions.Contains(neighbourPos))
                {
                    edgePositions.Add(neighbourPos);
                }
            }
        }
        return edgePositions;
    }
}
