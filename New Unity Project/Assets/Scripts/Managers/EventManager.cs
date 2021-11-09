using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void EnemySpawn();
    public static event EnemySpawn EnemySpawning;

    private void Awake()
    {
        if (EnemySpawning != null)
            EnemySpawning();
    }
}
