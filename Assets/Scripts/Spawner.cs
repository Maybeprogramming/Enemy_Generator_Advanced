using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint _spawnpoint;
    [SerializeField] private PreviewEnemyPoint _previewEnemyPoint;
    [SerializeField] private Target _target;
    [SerializeField] private Enemy _enemyTemplate;

    public Transform Target => _target.transform;

    public void Init(Enemy enemy, Target target)
    {
        _enemyTemplate = enemy;
        _target = target;
    }

    public void SpawnEnemy()
    {
        CreateEnemy(_spawnpoint.transform, Target);
    }

    private void Start()
    {
        _spawnpoint = GetComponentInChildren<SpawnPoint>();
        _previewEnemyPoint = GetComponentInChildren<PreviewEnemyPoint>();

        CreatePreviewEnemy();
    }

    private void CreatePreviewEnemy()
    {
        Enemy previewEnemy = Instantiate(_enemyTemplate, _previewEnemyPoint.transform);
        previewEnemy.GetComponent<Mover>().enabled = false;
        previewEnemy.GetComponent<Animator>().enabled = false;
    }

    private Enemy CreateEnemy(Transform spawnPosition, Transform target)
    {
        Enemy enemy = Instantiate(_enemyTemplate, spawnPosition.position, Quaternion.identity); ;
        enemy.Init(target);
        return enemy;
    }
}
