using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint _spawnpoint;
    [SerializeField] private PreViewEnemyPoint _preViewEnemyPoint;
    [SerializeField] private Target _target;
    [SerializeField] private Enemy _enemyTemplate;

    public Transform Target => _target.transform;

    private void Start()
    {
        _spawnpoint = GetComponentInChildren<SpawnPoint>();
        _preViewEnemyPoint = GetComponentInChildren<PreViewEnemyPoint>();

        var previewEnemy = Instantiate(_enemyTemplate, _preViewEnemyPoint.transform);
        previewEnemy.GetComponent<Mover>().enabled = false;
        previewEnemy.GetComponent<Animator>().enabled = false;
        Color color = Color.white;
        color.a = 0.2f;
        //MeshRenderer meshRenderer = FindObjectOfType<MeshRenderer>(previewEnemy);
        //meshRenderer.material.color = color;
    }

    public void OnSpawned()
    {
        CreateEnemy(_spawnpoint.transform, Target);
    }

    private Enemy CreateEnemy(Transform spawnPosition, Transform target)
    {
        Enemy enemy = Instantiate(_enemyTemplate, spawnPosition.position, Quaternion.identity); ;
        enemy.Init(target);
        return enemy;
    }

    public void Init(Enemy enemy, Target target)
    {
        _enemyTemplate = enemy;
        _target = target;
    }
}
