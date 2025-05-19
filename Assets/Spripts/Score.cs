using TMPro;
using UnityEngine;
using YG;
public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI BestScoreText;
    private int _score;
    private int _bestScore;

    private void Start()
    {
        _bestScore = YG2.GetState("Scoree");
        _scoreText.text = $"СЧЕТ: {_score}";
        BestScoreText.text = $"РЕКОРД: {_bestScore}";
    }

    private void OnEnable()
    {
        RobotPart.Merged += AddScore;
    }

    private void OnDisable()
    {
        RobotPart.Merged -= AddScore;        
    }

    private void AddScore()
    {
        // Начисляем случайное значение
        int delta = Random.Range(3, 10);
        _score += delta;
        _scoreText.text = $"СЧЕТ: {_score}";

        // Сохраняем, если побит рекорд
        if (_score > _bestScore)
        {
            _bestScore = _score;
            BestScoreText.text = $"РЕКОРД: {_bestScore}";
        }
    }
    private void SaveScore()
    {
        YG2.SetState("Scoree", _bestScore);
    }
}