using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnManager : MonoBehaviour
{
    private static EnemySpawnManager _instance;

    public static EnemySpawnManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("EnemySpawnManager is null");
            }

            return _instance;
        }
    }

    private int _currentEnemyCount;
    private float _xPos, _zPos;
    
    private void Awake()
    {
        _instance = this;
    }

    public void SpawnEnemy(GameObject enemy,int enemyCount,float minXPos, float maxXPos, float minZPos, float maxZPos, float yPos)
    {
        StartCoroutine(EnemyDrop(enemy,enemyCount,minXPos, maxXPos, minZPos, maxZPos, yPos));
    }

    IEnumerator EnemyDrop(GameObject enemy,int enemyCount,float minXPos, float maxXPos, float minZPos, float maxZPos, float yPos)
    {
        while (_currentEnemyCount < enemyCount)
        {
            _xPos = Random.Range(minXPos, maxXPos);
            _zPos = Random.Range(minZPos, maxZPos);
            Instantiate(enemy, new Vector3(_xPos, yPos, _zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            _currentEnemyCount += 1;
        }
    }
}
