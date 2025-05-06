using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
public enum Evolution
{
    Screw,
    Bolt,
    Gear,
    Spring,
    Arm,
    Capacitor,
    Battery,
    Circuit,
    ServoMotor,
    Engine,
    Body,
    Robot,
    MegaRobot
}
public class RobotPart : MonoBehaviour
{
    public static Action<int> Merged;
    public static Action<bool> GameOver;
    [SerializeField] private Evolution evolution = Evolution.Bolt;
    [SerializeField] private List<GameObject> partsRobot = new List<GameObject>();
    [SerializeField] private ParticleSystem _particle;
    private int _triggerLineOfDeath;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _triggerLineOfDeath++;
        if(_triggerLineOfDeath >= 2)
        {
            GameOver?.Invoke(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out RobotPart robotPart))
        {
            if (evolution == robotPart.evolution && GetInstanceID() > collision.gameObject.GetInstanceID() && ((int)evolution) +1 < partsRobot.Count)
            {
                robotPart.Upgrate();
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
    private void Upgrate()
    {
        int indexPart = ((int)evolution) + 1;
        GameObject evolutionPart = partsRobot[indexPart];
        Instantiate(evolutionPart, transform.position, Quaternion.identity);
        Merged?.Invoke(indexPart * 5);
        Instantiate(_particle, transform.position, Quaternion.identity);
    }
}
