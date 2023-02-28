using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    public string nextLevelName;
    public GameObject player;
    private Collider2D collider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<ChangeScene>().btnChangeScene(nextLevelName);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<Collider2D>();
    }


    private void FixedUpdate()
    {
        if (collider.bounds.Contains(player.transform.position))
        {
            FindObjectOfType<ChangeScene>().btnChangeScene(nextLevelName);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
