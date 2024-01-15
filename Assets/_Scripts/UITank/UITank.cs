using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class UITank : MonoBehaviour
    {
        [Header("Object Reference")]
        [SerializeField] private GameObject bustedTank;
        [SerializeField] private Transform Target;
        [SerializeField] private Transform Turrent;

        [Header("Values")]
        [SerializeField] private float RotationSpeed = 1;
        [SerializeField] private float CircleRadius = 1;
        [SerializeField] private float ElevationOffset = 0;

        private Vector3 positionOffset;
        private float angle;

        private void LateUpdate()
        {
            TankMoveAround();
        }

        private void TankMoveAround()
        {
            positionOffset.Set(
                  Mathf.Cos(angle) * CircleRadius,
                  ElevationOffset,
                  Mathf.Sin(angle) * CircleRadius);

            transform.position = Target.position + positionOffset;
            angle += Time.deltaTime * RotationSpeed;

            Turrent.transform.LookAt(Target.position);
        }
    }
}
