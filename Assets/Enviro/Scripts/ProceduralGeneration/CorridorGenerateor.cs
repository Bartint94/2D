using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CorridorGenerateor : RoomGenerator
{
    public override void Generate()
    {
        tilemapEnviro.Clear();
        CorridorGeneration();
    }

    private void CorridorGeneration()
    {
        HashSet<Vector2Int> pathPositions = new HashSet<Vector2Int>();
        HashSet<Vector2Int> potentialRoomPositions = new HashSet<Vector2Int>();
        
        CreateCorridors(pathPositions,potentialRoomPositions);

        HashSet<Vector2Int> roomPositions = CreateRooms(potentialRoomPositions);

        pathPositions.UnionWith(roomPositions);
        tilemapEnviro.PaintPathTiles(pathPositions);
        EdgeGenerator.CreateEdges(pathPositions, tilemapEnviro);
    }

    protected HashSet<Vector2Int> CreateRooms(HashSet<Vector2Int> potentialRoomPositions)
    {
        HashSet<Vector2Int> roomPositions = new HashSet<Vector2Int>();
        int roomCount = Mathf.RoundToInt(potentialRoomPositions.Count * settings.roomPercent);

        List<Vector2Int> roomToCreate = potentialRoomPositions.OrderBy(x => Guid.NewGuid()).Take(roomCount).ToList();

        foreach (Vector2Int roomPosition in roomToCreate)
        {
            var roomPath = RandomPath(roomPosition);
            roomPositions.UnionWith(roomPath);
        }
        return roomPositions;
    }

    protected void CreateCorridors(HashSet<Vector2Int> pathPositions, HashSet<Vector2Int> potentialRoomPositions)
    {
        var currentPosition = startPos;
        potentialRoomPositions.Add(currentPosition);
        for (int i = 0; i < settings.CorridorCount(); i++)
        {
            var corridor = ProceduralGeneration.RandomPathCorridor(currentPosition, settings.CorridorLength());
            currentPosition = corridor[corridor.Count - 1];
            potentialRoomPositions.Add(currentPosition);
            pathPositions.UnionWith(corridor);
        }
    }
}
