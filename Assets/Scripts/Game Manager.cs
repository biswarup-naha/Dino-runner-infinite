using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance;

    [SerializeField]
    private MeshRenderer groundRenderer;

    public float speed = 0.2f;
    public float upSpeed = 0.1f;
    private float currSpeed;

    [HideInInspector]
    public bool gameStarted = false;

    [Header("UI")]
    public TextMeshProUGUI score;

    private int highScore; 
    private float currScore = 0f;

    private void Awake()
    {
        Instance= this;
        currSpeed = speed;
        highScore= PlayerPrefs.HasKey("HighScore") ? PlayerPrefs.GetInt("HighScore") : 0;
    }

    private void Update()
    {
        if(gameStarted)
        {
            currSpeed += upSpeed * Time.deltaTime; // increase speed over time
            groundRenderer.material.mainTextureOffset += new Vector2(currSpeed * Time.deltaTime, 0);  // d = s * t

            currScore+=(currSpeed * Time.deltaTime);
            if(Mathf.RoundToInt(currScore)> highScore) highScore = Mathf.RoundToInt(currScore);

            //save highscore
            PlayerPrefs.SetInt("HighScore", highScore);

            UpdateScoreUI();
        }
    }

    private void UpdateScoreUI()
    {
        score.SetText($"Hi: {highScore.ToString("D5")}    Live: {Mathf.RoundToInt(currScore).ToString("D5")}");
    }
}
