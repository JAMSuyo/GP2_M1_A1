using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 5f;
    private Vector3 initPos;

    void Awake()
    {
        initPos = transform.position; 
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        float distanceTravelled = Vector3.Distance(initPos, transform.position);

        Destroy(gameObject);
    }
}
