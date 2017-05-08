using UnityEngine;

public class Enemy : MonoBehaviour {

    [Header("Attributes")]
    public float moveSpeed;
    public int hp;
    public int dmg;
    public float atkSpeed;
    public bool grounded;

    private bool blocked;
    private Transform target;
    private int wavePointIndex = 0;
    private Transform attackTarget;
    private float coolDown = 0f;
    private float moveSpeedTemp;

    //Debuff Countdowns
    private float slowCountdown = 0f;

    //Debuff booleans
    private bool isSlowed = false;

    void Start()
    {
        target = Waypoints.points[0];
        moveSpeedTemp = moveSpeed;
    }

    void FixedUpdate()
    {
        if (slowCountdown > 0)
        {    
            if (!isSlowed)
            {
                isSlowed = true;
                moveSpeed = 0.5f * moveSpeedTemp;
            }
            slowCountdown -= Time.deltaTime;
           
        }
        else
        {
            moveSpeed = moveSpeedTemp;
            isSlowed = false;
        }

        if (attackTarget == null)
        {
            blocked = false;
        }

        Vector2 dir = target.position - transform.position;
        if (!blocked)
            transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);

        if (coolDown <= 0)
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
			attackTarget.gameObject.GetComponent<MeleeTower>().TakeDamage(dmg);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "MeleeTower")
        {
            blocked = true;
            attackTarget = coll.transform;
        }
    }

    public void RefreshDebuffCountdown(string debuff, float cd)
    {
        if (debuff.Equals("Slow"))
            slowCountdown = cd;
    }
}
