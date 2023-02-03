using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private PlayerController playerController;
    private float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10){
            Destroy(gameObject);
        }
        // Debug.Log((playerController.transform.position - transform.position).normalized);
        Vector3 lookDir = (playerController.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDir * speed);
    }
}
