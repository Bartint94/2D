using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapEnviro : MonoBehaviour
{
    [SerializeField] Tilemap staticMap, interactableMap;
    [SerializeField] RuleTile tilePath, rightTileEdge, leftTileEdge, 
        topTileEdge, botTileEdge, universalTileEdge, trap;

    public void PaintPathTiles(IEnumerable<Vector2Int> pathPositions)
    {
        PaintPathTiles(pathPositions, staticMap, tilePath);
    }
    internal void PaintUniversalEdgeTile(Vector2Int edge)
    {
        PaintSingleTile(staticMap, edge, universalTileEdge);
    }

    internal void PaintRightEdgeTile(Vector2Int edge)
    {
        PaintSingleTile(staticMap, edge, rightTileEdge);
    }
    internal void PaintLeftEdgeTile(Vector2Int edge)
    {
        PaintSingleTile(staticMap, edge, leftTileEdge);
    }
    internal void PaintTopEdgeTile(Vector2Int edge)
    {
        PaintSingleTile(staticMap, edge, topTileEdge);
    }
    internal void PaintBotEdgeTile(Vector2Int edge)
    {
        PaintSingleTile(staticMap, edge, botTileEdge);
    }
    public void PaintTrapTiles(IEnumerable<Vector2Int> pathPositions)
    {
        PaintPathTiles(pathPositions, interactableMap, trap);
    }

    private void PaintPathTiles(IEnumerable<Vector2Int> pathPositions, Tilemap map, RuleTile tile)
    {
        foreach (var pos in pathPositions)
        {
            PaintSingleTile(map, pos, tile);
        }
    }

    public void PaintSingleTile(Tilemap map, Vector2Int pos, RuleTile tile)
    {
        var tilePos = map.WorldToCell((Vector3Int)pos);
        
        map.SetTile(tilePos,tile);
        //tile.m_DefaultGameObject.transform.localScale = new Vector3(scale, scale, 1);
    }

    internal void Clear()
    {
        staticMap.ClearAllTiles();
    }
}
