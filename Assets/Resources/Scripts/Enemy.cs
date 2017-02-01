using UnityEngine;

public class Enemy : MonoBehaviour {

    [Header("Attributes")]
    public float moveSpeed;
    public int hp;
    public int dmg;
    public float atkSpeed;

    private bool blocked;
    private Transform target;
    private int wavePointIndex = 0;
    private Transform attackTarget;
    private float coolDown = 0f;

    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        if(attackTarget == null)
        {
            blocked = false;
        }

        Vector2 dir = target.position - transform.position;
        if(!blocked)
            transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);

        if(coolDown <= 0)
        {
            Attack();
            coolDown = 1f / atkSpeed;
        }
        coolDown -= Time.deltaTime;

        if (Vector2.Distance(transform.position, target.position) <= 10f)
        {
            if (wavePointIndex >= Waypoints.points.Length - 1)
            {
                Destroy(gameObject);
                return;
            }
            wavePointIndex++;
            target = Waypoints.points[wavePointIndex];
        }

        if (hp <= 0)
            Destroy(gameObject);  
    }

    void Attack()
    {
        if (blocked)
        {
            attackTarget.gameObject.GetComponent<MeleeTower>().hp -= dmg;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            blocked = true;
            attackTarget = coll.transform;
        }
    }
}
