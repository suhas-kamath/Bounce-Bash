using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager {

    public static GameManager m_Instance;
    public static GameManager Instance {
        get {
            if (m_Instance == null)
                m_Instance = new ();
            return m_Instance;
        }
    }
    public Action GameOverAction;

    int Score = 0;
    int Coins = 0;

    public void GameOver () {

        (int, int) playerdata = UiManager.Instance.GetPlayerData ();
        if (Score < playerdata.Item1) {
            Score = playerdata.Item1;
        }
        Coins += playerdata.Item2;
        PlayerPrefs.SetInt ("score", Score);
        PlayerPrefs.SetInt ("coins", Coins);
        UiManager.Instance.Reset ();
        UiManager.Instance.SetGameScene ();
        GameOverAction?.Invoke ();
        UiManager.Instance.UpdateUI (PlayerPrefs.GetInt ("score"), PlayerPrefs.GetInt ("coins"));
        UiManager.Instance.SetRestartScene (playerdata.Item1);
    }

}