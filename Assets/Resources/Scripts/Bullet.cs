using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private Transform target;
    private int damage;
    public float travelSpeed;
    public GameObject hitEffect;
    public bool isInstant;
    public bool isSlow;

    [Header("Explosive Bullet Only")]
    public float explosiveRadius;

	void Update () {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        if (!isInstant)
        {
            Vector2 dir = target.position - transform.position;
            float distancePerFrame = Time.deltaTime * travelSpeed;
            if (dir.magnitude <= distancePerFrame)
            {
                HitTarget();
            }

            transform.Translate(dir.normalized * distancePerFrame, Space.World);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            HitTarget();
        }

    }

    public void Travel(Transform _target, int dmg)
    {
        target = _target;
        damage = dmg;
    }

    void HitTarget()
    {
        if(hitEffect != null)
        {
            GameObject effect = (GameObject)Instantiate(hitEffect, transform.position, transform.rotation);
            effect.GetComponent<HitEffect>().assignTarget(target);
            Destroy(effect, 0.3f);
        }

        if (isSlow)
        {
            target.gameObject.GetComponent<Enemy>().RefreshDebuffCountdown("Slow", 1f);
        }

        if(explosiveRadius > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        
        
    }

    void Explode()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, explosiveRadius);

        foreach (Collider2D enemy in enemiesInRange)
        {
            if(enemy.tag == "Enemy")
            {
                Damage(enemy.transform);
            }
        }
        
        Destroy(gameObject);

    }

    void Damage(Transform target)
    {
        target.gameObject.GetComponent<Enemy>().hp -= damage;
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosiveRadius);
    }
}
