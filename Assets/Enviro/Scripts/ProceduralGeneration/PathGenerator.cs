using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathGenerator : AbstractGenerator
{
    [SerializeField] int iterations;
    [SerializeField] int length;
    [SerializeField] bool random;
    [SerializeField] Vector2Int startPos = new Vector2Int(0, 0);
    
    
    public override void Generate()
    {
        tilemapVisualize.Clear();
        HashSet<Vector2Int> pathPositions = RandomPath(startPos);
        foreach (Vector2Int pos in pathPositions)
        {
            Debug.Log(pos.ToString());
        }
        tilemapVisualize.PaintPathTiles(pathPositions);
        EdgeGenerator.CreateEdges(pathPositions, tilemapVisualize);
    }
    protected HashSet<Vector2Int> RandomPath(Vector2Int startPos)
    {
        var currentPos = startPos;
        HashSet<Vector2Int> pathPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < iterations; i++)
        {
            var path = ProceduralGeneration.RandomPath(currentPos, length);
            pathPositions.UnionWith(path);
            if (random)
                currentPos = pathPositions.ElementAt(Random.Range(0, pathPositions.Count));

        }
        return pathPositions;
    }
}
