using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject pivot;
    public bool playerInRange;
    public float rotationSpeed = 5f;
    public float flipThreshold = 90f;

    private Collider2D collider;
    private Vector3 defaultScale;

    void Start()
    {
        collider = pivot.GetComponent<Collider2D>();
        defaultScale = pivot.transform.localScale;
    }

    void Update()
    {
        if (collider.bounds.Contains(player.transform.position))
        {
            playerInRange= true;
            Vector3 direction = (player.transform.position - pivot.transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion currentRotation = pivot.transform.rotation;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Check if rotation is greater than the flip threshold
            if (currentRotation.eulerAngles.z < 270f && currentRotation.eulerAngles.z > 90f)
            {
                //Debug.Log("1");
                pivot.transform.localScale = new Vector3(-defaultScale.x, -defaultScale.y, defaultScale.z);
            }
            else if (currentRotation.eulerAngles.z > 270f && currentRotation.eulerAngles.z < 90f)
            {
                //Debug.Log("2");
                pivot.transform.localScale = new Vector3(-defaultScale.x, defaultScale.y, defaultScale.z);
            }
            else
            {
                //Debug.Log("3");
                pivot.transform.localScale = new Vector3(-defaultScale.x, defaultScale.y, defaultScale.z);
            }
            //Debug.Log("Target Rot: "+ targetRotation.eulerAngles);
            // Smoothly interpolate rotation using Quaternion.Slerp
            pivot.transform.rotation = Quaternion.Slerp(pivot.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
            playerInRange = false;
    }

}