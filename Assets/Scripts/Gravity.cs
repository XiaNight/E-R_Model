using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Gravity : MonoBehaviour
{
    public List<ForceRelation> forceRelations;
    public Rigidbody2D rb;
    public float pullDistance = 1;

    // Start is called before the first frame update
    void Start()
    {
        forceRelations = new List<ForceRelation>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (ForceRelation forceRelation in forceRelations)
        {
            if (forceRelation.target == null) continue;

            if((forceRelation.type & 1) == 1)
            {
                Vector3 reletivePosition = forceRelation.target.transform.InverseTransformPoint(transform.position);
                if(reletivePosition.magnitude > pullDistance)
                {
                    forceRelation.target.rb.AddRelativeForce(reletivePosition - reletivePosition.normalized * pullDistance);
                }
                
            }
            if ((forceRelation.type & 2) == 2)
            {
                Vector3 reletivePosition = transform.InverseTransformPoint(forceRelation.target.transform.position);
                if (reletivePosition.magnitude > pullDistance)
                {
                    rb.AddRelativeForce(reletivePosition - reletivePosition.normalized * pullDistance);
                }
            }
        }

        foreach (Entity entity in EREventSystem.current.entities)
        {
            if (entity == this) continue;
            float distance = Vector2.Distance(transform.position, entity.transform.position);
            if (distance < 1)
            {
                Vector3 direction = entity.transform.InverseTransformPoint(transform.position).normalized;
                entity.rb.AddRelativeForce(-direction * (2 - distance));
            }
        }
    }

    [Serializable]
    public struct ForceRelation
    {
        public Gravity target;
        public float force;
        /// <summary>
        /// 0: none, 1: pull, 2: push, 3: push
        /// </summary>
        public int type;
    }
}
