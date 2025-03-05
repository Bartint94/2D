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
    
    public static List<Vector2Int> directionList = new List<Vector2Int>
    {
        new Vector2Int(0,1),
        new Vector2Int(0,-1),
        new Vector2Int(1,0),
        new Vector2Int(-1,0)

    };

    public static Vector2Int GetRandomDirection()
    {
        return directionList[Random.Range(0, directionList.Count)];
    }
}