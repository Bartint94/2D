using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualize : MonoBehaviour
{
    [SerializeField] Tilemap map;
    [SerializeField] RuleTile tilePath, rightTileEdge, leftTileEdge, topTileEdge, botTileEdge;
    
    public int scale;
    private void Awake()
    {
        scale = (int)map.cellSize.magnitude;
    }

    public void PaintPathTiles(IEnumerable<Vector2Int> pathPositions)
    {
        PaintPathTiles(pathPositions, map, tilePath);
    }

    internal void PaintRightEdgeTile(Vector2Int edge)
    {
        PaintSingleTile(map, edge, rightTileEdge);
    }
    internal void PaintLeftEdgeTile(Vector2Int edge)
    {
        PaintSingleTile(map, edge, leftTileEdge);
    }
    internal void PaintTopEdgeTile(Vector2Int edge)
    {
        PaintSingleTile(map, edge, topTileEdge);
    }
    internal void PaintBotEdgeTile(Vector2Int edge)
    {
        PaintSingleTile(map, edge, botTileEdge);
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
        map.ClearAllTiles();
    }
}
