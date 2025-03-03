using UnityEngine;

public abstract class AbstractGenerator : MonoBehaviour
{
    [SerializeField] protected TilemapVisualize tilemapVisualize;
    [SerializeField] protected Vector2Int startPosition = Vector2Int.zero;

    public abstract void Generate();
    

}
