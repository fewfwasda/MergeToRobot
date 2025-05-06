using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip metalClank;
    private void OnEnable()
    {
        RobotPart.Merged += PlaySFX;
    }

    private void OnDisable()
    {
        RobotPart.Merged -= PlaySFX;
    }
    private void PlaySFX(int addScore)
    {
        audioSource.PlayOneShot(metalClank);
    }
}
