using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour {

    [SerializeField]
    Camera m_Camera;

    public static UiManager Instance;

    int score;
    int coins;
    [SerializeField]
    TextMeshProUGUI scoreHeadingText;
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI coinText;
    [SerializeField]
    Rigidbody2D Player;
    [SerializeField]
    Button PlayButton;
    [SerializeField]
    TextMeshProUGUI PlayButtonText;
    [SerializeField]
    GameObject Headertext;
    [SerializeField]

    TextMeshProUGUI HighScoreText;
    [SerializeField]

    GameObject GameOver;

    public bool StartSpawing;

    private void Awake () {
        if (Instance == null) Instance = this;
        SetGameScene ();
        UpdateUI (PlayerPrefs.GetInt ("score"), PlayerPrefs.GetInt ("coins"));
    }
    public void Reset () {
        score = 0;
        coins = 0;
        Player.simulated = false;
        StartSpawing = false;
    }

    public (int, int) GetPlayerData () {
        return new (score, coins);
    }

    float time;
    void Update () {
        if (StartSpawing) {
            time += Time.deltaTime;
            if (time >= 1) {
                time = 0;
                score += 1;
                UpdateUI (score, coins);
            }
        }
    }

    public void AddCoins (int amount) {
        coins += amount;
        coinText.transform.localScale = Vector3.one;
        coinText.transform.localScale = Vector3.one * 1.3f;
        UpdateUI (score, coins);
    }

    public void UpdateUI (int inScore, int inCoin) {
        scoreText.text = inScore.ToString ();
        coinText.text = inCoin.ToString ();
    }

    public void SetGameScene () {
        PlayButtonText.text = "Play";
        scoreHeadingText.text = "High\nScore";
        Player.gameObject.GetComponent<Transform> ().localPosition = Vector3.zero;
        m_Camera.gameObject.GetComponent<Transform> ().localPosition = new (0, 0, -10f);
        Player.simulated = false;
        Headertext.SetActive (true);
        HighScoreText.gameObject.SetActive (false);
        GameOver.SetActive (false);
        PlayButton.gameObject.SetActive (true);
        PlayButton.onClick.RemoveAllListeners ();
        PlayButton.onClick.AddListener (() => {
            scoreHeadingText.text = "Score";
            Headertext.SetActive (false);
            HighScoreText.gameObject.SetActive (false);
            GameOver.SetActive (false);
            PlayButton.gameObject.SetActive (false);
            Player.simulated = true;
            StartSpawing = true;
            UpdateUI (score, coins);
        });
    }

    public void SetRestartScene (int score) {
        PlayButtonText.text = "Play Again";
        Headertext.SetActive (false);
        GameOver.SetActive (true);
        HighScoreText.gameObject.SetActive (true);
        HighScoreText.text = "Score : " + score;
    }

    public void AnimateCoinText () {
        coinText.transform.DOKill ();
        coinText.transform.localScale = Vector3.one;
        coinText.transform.DOScale (Vector3.one * 1.5f, 0.3f).SetEase (Ease.OutQuad).OnComplete (() => {
            coinText.transform.localScale = Vector3.one;
        });
    }
}