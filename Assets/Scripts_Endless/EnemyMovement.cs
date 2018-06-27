using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour {

    public float enemySpeed = 1f;

    void FixedUpdate()
    {
        //transform.position -= transform.right * Time.deltaTime * enemySpeed;
        transform.position += transform.forward * Time.deltaTime * enemySpeed;
        enemySpeed += 3f * Time.deltaTime;
    }
}

