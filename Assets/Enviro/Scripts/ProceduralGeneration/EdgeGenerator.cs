using System;
using System.Collections.Generic;
using UnityEngine;

public static class EdgeGenerator
{
    public static void CreateEdges(HashSet<Vector2Int> pathPositions, TilemapVisualize tileVisualize)
    {
        /* var edgePositions = FindEdgesInDirections(pathPositions, Directions.directionList);
         foreach (var edge in edgePositions)
         {
             tileVisualize.PaintRightEdgeTile(edge);
         }
         HashSet<Vector2Int> edgePositions = new HashSet<Vector2Int>();
        */
        List<Vector2Int> directionList = Directions.directionList;
        foreach (var position in pathPositions)
        {
            for (int i = 0; i < directionList.Count; i++)
            {
                var neighbourPos = position + directionList[i];
                if (!pathPositions.Contains(neighbourPos))
                {
                    if (i == (int)directions.right)
                        tileVisualize.PaintRightEdgeTile(neighbourPos);
                    if (i == (int)directions.left)
                        tileVisualize.PaintLeftEdgeTile(neighbourPos);
                    if (i == (int)directions.top)
                        tileVisualize.PaintTopEdgeTile(neighbourPos);
                    if (i == (int)directions.bottom)
                        tileVisualize.PaintBotEdgeTile(neighbourPos);

                    //edgePositions.Add(neighbourPos);
                }
            }
        }
        //return edgePositions;

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
                    if( i == (int)directions.right)
                    edgePositions.Add(neighbourPos);
                }
            }
        }
        return edgePositions;
    }
}
