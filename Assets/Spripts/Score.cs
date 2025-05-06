using TMPro;
using UnityEngine;
using YG;
public class Score : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    public TextMeshProUGUI BestScoreText;
    private int _score;
    private int _bestScore;
    private void Start()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
        _scoreText.text = $"явер: {_score}";
        _bestScore =  YG2.GetState("BestScore");
        BestScoreText.text = $"пейнпд: {_bestScore}";

    }
    private void OnEnable()
    {
        RobotPart.Merged += AddScore;
    }

    private void OnDisable()
    {
        RobotPart.Merged -= AddScore;
    }
    private void AddScore(int addScore)
    {
        _score+= addScore;
        _scoreText.text = $"явер: {_score}";
        if (_score >= _bestScore)
        {
            _bestScore = _score;
            BestScoreText.text = $"пейнпд: {_bestScore}";
            YG2.SetState("BestScore", _bestScore);
        }
    }
}
