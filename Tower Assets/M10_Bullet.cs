using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M10_Bullet : MonoBehaviour
{
    private Transform target;

    [Header("Bullet Behavior")]
    public float speed = 30f;   //fast projectile
    public int damage = 50;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceToFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceToFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceToFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        Destroy(gameObject);
    }
}