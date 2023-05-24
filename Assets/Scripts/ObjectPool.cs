using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    [SerializeField] [Range (0, 50)] int poolSize = 5;

    //устанавливаем диапазон допустимых значени для инспектора
    [SerializeField] [Range (0.1f, 30f)] float spawnTimer = 1f;
    GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }
    void PopulatePool(){
        pool = new GameObject[poolSize];
        for(int i = 0;  i < pool.Length; i++){
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyInstantiator());
    }

    IEnumerator EnemyInstantiator()
    {
        while(true) {
            EnabledObjectInPool();
            yield return new WaitForSeconds(1f);
        }
        
    }

    private void EnabledObjectInPool()
    {
        for (int i = 0; i<pool.Length; i++){
            if (pool[i].activeInHierarchy == false){
                pool[i].SetActive(true);
                return;
            }
        }
    }
}
