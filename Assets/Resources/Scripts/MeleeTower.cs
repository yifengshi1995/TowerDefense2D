using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class MeleeTower : MonoBehaviour {

    public int hp;
    public int dmg;
    public float atkSpd;
    public int maxBlock;

    private int block;
    private bool blocking = false;
    private BoxCollider2D bc;
    private List<Transform> blockingEnemies;
    private Transform target;
    private float cooldown = 0f;

    void Start () {
        bc = GetComponent<BoxCollider2D>();
        blockingEnemies = new List<Transform>();
    }

    void OnEnable()
    {
        //Weather Effect
        InvokeRepeating("Regeneration", 0f, 0.5f);
    }

	void Update () {  

        RestoreBlock();
        if (block < maxBlock)
            bc.enabled = true;
        else
            bc.enabled = false;

        if(cooldown <= 0 && blocking)
        {
            UpdateTarget();
            if (target == null)
                return;
            Attack();
            cooldown = 1f / atkSpd;
        }
        cooldown -= Time.deltaTime;

        if (hp <= 0)
            Destroy(gameObject);

        
    }

    void Regeneration()
    {
        if (WeatherSystem.weather == 1)
            {
                hp += 5;
                Debug.Log(hp);
            }
    }

    void RestoreBlock()
    {
        if(blockingEnemies != null)
        {
            foreach (Transform enemy in blockingEnemies.ToList())
            {
                if (enemy == null)
                {
                    block--;
                    blockingEnemies.Remove(enemy);
                }

                if (block == 0)
                    blocking = false;
            }
        }
    }

    void Attack()
    {
        target.gameObject.GetComponent<Enemy>().hp -= dmg;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if ((coll.gameObject.tag == "Enemy"))
        {
            block++;
            blocking = true;
            blockingEnemies.Add(coll.transform);
        }
    }

//    void OnTriggerExit2D(Collider2D coll)
//    {
//        block--;
//        blockingEnemies.Remove(coll.transform);
//        if (block == 0)
//            blocking = false;
//    }

    void UpdateTarget()
    {
        if (blockingEnemies.Count > 0)
        {
            target = blockingEnemies.ElementAt(0);
        }
    }
}
