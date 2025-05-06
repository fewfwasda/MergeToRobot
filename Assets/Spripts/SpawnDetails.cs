using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpawnDetails : MonoBehaviour
{
    private GameObject _detail;
    private SpriteRenderer _spriteDetail;
    private int _indexDetail;
    private float delay;
    [SerializeField] private List<GameObject> _parts = new List<GameObject>();
    [SerializeField] private List<Sprite> _spritesParts = new List<Sprite>();
    private void Start()
    {
        _spriteDetail = GetComponent<SpriteRenderer>();
        ShowDetail();
        delay = 0;
    }
    void Update()
    {
        Timer();
        if ((Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)) && delay <= 0)
        {
            delay = 0.5f;
            Spawn();
            ShowDetail();
        }
    }
    private void Timer()
    {
        
        delay -= Time.deltaTime;
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
}
