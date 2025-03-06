using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InteractableGenerator : CorridorGenerateor
{
    public override void Generate()
    {
        tilemapEnviro.Clear();
        HashSet<Vector2Int> pathPositions = new HashSet<Vector2Int>();
        HashSet<Vector2Int> potentialRoomPositions = new HashSet<Vector2Int>();

        CreateCorridors(pathPositions, potentialRoomPositions);

        HashSet<Vector2Int> roomPositions = CreateRooms(potentialRoomPositions);
        pathPositions.UnionWith(roomPositions);
        tilemapEnviro.PaintPathTiles(pathPositions);
        EdgeGenerator.CreateEdges(pathPositions, tilemapEnviro);
        GenerateTraps(roomPositions);
    }
    private void GenerateTraps(HashSet<Vector2Int> roomPositions)
    {
        var potentialPositions = GetPotentialTrapPositions(roomPositions);
        Debug.Log(potentialPositions.Count);
        tilemapEnviro.PaintTrapTiles(potentialPositions);
    }
    private List<Vector2Int> GetPotentialTrapPositions(HashSet<Vector2Int> roomPositions)
    {
        List<Vector2Int> potentialPos = new List<Vector2Int>();
        foreach (var pos in roomPositions)
        {
            var neighboursCount = Directions.GetNeighboursDiagonalDirection(pos, roomPositions).Count;
            if(neighboursCount == 8)
            {
                potentialPos.Add(pos);
            }
        }
        return potentialPos;    
    }
}
