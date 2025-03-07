using UnityEngine;

public class Timer : MonoBehaviour
{
    GameplayManager manager;
    
    public float currentTime = 0;

    private void Awake()
    {
        manager = GetComponent<GameplayManager>();
    }
    private void OnEnable()
    {
        currentTime = 0;
    }
   
    private void Update()
    {
        currentTime += Time.deltaTime;
        manager.ui.UpdateTimer(currentTime);
    }
    public void Restart()
    {
        manager.lastTime = currentTime;

        currentTime = 0;
    }
}
