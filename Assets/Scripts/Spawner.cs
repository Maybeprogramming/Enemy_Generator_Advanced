using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint _spawnpoint;
    [SerializeField] private PreViewEnemyPoint _preViewEnemyPoint;
    //[SerializeField] private Timer _timer;
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
        MeshRenderer meshRenderer = FindObjectOfType<MeshRenderer>(previewEnemy);
        Color color = Color.white;
        color.a = 0.2f;
        meshRenderer.material.color = color;
    }

    public void OnSpawned()
    {
        //Instantiate(CreateEnemy(), _spawnpoint.transform.position, Quaternion.identity);
        CreateEnemy(_spawnpoint.transform, Target);
    }

    private Enemy CreateEnemy(Transform spawnPosition, Transform target)
    {
        //Enemy enemy = _enemyTemplate;
        Enemy enemy = Instantiate(_enemyTemplate, spawnPosition.position, Quaternion.identity); ;
        enemy.Init(target);
        //enemy.GetComponent<Mover>().enabled = true;
        //enemy.GetComponent<Animator>().enabled = true;
        return enemy;
    }

    //private void OnEnable()
    //{
    //    _timer.Triggered += OnSpawned;
    //}

    //private void OnDisable()
    //{
    //    _timer.Triggered -= OnSpawned;
    //}

    public void Init(Enemy enemy, Target target, Timer timer)
    {
        //_timer = timer;
        _enemyTemplate = enemy;
        _target = target;
    }
}
