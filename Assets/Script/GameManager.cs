using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI killCounterText;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;

    [Header("Win Condition")]
    [SerializeField] private int killsToWin = 5;

    private int kills;

    private void Awake()
    {
        Instance = this;
    }

    public void AddKill()
    {
        kills++;
        if (killCounterText != null)
            killCounterText.text = $"Kills: {kills}";

        if (kills >= killsToWin)
        {
            Win();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;   // стоп игры
        losePanel.SetActive(true);
        Debug.Log("Проигрыш!");
    }

    private void Win()
    {
        Time.timeScale = 0f;
        winPanel.SetActive(true);
        Debug.Log("Победа!");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
