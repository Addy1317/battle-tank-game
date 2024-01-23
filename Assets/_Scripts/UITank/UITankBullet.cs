using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class UITankBullet : MonoBehaviour
    {
        public GameObject explosion;
        private Rigidbody rb;
        private void OnCollisionEnter(Collision col)
        {
            if(col.gameObject.tag =="BustedTank")
            {
                GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
                Destroy(exp, 0.5f);
                Destroy(this.gameObject);
            }
        }

        private void Start()
        {
            rb = this.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            this.transform.forward = rb.velocity;
        }
    }
}