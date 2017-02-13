using UnityEngine;
using System.Collections;

public class HitEffect : MonoBehaviour {

    public bool isTraceingTarget;
    private Transform target;

    void Update()
    {
        if (isTraceingTarget)
        {
            if (target != null)
            {
                transform.position = new Vector3(target.position.x, target.position.y, -6);
            }
        }
    }

    public void assignTarget(Transform _target)
    {
        target = _target;
    }
}
