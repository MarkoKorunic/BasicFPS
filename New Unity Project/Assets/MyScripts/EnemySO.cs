using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "enemy")]


[Serializable]
public class EnemySO : ScriptableObject
{
    [SerializeField] public string enemyName; 
    [SerializeField] public int health;
    [SerializeField] public EnemySizes enemySize;



    public void Print()
    {
        Debug.Log(enemyName);
    }
}



public enum EnemySizes
{
    Small,
    Medium,
    Large

}