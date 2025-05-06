using UnityEngine;

public class MoveSpawner : MonoBehaviour
{
    private Vector2 _mousePos;
    private Vector2 _spawnPos = new Vector2(0, 3.9f);
    private float edgesBox = 1.5f;
    private void OnEnable()
    {
        RobotPart.GameOver += StopMove;
    }

    private void OnDisable()
    {
        RobotPart.GameOver -= StopMove;
    }
    void Update()
    {
        _mousePos.x = Input.mousePosition.x;

        _spawnPos.x = Mathf.Clamp(Camera.main.ScreenToWorldPoint(_mousePos).x, -edgesBox, edgesBox);

        transform.position = _spawnPos;
    }
    private void StopMove(bool stop)
    {
        GetComponent<MoveSpawner>().enabled = !stop;
    }
}