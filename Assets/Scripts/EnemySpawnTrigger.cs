using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int enemyCount;
    [SerializeField] private float minXPos, maxXPos, minZPos, maxZPos, yPos;
    private void OnTriggerEnter(Collider other)
    {
        EnemySpawnManager.Instance.SpawnEnemy(enemy, enemyCount, minXPos, maxXPos, minZPos, maxZPos, yPos);
    }
}
