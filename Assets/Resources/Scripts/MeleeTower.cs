﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class MeleeTower : MonoBehaviour {

	[Header("Attributes")]
    public int maxHp;
    public int dmg;
    public int def;
    public float atkSpd;
    public int maxBlock;
    public string towerName;

	private int hp;
    private int block;
    private bool blocking = false;
    private BoxCollider2D boxCollider2D;
    private List<Transform> blockingEnemies;
    protected Transform target;
    private float cooldown = 0f;

    private int maxHpO;
    private int dmgO;
    private int defO;
    private float atkSpdO;
    private int maxBlockO;

    private bool commanded = false;

    public void Start () {
		hp = maxHp;
		boxCollider2D = GetComponent<BoxCollider2D>();
        blockingEnemies = new List<Transform>();

        maxHpO = maxHp;
        dmgO = dmg;
        defO = def;
        atkSpdO = atkSpd;
        maxBlockO = maxBlock;

    }

    void OnEnable()
    {
        //Weather Effect
        InvokeRepeating("Regeneration", 0f, 0.5f);

    }

	void FixedUpdate () {
        StatusChange();

        if (Input.GetMouseButtonDown(1))
        {
            StatusDisplay.instance.setTower(null);
        }

        RestoreBlock();
        if (block < maxBlock)
			boxCollider2D.enabled = true;
        else
			boxCollider2D.enabled = false;

        if(cooldown <= 0 && blocking)
        {
            UpdateTarget();
            if (target == null)
                return;
            Attack();
            cooldown = 1f / atkSpd;
        }
        cooldown -= Time.deltaTime;

    }

    void Regeneration()
    {
        if (WeatherSystem.weather == 1)
            {
                hp += 5;
				if (hp > maxHp)
					hp = maxHp;
            }
    }

    void UnderCommand()
    {
        if (GameObject.Find("Commander(Clone)") != null)
        {
            dmg *= (int)1.2f;
            def *= (int)1.2f;
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

    protected virtual void Attack()
    {
        
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

    void UpdateTarget()
    {
        if (blockingEnemies.Count > 0)
        {
            target = blockingEnemies.ElementAt(0);
        }
    }

	public void TakeDamage(int enemyDmg){

        if (enemyDmg > def)
        {
            hp = hp - (enemyDmg - def);
            if (hp <= 0)
            {
                hp = 0;
                Destroy(gameObject);
            }
        }
        else
        {
            hp -= 1;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
		
	}

    public int getCurrentHp()
    {
        return hp;
    }

    void OnMouseDown()
    {
        StatusDisplay.instance.setTower(this.gameObject);
    }

    void StatusChange()
    {
        if(GameObject.Find("Commander(Clone)") != null && !commanded)
        {
            commanded = true;
            dmg = (int)(dmg * 1.2f);
            def = (int)(def * 1.2f);
        }
        if (GameObject.Find("Commander(Clone)") == null)
        {
            dmg = dmgO;
            def = defO;
            commanded = false;
        }
    }
}
