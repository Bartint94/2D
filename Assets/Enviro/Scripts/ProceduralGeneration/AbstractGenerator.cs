using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractGenerator : MonoBehaviour
{
    [SerializeField] protected TilemapEnviro tilemapEnviro;
    [SerializeField] protected Vector2Int startPos = Vector2Int.zero;
    [SerializeField] protected GenerationSettings settings;

    public abstract void Generate();
   
    

}
