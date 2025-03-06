using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomGenerator : AbstractGenerator
{
    public override void Generate()
    {
        tilemapEnviro.Clear();
        HashSet<Vector2Int> pathPositions = RandomPath(startPos);
        foreach (Vector2Int pos in pathPositions)
        {
            Debug.Log(pos.ToString());
        }
        tilemapEnviro.PaintPathTiles(pathPositions);
        EdgeGenerator.CreateEdges(pathPositions, tilemapEnviro);
    }
    protected HashSet<Vector2Int> RandomPath(Vector2Int startPos)
    {
        var currentPos = startPos;
        HashSet<Vector2Int> pathPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < settings.RoomIterations(); i++)
        {
            var path = ProceduralGeneration.RandomPath(currentPos, settings.RoomLength());
            pathPositions.UnionWith(path);
            if (settings.random)
                currentPos = pathPositions.ElementAt(Random.Range(0, pathPositions.Count));

        }
        return pathPositions;
    }
}
