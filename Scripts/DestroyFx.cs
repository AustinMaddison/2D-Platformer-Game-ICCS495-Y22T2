using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFx : MonoBehaviour
{

    public ParticleSystem _ps;
    public AudioSource _source;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!_ps.IsAlive() && !_source.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
