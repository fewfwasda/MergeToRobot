using UnityEngine;

public class SFXManager : MonoBehaviour
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
    private void PlaySFX()
    {
        audioSource.PlayOneShot(metalClank);
    }
}
