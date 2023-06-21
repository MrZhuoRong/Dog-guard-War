using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject []enemyPrefab;
    public GameObject []BossPrefabs;
    private float Enemytime;
    private float Bosstime=15.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyPrefab != null)
        {
            enemyGeneration();
        }
        if(BossPrefabs != null)
        {
            BossGeneration();
        }
    }

    void enemyGeneration()
    {
        if (Enemytime > 0) { Enemytime -= Time.deltaTime; }

        else
        {
            int num = Random.Range(0, 3);
            var enemy = Instantiate(enemyPrefab[num]);
            enemy.transform.parent = this.transform;
            enemy.transform.localPosition = Vector3.zero;
            Enemytime = 10f;
        }
    }

    void BossGeneration()
    {
        if (Bosstime > 0) { Bosstime -= Time.deltaTime; }

        else
        {
            int num = Random.Range(0, 3);
            var enemy = Instantiate(BossPrefabs[num]);
            enemy.transform.parent = this.transform;
            enemy.transform.localPosition = Vector3.zero;
            Bosstime = Random.Range(15, 30);
        }
    }
}
