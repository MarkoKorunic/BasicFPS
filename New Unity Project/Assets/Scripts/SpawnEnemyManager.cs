using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{
    [SerializeField] public Terrain terrain;
    [SerializeField] public int enemyAmount;
    public GameObject enemyPrefab;
    public float yOffset = 0.5f;

    private float terrainWidth;
    private float terrainLength;
    private float xTerrainPos;
    private float zTerrainPos;


    void Start()
    {
        terrainWidth = terrain.terrainData.size.x;
        terrainLength = terrain.terrainData.size.z;
        xTerrainPos = terrain.transform.position.x;
        zTerrainPos = terrain.transform.position.z;

        generateObjectOnTerrain();
    }

    void generateObjectOnTerrain()
    {
        for(var i = 1; i <=enemyAmount; i++)
        {
            float randX = UnityEngine.Random.Range(xTerrainPos, xTerrainPos + terrainWidth);
            float randZ = UnityEngine.Random.Range(zTerrainPos, zTerrainPos + terrainLength);
            float yVal = Terrain.activeTerrain.SampleHeight(new Vector3(randX, 0, randZ));

            yVal = yVal + yOffset;

            GameObject enemyInstance = (GameObject)Instantiate(enemyPrefab, new Vector3(randX, yVal, randZ), Quaternion.identity);
        }
    }

}
