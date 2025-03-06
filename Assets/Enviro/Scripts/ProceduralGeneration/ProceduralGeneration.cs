using System.Collections.Generic;
using UnityEngine;

public static class ProceduralGeneration
{
    public static HashSet<Vector2Int> RandomPath(Vector2Int startPos, int length)
    {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        path.Add(startPos);
        var previousPos = startPos; 

        for (int i = 0; i < length; i++)
        {
            var newPos = previousPos + Directions.GetRandomDirection();
            path.Add(newPos);
            previousPos = newPos;
        }

        return path;
    }
    public static List<Vector2Int> RandomPathCorridor(Vector2Int startPos, int length)
    {
        List<Vector2Int> corridor = new List<Vector2Int>(); 
        var direction = Directions.GetRandomDirection();    
        var currentPos = startPos;
        corridor.Add(currentPos);
        for (int i = 0;i < length;i++)
        {
            currentPos += direction;
            corridor.Add(currentPos);
        }
        return corridor;
    }
}
public enum directions
{
    top, bottom, right, left,
}
public static class Directions
{
    
    public static List<Vector2Int> cardinalDirectionList = new List<Vector2Int>
    {
        new Vector2Int(0,1),
        new Vector2Int(0,-1),
        new Vector2Int(1,0),
        new Vector2Int(-1,0)

    };
    public static List<Vector2Int> diagonalDirectionList = new List<Vector2Int>
    {
        new Vector2Int(0,1),
        new Vector2Int(0,-1),
        new Vector2Int(1,0),
        new Vector2Int(-1,0),
        new Vector2Int(1,1),
        new Vector2Int(1,-1),
        new Vector2Int(-1,1),
        new Vector2Int(-1,-1)
    };
    public static List<Vector2Int> GetNeighboursCardinalDirection(Vector2Int startPos, HashSet<Vector2Int> roomPositions)
    {
        return GetNeighbours(startPos, cardinalDirectionList, roomPositions);
    }
    public static List<Vector2Int> GetNeighboursDiagonalDirection(Vector2Int startPos, HashSet<Vector2Int> roomPositions)
    {
        return GetNeighbours(startPos, diagonalDirectionList, roomPositions);
    }

    private static List<Vector2Int> GetNeighbours(Vector2Int startPos, List<Vector2Int> offset, HashSet<Vector2Int> roomPositions)
    {
        List<Vector2Int> neighbours = new List<Vector2Int>();
        foreach (var dir in offset)
        {
            Vector2Int neighbour = startPos + dir;
            if(roomPositions.Contains(neighbour))
            {
                neighbours.Add(neighbour);  
            }
        }
        return neighbours;
    }

    public static Vector2Int GetRandomDirection()
    {
        return cardinalDirectionList[Random.Range(0, cardinalDirectionList.Count)];
    }
}