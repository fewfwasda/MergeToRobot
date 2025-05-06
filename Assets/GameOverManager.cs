using TMPro;
using UnityEngine;
using YG;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    private float _timer = 10;
    public TextMeshProUGUI Timer;
    public Image GearTimer;
    public GameObject ScreenOfDeath;
    private bool _startTimer = false;
    private void OnEnable()
    {
        RobotPart.GameOver += GameOver;
    }

    private void OnDisable()
    {
        RobotPart.GameOver -= GameOver;
    }
    private void Update()
    {
        if (_startTimer && _timer >= 0)
        {
            _timer -= Time.deltaTime;
            Timer.text = $"{((int)_timer)}";
            GearTimer.fillAmount = _timer / 10;
        }
    }
    private void GameOver(bool gameOver)
    {
        _startTimer = gameOver;
        ScreenOfDeath.SetActive(gameOver);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        YG2.InterstitialAdvShow();
    }
}
