using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class LeaderboardManager : MonoBehaviour
{
    public TextMeshProUGUI leaderboardTextPrefab;
    [SerializeField] Transform board;
    public List<float> records = new List<float>(); 

    private const string RecordsKey = "Leaderboard";
    [SerializeField] int maxRecords = 20;

    public void AddNewRecord(float newTime)
    {
        Debug.Log(newTime + records.Count + " count");
        records.Add(newTime);
        records.Sort();

        if (records.Count > maxRecords)
        {
            records.RemoveAt(records.Count - 1);
        }

        SaveRecords();
    }

    void SaveRecords()
    {
        string floatString = string.Join('b', records.Select(f => f.ToString()).ToArray());

        PlayerPrefs.SetString(RecordsKey,  floatString);
        PlayerPrefs.Save();
    }

    void LoadRecords()
    {
        records.Clear();
        if (PlayerPrefs.HasKey(RecordsKey))
        {
            string savedData = PlayerPrefs.GetString(RecordsKey);
            Debug.Log(savedData + "pref");

            records = savedData.Split('b').Select(f=> float.Parse(f)).ToList();
            
            records.Sort();
        }
    }

    public void UpdateUI()
    {
        RemoveTextPrefabs();
        LoadRecords();
        for (int i = 0; i < records.Count; i++)
        {
            var text = Instantiate(leaderboardTextPrefab, board);
            text.text = $"{i + 1}. {FormatTime(records[i])}";
        }
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return $"{minutes:00}:{seconds:00}";
    }

    public void ClearStats()
    {
        records.Clear();
        PlayerPrefs.DeleteAll();
        RemoveTextPrefabs();
        UpdateUI();
    }
    void RemoveTextPrefabs()
    {
        var prefabs = board.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (var prefab in prefabs)
        {
            Destroy(prefab.gameObject);
        }
    }
}
