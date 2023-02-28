using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    public LookAtPlayer _lookatplayer;
    public GameObject player;
    public float followSpeed = 5f;
    public float hoverHeight = 2f;
    public float hoverDamp = 0.5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (_lookatplayer.playerInRange)
        {
            // Move towards the player
            Vector2 direction = player.transform.position - transform.position;
            rb.velocity = direction.normalized * followSpeed;

            // Calculate the desired height and adjust the drone's velocity
            float distance = Mathf.Abs(transform.position.y - player.transform.position.y);
            float heightError = hoverHeight - distance;
            float verticalVelocity = rb.velocity.y;
            rb.AddForce(Vector2.up * heightError * hoverDamp - Vector2.up * verticalVelocity * hoverDamp, ForceMode2D.Force);

            // Constrain the rotation of the drone
            //rb.rotation = 0f;
        }

    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
