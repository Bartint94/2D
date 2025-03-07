
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InteractableGenerator : CorridorGenerateor
{
    [SerializeField] GameplayManager manager;
    public override void Generate()
    {
        Clear();
        HashSet<Vector2Int> pathPositions = new HashSet<Vector2Int>();
        HashSet<Vector2Int> potentialRoomPositions = new HashSet<Vector2Int>();

        CreateCorridors(pathPositions, potentialRoomPositions);

        HashSet<Vector2Int> roomPositions = CreateRooms(potentialRoomPositions);
        pathPositions.UnionWith(roomPositions);
        tilemapEnviro.PaintPathTiles(pathPositions);
        EdgeGenerator.CreateEdges(pathPositions, tilemapEnviro);
        GenerateTraps(roomPositions);
        GenerateCoins(roomPositions);
    }

    public void Clear()
    {
        tilemapEnviro.Clear();  
    }
    private void GenerateCoins(HashSet<Vector2Int> roomPositions)
    {
        var i = 0;
        var reject = settings.CoinDivide();
        var count = 0;
        foreach (Vector2Int pos in roomPositions)
        {
            i++;
            if(i == reject)
            {
                count++;
                if(count % settings.goldCoinRarity == 0)
                {
                    tilemapEnviro.PaintGoldCoinTile(pos);
                    manager.destinationPoints += manager.goldCoinValue;
                }
                else
                {
                    tilemapEnviro.PaintSilverTile(pos);
                    manager.destinationPoints += manager.silverCoinValue;
                }
                reject += settings.CoinDivide();
            }
        }
        Debug.Log(count+ "Coins");
    }

    private void GenerateTraps(HashSet<Vector2Int> roomPositions)
    {
        var potentialPositions = GetPotentialTrapPositions(roomPositions);
        var finalPositions = RejectSomePositions(potentialPositions);
        tilemapEnviro.PaintTrapTiles(finalPositions);
    }

    private HashSet<Vector2Int> RejectSomePositions(List<Vector2Int> potentialPositions)
    {
        var finalPositions = new HashSet<Vector2Int>();
        for (int i = settings.TrapDivide(); i < potentialPositions.Count; i += settings.TrapDivide())
        {
            finalPositions.Add(potentialPositions[i]);
        }
        return finalPositions;
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
