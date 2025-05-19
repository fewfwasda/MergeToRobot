using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using YG;

public class ManagerOfFinish : MonoBehaviour
{
    public GameObject ScreenOfFinish;
    private void OnEnable()
    {
        RobotPart.FinishGame += PlayFinishGame;
    }

    private void OnDisable()
    {
        RobotPart.FinishGame -= PlayFinishGame;
    }
    private void PlayFinishGame(GameObject megaRobot)
    {
        ScreenOfFinish.SetActive(true);

        megaRobot.transform.DOMove(new Vector3(0, 0, 0), 1);
        megaRobot.transform.DOScale(new Vector3(4, 4, 4), 1);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        YG2.InterstitialAdvShow();
    }
}
