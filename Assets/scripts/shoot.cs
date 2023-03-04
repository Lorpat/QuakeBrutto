    using UnityEngine;
using UnityEngine.UI;

namespace Assets.scripts
{
    public class shoot : MonoBehaviour
    {
        public float damage = 10f;
        public float range = 100f;
        public float fireRate = 15f;

        public Camera fpsCam;
        public ParticleSystem muzzleFlash;
        public Transform bulletSpawnPoint;
        public Image crossHair;
        public GameObject BulletTrail;
        public GameObject BulletHole;
        public Transform bulletHoleContainer;
        public TrailRenderer tr;

        private float nextTimeToFire = 0f;
        private bool isFiring = false;
        
        private void Start()
        {
            //Instanzia il GameObject con componente TrailRenderer
            GameObject bulletTrail = Instantiate(BulletTrail, bulletSpawnPoint.position, Quaternion.identity);
            tr = bulletTrail.GetComponent<TrailRenderer>();
        }

        private void Update()
        {
            //Per armi a colpo singolo o che si deve premere ogni volta per sparare usare
            //Input.GetKeyDown(KeyCode.Mouse0)
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                isFiring = true;
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                muzzleFlash.Stop();
                isFiring = false;
                tr.Clear();
            }

            if (isFiring && Time.time >= nextTimeToFire)
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
            
            if (Physics.Raycast(ray, out hit, range)) // se il raycast colpisce qualcosa
            {

                Debug.Log(hit.transform.name);
                Vector3 bulletHoleRotation = new Vector3(0f, 180f, 0f);
                Vector3 bulletHoleOffset = new Vector3(0f, 0f, -0.001f);

                // genera il bulletHole. L'offset è per evitare l'overlap con le texture, la rotazione per
                // "raddrizzare" il bulletHole, e il container per evitare sovraffollamento nella hierarchy di unity
                GameObject bulletHole = Instantiate(BulletHole, hit.point, Quaternion.Euler(bulletHoleRotation));
                bulletHole.transform.position += bulletHoleOffset;
                bulletHole.transform.SetParent(bulletHoleContainer);
                
                enemy enemy = hit.transform.GetComponent<enemy>();
                if (enemy != null) // se ciò che viene colpito ha un component "enemy", allora l'enemy prende danno
                {
                    enemy.TakeDamage(damage);
                    crossHair.color = Color.red;
                    Invoke("changeToGreen", 0.25f);
                }

                // aggiorna la posizione del BulletTrail
                tr.transform.position = hit.point;
                tr.AddPosition(hit.point);
                tr.transform.position = bulletSpawnPoint.position;
            }
            else
            {
                // aggiorna la posizione del BulletTrail nel caso in cui non colpisca niente
                tr.transform.position = ray.origin + (ray.direction.normalized * range);
                tr.AddPosition(ray.origin + (ray.direction.normalized * range));
            }
        }
    
        private void changeToGreen()
        {
            crossHair.color = Color.green;
        }

    }
}
