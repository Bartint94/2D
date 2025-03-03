using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CorridorGenerateor : PathGenerator
{
    [SerializeField] int corridorlength, count;
    [SerializeField] [Range(.1f,1)]float roomPercent;
    public override void Generate()
    {
        CorridorGeneration();
    }

    private void CorridorGeneration()
    {
        tilemapVisualize.Clear();
        HashSet<Vector2Int> pathPositions = new HashSet<Vector2Int>();
        HashSet<Vector2Int> potentialRoomPositions = new HashSet<Vector2Int>();
        
        CreateCorridors(pathPositions,potentialRoomPositions);

        HashSet<Vector2Int> roomPositions = CreateRooms(potentialRoomPositions);

        pathPositions.UnionWith(roomPositions);
        tilemapVisualize.PaintPathTiles(pathPositions);
        EdgeGenerator.CreateEdges(pathPositions, tilemapVisualize);
    }

    private HashSet<Vector2Int> CreateRooms(HashSet<Vector2Int> potentialRoomPositions)
    {
        HashSet<Vector2Int> roomPositions = new HashSet<Vector2Int>();
        int roomCount = Mathf.RoundToInt(potentialRoomPositions.Count * roomPercent);

        List<Vector2Int> roomToCreate = potentialRoomPositions.OrderBy(x => Guid.NewGuid()).Take(roomCount).ToList();

        foreach (Vector2Int roomPosition in roomToCreate)
        {
            var roomPath = RandomPath(roomPosition);
            roomPositions.UnionWith(roomPath);
        }
        return roomPositions;
    }

    private void CreateCorridors(HashSet<Vector2Int> pathPositions, HashSet<Vector2Int> potentialRoomPositions)
    {
        var currentPosition = startPosition;
        potentialRoomPositions.Add(currentPosition);
        for (int i = 0; i < corridorlength; i++)
        {
            var corridor = ProceduralGeneration.RandomPathCorridor(currentPosition, corridorlength);
            currentPosition = corridor[corridor.Count - 1];
            potentialRoomPositions.Add(currentPosition);
            pathPositions.UnionWith(corridor);
        }
    }
}
