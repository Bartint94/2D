using UnityEngine;

[CreateAssetMenu(fileName = "GenerationSettings", menuName = "ProceduralGeneration/GenerationSettings")]
public class GenerationSettings : ScriptableObject
{
    public int startRoomIterations;
    public int startRoomLength;
    public bool random;
    public int startCorridorLength, startCorridorCount;
    [Range(.1f, 1)] public float roomPercent;

    public int currentLevel;
    [SerializeField] AnimationCurve roomIterationCurve, roomLengthCurve, corridorLengthCurve, corridorCountCurve;
  

    public int RoomIterations()
    {
        int roomIterations = startRoomIterations + (int)roomIterationCurve.Evaluate(currentLevel);
        return roomIterations;
    }
    public int RoomLength()
    {
        int roomLenght = startRoomLength + (int)roomLengthCurve.Evaluate(currentLevel);
        return roomLenght;
    }
    public int CorridorLength()
    {
        int length = startCorridorLength + (int)corridorLengthCurve.Evaluate(currentLevel);
        return length;
    }
    public int CorridorCount()
    {
        int count = startCorridorCount + (int)corridorCountCurve.Evaluate(currentLevel);
        return count;
    }
}
