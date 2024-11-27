using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private float InitialGameSpeed = 5f;
    [SerializeField] private float GameSpeedIncrease = 0.1f;
    [SerializeField] private TextMeshProUGUI gameOverText, scoreText, highScoreText;
    [SerializeField] private Button retryButton;
    public float GameSpeed { get; private set; }

    private DinoPlayer player;
    private ObstacleSpawner obstacleSpawner;

    private float score = 0f, highScore = 0f;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    private void Start()
    {
        player = FindObjectOfType<DinoPlayer>();
        obstacleSpawner = FindObjectOfType<ObstacleSpawner>();
        NewGame();
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
        highScoreText.text = Mathf.RoundToInt(highScore).ToString("D5");
    }
    public void NewGame()
    {
        score = 0f;
        var obstacles = FindObjectsOfType<ObstacleManager>(true);
        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }
        GameSpeed = InitialGameSpeed;
        enabled = true;
        player.gameObject.SetActive(true);
        obstacleSpawner.gameObject.SetActive(true);

        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
    }
    public void GameOver()
    {
        GameSpeed = 0f;
        enabled = false;
        player.gameObject.SetActive(false);
        obstacleSpawner.gameObject.SetActive(false);

        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
    }
    private void Update()
    {
        GameSpeed += GameSpeedIncrease * Time.deltaTime;
        score += GameSpeed * Time.deltaTime;

        scoreText.text = Mathf.RoundToInt(score).ToString("D5");
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = scoreText.text;
        }
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat("HighScore", highScore);
        PlayerPrefs.Save();
    }
    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
