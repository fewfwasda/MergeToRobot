using UnityEngine;
using System.Collections.Generic;
using System;

public class RobotPart : MonoBehaviour
{
    public static Action Merged;
    public static Action StopGame;
    public static Action<bool> GameOver;
    public static Action<GameObject> FinishGame;

    [SerializeField] private EvolutionRobotPart.Evolution evolutionRobotPart;
    [SerializeField] private List<GameObject> mergePrefabs = new List<GameObject>();
    [SerializeField] private ParticleSystem _particle;
    
    private int _countTriggerLineOfDeadth;
    private bool _isMerging = false;
    private int _indexPart;

    private void Start()
    {
        _indexPart = (int)evolutionRobotPart;
        if (_indexPart == mergePrefabs.Count-1)
        {
            StopGame?.Invoke();
            FinishGame?.Invoke(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isMerging) return;
        if (collision.gameObject.TryGetComponent(out RobotPart otherPart))
        {
            if (evolutionRobotPart == otherPart.evolutionRobotPart &&
                _indexPart + 1 < mergePrefabs.Count)
            {
                Destroy(collision.gameObject);

                _isMerging = true;
                otherPart._isMerging = true;

                Invoke(nameof(Merge), 0.1f);
            }
        }
    }
    private void Merge()
    {
        if (_indexPart + 1 >= mergePrefabs.Count) return;
        GameObject newPart = mergePrefabs[_indexPart + 1];
        Instantiate(newPart, transform.position, Quaternion.identity);

        Destroy(gameObject);

        Merged?.Invoke();

        ParticleEffect();
    }
    private void ParticleEffect()
    {
        Instantiate(_particle, transform.position, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _countTriggerLineOfDeadth++;
        if (_countTriggerLineOfDeadth >= 2)
        {
            GameOver?.Invoke(true);
            StopGame?.Invoke();
        }
    }
    private void OnDestroy()
    {
        CancelInvoke();
    }
}
