using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private Transform target;
    private int damage;
    public float travelSpeed;
    public GameObject hitEffect;

	void Update () {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 dir = target.position - transform.position;
        float distancePerFrame = Time.deltaTime * travelSpeed;
        if(dir.magnitude <= distancePerFrame)
        {
            HitTarget();
        }

        transform.Translate(dir.normalized * distancePerFrame, Space.World);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

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
            Destroy(effect, 1f);
        }

        target.gameObject.GetComponent<Enemy>().hp -= damage;
        Destroy(gameObject);
    }
}
