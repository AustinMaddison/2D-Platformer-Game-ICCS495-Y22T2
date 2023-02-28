using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("BULLET CONFIG")]
    public float speed = 20f;
    public int damage = 10;
    public float despawn_time = 5f;
    public Rigidbody2D rb;
    public GameObject CollisionEffect;
    public string BulletShotFromTag;

    // Start is called before the first frame update
    void Start()
    {
        Transform objectTrasform = GetComponent<Transform>();
        rb.velocity = transform.right * speed * objectTrasform.localScale.x;
        StartCoroutine(SelfDestruct());
    }


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        // Colliders that are not characters nor level
        if (hitInfo.CompareTag("BulletCantCollide")) return;
        if (BulletShotFromTag == hitInfo.tag) return;


        // Spawn FX
        Instantiate(CollisionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

        // Damage
        if(hitInfo.CompareTag("Enemy"))
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy != null) enemy.TakeDamage(damage);
        }
        if (hitInfo.CompareTag("Player"))
        {
            PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
            if ( player != null) player.TakeDamage(damage);
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(despawn_time);
        Destroy(gameObject);
    }
}
