using TMPro;
using UnityEngine;

public class AvailableScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text label;
    [SerializeField] private ScoreManager scoreManager;
    private void Awake()
    {
        scoreManager.scoreAvailableCell.ListenUpdates(UpdateScore);
        UpdateScore(scoreManager.scoreAvailable);
    }

    private void UpdateScore(int score)
    {
        label.text = $"{score}/1K";
    }
}
