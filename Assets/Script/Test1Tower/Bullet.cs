using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
        
        
        
    }

    

    private void Update()
    {
        if(gameObject.transform.position.x > 150 || gameObject.transform.position.x < -150) gameObject.SetActive(false);
        transform.position += transform.right * 0.25f;
    }
}
