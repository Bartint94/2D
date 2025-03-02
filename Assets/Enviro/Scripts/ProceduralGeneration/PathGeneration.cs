using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathGeneration : MonoBehaviour
{
    [SerializeField] int iterations;
    [SerializeField] int length;
    [SerializeField] bool random;
    [SerializeField] Vector2Int startPos = new Vector2Int(0, 0);
    [SerializeField] TilemapVisualize tilemapVisualize;

    public void Generate()
    {
        HashSet<Vector2Int> pathPositions = RandomPath();
        tilemapVisualize.PaintPathTiles(pathPositions);
        EdgeGenerator.CreateEdges(pathPositions, tilemapVisualize);
    }
    protected HashSet<Vector2Int> RandomPath()
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
