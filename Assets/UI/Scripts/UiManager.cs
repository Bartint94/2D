using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class UiManager : MonoBehaviour
{
    public GameObject startScreen;

    [SerializeField] List<TMP_FontAsset> fontList;

    [SerializeField] TextMeshProUGUI pointText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI trapText;
    readonly string goldCoinSprite = "<sprite index= 0>";

    readonly string falls = " falls";
    private void Awake()
    {
        ChangeFonts(0);
    }
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }
    public void SetPointText(int currentPoints, int destinationPoints)
    {
        pointText.text = $"{currentPoints} / {destinationPoints} {goldCoinSprite}";
    }
    public void UpdateTimer(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timeText.text = $"{minutes:00}:{seconds:00}";
    }
    public void SetFallsText(int value)
    {
        trapText.text = value.ToString() + falls;
    }
    public void ChangeFonts(int value)
    {
        TextMeshProUGUI[] allText = GetComponentsInChildren<TextMeshProUGUI>();
        foreach (var text in allText)
        {
            text.font = fontList[value];
        }
    }
    
}
