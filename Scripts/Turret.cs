using AustinController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update

    public LookAtPlayer _lookatplayer;
    public Transform muzzlePoint;
    //public Transform Direction;
    public GameObject bulletPrefab;
    public float fireRate = 0.5f;  //bullets per seconds
    public Animator _anim;
    [Header("SHOOTING SOUND")]
    public float maxPitch = 1.0f;
    public float minPitch = 0.6f;
    [Header("MuzzleFix")]
    public GameObject muzzleObject;

    private IPlayerController _player;
    [Header("Audio")]
    [SerializeField]
    private AudioSource _source;
    [SerializeField]
    private AudioClip _clip;
    private bool _canShoot = true;

    private float _lastFireTime;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(_lookatplayer.playerInRange && _canShoot)
        {
            _anim.SetBool(MuzzleFlashKey, true);
            Shoot();
        }
        else
            _anim.SetBool(MuzzleFlashKey, false);
    }
    void Shoot()
    {
        if (Time.time - _lastFireTime >= 1f / fireRate)
        {
            // Audio
            _source.pitch = (Random.Range(minPitch, maxPitch));
            //Debug.Log("PITCH: " + _source.pitch);
            _source.PlayOneShot(_clip);

            // Flip bulllet
            GameObject bulletObject = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
            Vector3 scale = bulletObject.transform.localScale;
            //Debug.Log("Direction: " + Direction.localScale.x);

            _lastFireTime = Time.time;

        }



    }

    private static readonly int MuzzleFlashKey = Animator.StringToHash("MuzzleFlashOn");


}
