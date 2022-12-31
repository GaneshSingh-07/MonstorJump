using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] SpawnerPosition;
    public GameObject[] Enemys;

    private GameObject spawn;
    private int EnemyPosition;
    private int EnemyIndex;
    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    IEnumerator EnemySpawner() {
        while (true){
            yield return new WaitForSeconds(Random.Range(0,5));
            EnemyPosition = Random.Range(0,SpawnerPosition.Length);
            EnemyIndex = Random.Range(0, Enemys.Length);
            spawn = Instantiate(Enemys[EnemyIndex]);
            spawn.transform.position = SpawnerPosition[EnemyPosition].position;
            if(EnemyPosition == 0){
                spawn.GetComponent<EnemyMovevment>().speed = Random.Range(5f, 10f);
            }
            else if(EnemyPosition == 1){
                spawn.GetComponent<EnemyMovevment>().speed = -Random.Range(5f, 10f);
                spawn.GetComponent<EnemyMovevment>().transform.localScale = new Vector3(-1f, 1f, 1f);
                
            }

        }
       
        
    }
}
