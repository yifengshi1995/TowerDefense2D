using UnityEngine;
using System.Collections;

public class ArrowTower : MonoBehaviour
{

	[Header("Attributes")]
	public int dmg;
	public float shootSpeed;
	public float range;
	public GameObject bulletPrefab;

	private Transform target;
	private Transform endPoint;
	private float cooldown;

	// Use this for initialization
	void Start ()
	{
		endPoint = GameObject.FindGameObjectWithTag("EndPoint").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (cooldown <= 0)
		{
			UpdateTarget();
			if (target == null)
				return;
			Attack();
			cooldown = 1f / shootSpeed;
		}
		cooldown -= Time.deltaTime;
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}

	void Attack()
	{
		Bullet bullet;

		GameObject bulletObject = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
		bullet = bulletObject.GetComponent<Bullet>();

		if (bullet != null)
			bullet.Travel(target, dmg);
	}

	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		float closest = Mathf.Infinity;
		GameObject neareastEnemy = null;

		foreach (GameObject enemy in enemies)
		{
			float distToEnd = Vector2.Distance(endPoint.position, enemy.transform.position);
			float distance = Vector2.Distance(transform.position, enemy.transform.position);
			if (distToEnd < closest && distance <= range)
			{
				closest = distToEnd;
				neareastEnemy = enemy;
			}
		}

		if (neareastEnemy != null)
		{
			target = neareastEnemy.transform;
		}
		else
		{
			target = null;
		}
	}
}

