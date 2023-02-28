using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousePosToWorldPos : MonoBehaviour
{

    public Vector3 screenPos;
    public Vector3 worldPos;
    public float offsetPlane;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        screenPos = Input.mousePosition;
        screenPos.z = Camera.main.nearClipPlane + offsetPlane + 1;

        worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        transform.position = worldPos;
    }
}
