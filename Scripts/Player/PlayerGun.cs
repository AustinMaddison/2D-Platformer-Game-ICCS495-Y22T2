using AustinController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AustinController
{
    public class PlayerGun : MonoBehaviour
    {
        public Transform MuzzlePoint;
        public Transform Direction;
        public GameObject bulletPrefab;
        public float fireRate = 0.5f;  //bullets per seconds
        public Animator _anim;
        [Header("SHOOTING SOUND")]
        public float maxPitch = 1.0f;
        public float minPitch = 1.0f;

        private IPlayerController _player;
        [SerializeField]
        private AudioSource _source;
        [SerializeField]
        private AudioClip _clip;
        private bool _canShoot = true;

        private float _lastFireTime;



        void Awake()
        {
            _player = GetComponent<IPlayerController>();
            _source.clip = _clip;
        }

 

        // Update is called once per frame
        void Update()
        {
            if (_player == null)
            {
                Debug.Log("Error cant get player interface");
                return;
            }

            if (_player.ShootThisFrame && _canShoot)
            {
                _anim.SetBool(MuzzleFlashKey, true);
                Shoot();
            }
            else
                _anim.SetBool(MuzzleFlashKey, false);
              

        }

        void Shoot()
        {
            if(Time.time - _lastFireTime >= 1f / fireRate)
            {
                // Audio
                _source.pitch = (Random.Range(minPitch, maxPitch));
                //Debug.Log("PITCH: " + _source.pitch);
                _source.PlayOneShot(_clip);

                // Flip bulllet
                GameObject bulletObject = Instantiate(bulletPrefab, MuzzlePoint.position, MuzzlePoint.rotation);
                Vector3 scale = bulletObject.transform.localScale;
                //Debug.Log("Direction: " + Direction.localScale.x);
                if (Direction.localScale.x != 1)
                {
                    scale.x *= -1;
                    bulletObject.transform.localScale = scale;
                }

                _lastFireTime = Time.time;


            }

           

        }
    
        private static readonly int MuzzleFlashKey = Animator.StringToHash("MuzzleFlashOn");


    }
}


