using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace BattleTank
{
    public class UITankController : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform firePoint;
        public Transform turrent;
        public float rotationSpeed = 1f;
        public float timeBetweenShots = 3f;
        public float bulletSpeed = 5f;

        [Header("Values")]
        [SerializeField] private float CircleRadius = 1;
        [SerializeField] private float ElevationOffset = 0;
        private Vector3 positionOffset;
        private float angle;

        private UITankPool bulletPool;
        private float timer = 0f;

        void Start()
        {
            // Assuming you have an ObjectPool class for bullet pooling
           // bulletPool = new UITankPool(bulletPrefab, 10); // You can adjust the pool size as needed
        }

        void Update()
        {
            //RotateTank();
            //ShootBullets();
        }

        private void TurrentMovement()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.x = 0;
            //transform.position = mousePos;
            turrent.transform.LookAt(mousePos);
        }

        void RotateTank()
        {
            //transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            positionOffset.Set(Mathf.Cos(angle) * CircleRadius, ElevationOffset, Mathf.Sin(angle) * CircleRadius);

            transform.position = firePoint.position + positionOffset;
            angle += Time.deltaTime * rotationSpeed;

            transform.LookAt(firePoint.position);
        }

        void ShootBullets()
        {
            timer += Time.deltaTime;

            if (timer >= timeBetweenShots)
            {
                FireBullet();
                timer = 0f;
            }
        }

        void FireBullet()
        {
            GameObject bullet = bulletPool.GetPooledObject();

            if (bullet != null)
            {
                bullet.transform.position = firePoint.position;
                bullet.transform.rotation = firePoint.rotation;
                bullet.SetActive(true);

                // Add force or apply other behaviors to the bullet
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
            }
        }
    }
}
