using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] InteractableGenerator interactableGenerator;
    [SerializeField] GenerationSettings generationSettings;
    int currentLevel = 1;

    void NextLevel()
    {
        currentLevel++;
        generationSettings.currentLevel = currentLevel;
      //  interactableGenerator.roo
    }
}
