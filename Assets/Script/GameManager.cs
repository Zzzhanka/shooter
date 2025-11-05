using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI killCounterText;

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
    }
}
