using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public GameObject player;
    public int damage=1000;
    private Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (collider.bounds.Contains(player.transform.position))
        {
            var playerHealth = player.GetComponentInParent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
        }

    }


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("Hazard: " + hitInfo);
        if (hitInfo.CompareTag("Player"))
        {
            PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
            if (player != null) player.TakeDamage(damage);
        }
    }


}
