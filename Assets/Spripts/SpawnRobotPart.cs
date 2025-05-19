using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpawnRobotPart : MonoBehaviour
{
    private GameObject _detail;
    private SpriteRenderer _spriteDetail;
    private int _indexDetail;
    private float _delay;
    [SerializeField] private List<GameObject> _parts = new List<GameObject>();
    [SerializeField] private List<Sprite> _spritesParts = new List<Sprite>();
    private bool _isSpawn;
    private void Start()
    {
        _spriteDetail = GetComponent<SpriteRenderer>();

        _isSpawn = true;
        _delay = 0;

        ShowDetail();
    }
    void Update()
    {
        Timer();
        if (_delay <= 0 && (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)) && _isSpawn)
        {
            _delay = 0.3f;
            Spawn();
            ShowDetail();
        }
    }
    private void Timer()
    {
        _delay -= Time.deltaTime;
    }
    private void Spawn()
    {
        Instantiate(GetPart(), transform.position, Quaternion.identity);
    }
    private void ShowDetail()
    {
        _spriteDetail.sprite = _spritesParts[GetRandomIndex()];
    }
    private GameObject GetPart()
    {
        _detail = _parts[_indexDetail];
        return _detail;
    }
    private int GetRandomIndex()
    {
        _indexDetail = Random.Range(0, _parts.Count);
        return _indexDetail;
    }
    private void OnEnable()
    {
        RobotPart.StopGame += StopSpawn;
    }

    private void OnDisable()
    {
        RobotPart.StopGame -= StopSpawn;
    }
    private void StopSpawn()
    {
        _isSpawn = false;
    }
}
