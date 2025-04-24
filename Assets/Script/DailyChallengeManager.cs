using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyChallengeManager : MonoBehaviour {
    public static DailyChallengeManager Instance;

    public int coinsCollectedToday = 0;
    public int dailyGoal = 50;
    public TextMeshProUGUI challengeText;

    private const string CoinsKey = "CoinsCollected";
    private const string DateKey = "LastPlayDate";

    void Awake () {
        if (Instance == null)
            Instance = this;
        else
            Destroy (gameObject);
    }

    void Start () {
        LoadChallengeProgress ();
        UpdateChallengeUI ();
    }

    public void AddCoins (int amount) {
        coinsCollectedToday += amount;
        PlayerPrefs.SetInt (CoinsKey, coinsCollectedToday);
        UpdateChallengeUI ();
    }

    private void UpdateChallengeUI () {
        if (coinsCollectedToday >= dailyGoal) {
            challengeText.text = "Daily Challenge Complete!";
        } else {
            challengeText.text = $"Daily Challenge: {coinsCollectedToday}/{dailyGoal} coins";
        }
    }

    private void LoadChallengeProgress () {
        string today = DateTime.Now.ToString ("yyyyMMdd");
        string lastDate = PlayerPrefs.GetString (DateKey, "");

        if (lastDate != today) {
            coinsCollectedToday = 0;
            PlayerPrefs.SetInt (CoinsKey, 0);
            PlayerPrefs.SetString (DateKey, today);
        } else {
            coinsCollectedToday = PlayerPrefs.GetInt (CoinsKey, 0);
        }
    }
}