using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualize : MonoBehaviour
{
    [SerializeField] Tilemap map;
    [SerializeField] TileBase tilePath, tileEdge;

    public void PaintPathTiles(IEnumerable<Vector2Int> pathPositions)
    {
        PaintPathTiles(pathPositions, map, tilePath);
    }

    internal void PaintEdgeTile(Vector2Int edge)
    {
        PaintSingleTile(map, edge, tileEdge);
    }

    private void PaintPathTiles(IEnumerable<Vector2Int> pathPositions, Tilemap map, TileBase tile)
    {
        foreach (var pos in pathPositions)
        {
            PaintSingleTile(map, pos, tile);
        }
    }

    private void PaintSingleTile(Tilemap map, Vector2Int pos, TileBase tile)
    {
        var tilePos = map.WorldToCell((Vector3Int)pos);
        map.SetTile(tilePos,tile);
    }
}
