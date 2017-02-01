using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public Transform spawnPoint;
    public float initialCountdown = 2f;
    
    void Update()
    {
        if(initialCountdown <= 0f)
        {
            StartCoroutine(Spawn());
            this.enabled = false;
        }

        initialCountdown -= Time.deltaTime;
        

    }

    void Start()
    {


    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < EnemyManager.enemyList.Length; i++)
        {
            Instantiate(Resources.Load("Prefabs/"+EnemyManager.enemyList[i].getName()), spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(EnemyManager.enemyList[i].getWaitTime());
        }
    }
}
