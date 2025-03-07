using UnityEngine;

[CreateAssetMenu(fileName = "GenerationSettings", menuName = "ProceduralGeneration/GenerationSettings")]
public class GenerationSettings : ScriptableObject
{
    public int currentLevel;

    [SerializeField] int startRoomIterations;
    [SerializeField] int startRoomLength;
    [SerializeField] public bool random;
    [SerializeField] int startCorridorLength, startCorridorCount;
    [Range(.1f, 1)] public float roomPercent;
    
    [SerializeField] AnimationCurve roomIterationCurve, roomLengthCurve, corridorLengthCurve, corridorCountCurve;

    [SerializeField] int potentialTrapPositionsDivide;
    [SerializeField] int potentialCoinPositionsDivide;
    [SerializeField] int GoldCoinRarity;
    public int goldCoinRarity { get { if (GoldCoinRarity < 1) return 1; else return GoldCoinRarity;}}

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
    public int TrapDivide()
    {
        return RandomInteractableDivide(potentialTrapPositionsDivide);
    }
    public int CoinDivide()
    {
        return RandomInteractableDivide(potentialCoinPositionsDivide);
    }
    int RandomInteractableDivide(int value)
    {
        if(value < 1)
        {
            return 1;
        }
        var randomMin = value / 2;
        var randomMax = randomMin + value;
        return Random.Range(randomMin, randomMax);
    }
   
}
