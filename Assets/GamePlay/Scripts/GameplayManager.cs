using System;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] InteractableGenerator generator;
    [SerializeField] GenerationSettings generationSettings;
    [SerializeField] UiManager Ui;
    [SerializeField] LeaderboardManager leaderboardManager;
    [SerializeField] CharacterManager characterManager;

    Timer timer;
    public UiManager ui => Ui;

    public int goldCoinValue = 2;
    public int silverCoinValue = 1;


    int currentFalls = 0;
    int currentLevel = 1;
    int currentPoints = 0;
    public int destinationPoints;

    public float lastTime;

    public Action OnLevelUp;
    public Action OnExitGameplay;
    void ClearStats()
    {
        currentFalls = 0;
        currentPoints = 0;
        destinationPoints = 0;
        currentLevel = 1;
        generationSettings.currentLevel = currentLevel;
    }
    private void Awake()
    {
        timer = GetComponent<Timer>();
    }
    public void InitGameplay()
    {
        ClearStats();
        generator.Generate();
        Ui.SetPointText(currentPoints,destinationPoints);
        Ui.SetFallsText(currentFalls);
        timer.enabled = true;
        characterManager.enabled = true;
        SoundManager.Instance.PlayMusic();
    }
    public void ExitGameplay()
    {
        generator.Clear();
        timer.enabled = false;
        OnExitGameplay?.Invoke();
        ui.startScreen.SetActive(true);
        SoundManager.Instance.StopMusic();
    }
   
    public void GetPoints(CoinType type)
    {
        if (type == CoinType.gold)
        {
            currentPoints += goldCoinValue;
        }
        if (type == CoinType.silver)
        {
            currentPoints += silverCoinValue;
        }

        Ui.SetPointText(currentPoints, destinationPoints);
        
        if (currentPoints == destinationPoints)
        {
            NextLevel();
        }
    }
    public void Fall()
    {
        currentFalls++;
        Ui.SetFallsText(currentFalls);
    }

    void NextLevel()
    {
        timer.Restart();
        leaderboardManager.AddNewRecord(lastTime);
        
        ClearStats();

        currentLevel++;

        generationSettings.currentLevel = currentLevel;
        generator.Generate();
        Ui.SetPointText(currentPoints, destinationPoints);
        OnLevelUp?.Invoke();
    }
}
