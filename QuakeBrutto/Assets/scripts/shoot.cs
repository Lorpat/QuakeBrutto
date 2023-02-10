using UnityEngine;
using UnityEngine.UI;

namespace Assets.scripts
{
    public class shoot : MonoBehaviour
    {

        //public float shootForce = 10f;
        //public float shootRange = 50f;
        //public float projectileSpeed = 10f;
        //public Transform shootPoint;

        //private void Update()
        //{
        //    if (Input.GetKey(KeyCode.Mouse0))
        //    {
        //        Shoot();
        //    }
        //}


        //private void Shoot()
        //{
        //    Ray ray = new Ray(shootPoint.position, shootPoint.forward);
        //    RaycastHit hitInfo;

        //    if (Physics.Raycast(ray, out hitInfo, shootRange))
        //    {
        //        Debug.Log("Hit: " + hitInfo.transform.name);

        //        // Apply force to the hit object
        //        // Rigidbody rb = hitInfo.rigidbody;
        //        // if (rb != null)
        //        // {
        //        //     rb.AddForceAtPosition(shootPoint.forward * shootForce, hitInfo.point);
        //        // }
        //    }
        //}

        public float damage = 10f;
        public float range = 100f;
        public float fireRate = 15f;

        public Camera fpsCam;
        public ParticleSystem muzzleFlash;
        public float nextTimeToFire = 0f;
        public Image crossHair;

        private void Update()
        {
            // Per armi a colpo singolo o che si deve premere ogni volta per sparare usare Input.GetKeyDown(KeyCode.Mouse0)
            if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                muzzleFlash.Play();
                Shoot();
            }
        }

        private void Shoot()
        {
            Ray ray = new Ray(fpsCam.transform.position, fpsCam.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range))
            {
                Debug.Log(hit.transform.name);

                enemy enemy = hit.transform.GetComponent<enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                    crossHair.color=Color.red;
                    Invoke("changeToGreen", 0.25f);
                }
            }
        }

        private void changeToGreen()
        {
            crossHair.color = Color.green;
        }
    }
}