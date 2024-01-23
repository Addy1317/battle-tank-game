using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class UITank : MonoBehaviour
    {
        [Header("Destroyed Tank Reference")]
        [SerializeField] private Transform DestroyedTank;

        [Header("Values")]
        [SerializeField] private float RotationSpeed = 1;
        [SerializeField] private float CircleRadius = 1;
        [SerializeField] private float ElevationOffset = 0;

        [Header("BulletShell")]
        [SerializeField] private Transform TankTurrentBase;
        [SerializeField] private Transform TankTurrentChild;
        [SerializeField] private GameObject BulletShellPrefab;
        [SerializeField] private float BulletShootSpeed = 5f;
        [SerializeField] private float TimeBetweenShots = 3f;
        [SerializeField] private int BulletAmountToSpawn = 5;
        private Vector3 positionOffset;
        private float angle;

        private UITankPool bulletPool;
        private float timer = 0f;

        private void Start()
        {
            bulletPool = new UITankPool(BulletShellPrefab, BulletAmountToSpawn); 
        }
        private void Update()
        {
            //CreateBullet();
            //ShootBullets();
        }
        private void LateUpdate()
        {
            TankMoveAround();
        }

        private void TankMoveAround()
        {
            positionOffset.Set(Mathf.Cos(angle) * CircleRadius, ElevationOffset, Mathf.Sin(angle) * CircleRadius);

            transform.position = DestroyedTank.position + positionOffset;
            angle += Time.deltaTime * RotationSpeed;

            TankTurrentBase.transform.LookAt(DestroyedTank.position);
        }

        private void CreateBullet()
        {
            //GameObject shell = Instantiate(BulletShell, TankTurrentChild.transform.position, TankTurrentChild.transform.rotation);
            //shell.GetComponent<Rigidbody>().velocity = BulletShootSpeed * TankTurrentBase.forward;
        }
        void ShootBullets()
        {
            timer += Time.deltaTime;

            if (timer >= TimeBetweenShots)
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
                bullet.transform.position = DestroyedTank.position;
                bullet.transform.rotation = DestroyedTank.rotation;
                bullet.SetActive(true);

                // Add force or apply other behaviors to the bullet
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * BulletShootSpeed;
            }
        }
    }
}
