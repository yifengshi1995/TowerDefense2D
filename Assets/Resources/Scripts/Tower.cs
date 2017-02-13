using UnityEngine;

public class Tower : MonoBehaviour {

    [Header("Attributes")]
    public int dmg;
    public float atkSpd;
    private Transform endPoint;
    public float range;
    public GameObject bulletPrefab;
    public bool isInstant;

    private Transform target;
    private float cooldown = 0f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Start()
    {
        endPoint = GameObject.FindGameObjectWithTag("EndPoint").transform;
    }

    void Update()
    {
        if (cooldown <= 0)
        {
            UpdateTarget();
            if (target == null)
                return;
            Attack();
            cooldown = 1f / atkSpd;
        }
        cooldown -= Time.deltaTime;

    }

    void Attack()
    {
        Bullet bullet;
        if (isInstant)
        {
            GameObject bulletObject = (GameObject)Instantiate(bulletPrefab, target.position, target.rotation);
            bullet = bulletObject.GetComponent<Bullet>();
        }
        else
        {
            GameObject bulletObject = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet = bulletObject.GetComponent<Bullet>();
        }
        

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
